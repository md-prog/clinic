using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.Model.Models;
using ClinicaCloudPlatform.Model.ApiModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ClinicaCloudPlatform.DAL.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Route("api/[controller]")]
    public class BarcodeController : Controller
    {
        // GET: api/values
        [HttpGet("{Id}")]
        public dynamic Get(int Id)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public string SaveBarcode(dynamic BarcodeRequest) //could get user from identity/stormpath but need to think about api usage and caching
        {
            SaveRequestBarcode barcodeRequest;
            var bcJson = ((JObject)BarcodeRequest);
            try { barcodeRequest = bcJson.ToObject<SaveRequestBarcode>(); }
            catch (Exception ex) { throw new FormatException("Error casting request body as SaveRequestBarcode, did JSON change?", ex); }
            using (var context = new ArsMachinaLIMSContext(barcodeRequest.userFullName, barcodeRequest.userHref))
            {
                Barcode dbBarcode = null;

                var dbBarcodes = context.Barcodes.Where(b => b.Number == barcodeRequest.Number).ToList();

                var matchingBarcodes = dbBarcodes.Select(b =>
                    new KeyValuePair<string, Barcode>(
                        JObject.Parse(b.CustomData ?? "{}").Value<string>("orgNameKey") ?? "",
                        b));

                var matchingOrgBarcodes = matchingBarcodes.Where(b => b.Key == barcodeRequest.OrgNameKey);

                if (matchingOrgBarcodes.Count() > 1 || (barcodeRequest.NewBarcode && matchingOrgBarcodes.Count() == 1))
                    throw new Exception("Barcode number must be unique per Organization.");
                else if (matchingOrgBarcodes.Count() == 1)
                    dbBarcode = matchingOrgBarcodes.Single().Value;

                if (dbBarcode == null)
                {
                    dbBarcode = new Barcode();
                    context.Barcodes.Add(dbBarcode);
                    if (!String.IsNullOrEmpty(barcodeRequest.Number))
                        dbBarcode.Number = barcodeRequest.Number;
                    else //save, then set the barcode string to its ID if not provided by user
                    {
                        context.SaveChanges();
                        dbBarcode.Number = dbBarcode.Id.ToString();
                    }
                }                

                if (string.IsNullOrEmpty(dbBarcode.CustomData))
                    dbBarcode.CustomData = "{}";

                var customData = JObject.Parse(dbBarcode.CustomData);

                if (customData.GetValue("orgNameKey") == null)
                    customData.Add("orgNameKey", barcodeRequest.OrgNameKey);

                if (barcodeRequest.SpecimenGuid != Guid.Empty)
                {
                    var specId = context.Specimens.FirstOrDefault(s => s.Guid == barcodeRequest.SpecimenGuid)?.Id;
                    if (specId != null)
                    {
                        var existingSpecIdToken = customData.GetValue("specimenId");
                        if (existingSpecIdToken != null)
                        {
                            int existingSpecimenId = (int)existingSpecIdToken;
                            if (existingSpecimenId != specId)
                                throw new Exception("Barcode exists for a different specimen.");
                        }
                        else
                            customData.Add("specimenId", specId);
                    }
                }

                if (barcodeRequest.AccessionGuid != Guid.Empty)
                {
                    var accId = context.Accessions.FirstOrDefault(s => s.Guid == barcodeRequest.AccessionGuid)?.Id;
                    if (accId != null)
                    {
                        var existingAccIdToken = customData.GetValue("accessionId");
                        if (existingAccIdToken != null)
                        {
                            int existingAccId = (int)existingAccIdToken;
                            if (existingAccId != accId)
                                throw new Exception("Barcode exists for a different accession.");
                        }
                        else
                            customData.Add("accessionId", accId);
                    }
                }

                if (barcodeRequest.CaseGuid != Guid.Empty)
                {
                    var caseId = context.Cases.FirstOrDefault(s => s.Guid == barcodeRequest.CaseGuid)?.Id;
                    if (caseId != null)
                    {
                        var existingCaseIdToken = customData.GetValue("caseId");
                        if (existingCaseIdToken != null)
                        {
                            int existingCaseId = (int)existingCaseIdToken;
                            if (existingCaseId != caseId)
                                throw new Exception("Barcode exists for a different case.");
                        }
                        else
                            customData.Add("caseId", caseId);
                    }
                }

                dbBarcode.CustomData = customData.ToString();

                context.SaveChanges();

                return dbBarcode.Number;
            }
        }
    }
}
