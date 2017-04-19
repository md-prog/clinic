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

        [HttpGet("{barcodeNumber}/{orgNameKey}")]
        public dynamic Get(string BarcodeNumber, string OrgNameKey)
        {
            using (var context = new ArsMachinaLIMSContext())
            {
                var barcodes = context.Barcodes.Where(bc => bc.Number == BarcodeNumber).ToList();
                return barcodes.Where(bc =>
                    JObject.Parse(bc.CustomData ?? "{}")["orgNameKey"].Value<string>() == OrgNameKey)
                    .Select(bc => new { AccessionGuid = bc.AccessionGuid, Number = bc.Number, CustomData = JObject.Parse(bc.CustomData) }).FirstOrDefault();
            }
        }


        [HttpPost("lookup")]
        public dynamic Get([FromBody]dynamic BarcodeRequest)
        {
            dynamic retVal;
            RequestBarcode barcodeRequest;
            var bcJson = ((JObject)BarcodeRequest);
            try { barcodeRequest = bcJson.ToObject<RequestBarcode>(); }
            catch (Exception ex) { throw new FormatException("Error casting request body as RequestBarcode, did JSON change?", ex); }

            using (var context = new ArsMachinaLIMSContext())
            {
                if (barcodeRequest.AccessionGuid != Guid.Empty)
                {
                    retVal = context.Barcodes.Where(bc =>
                        bc.AccessionGuid == barcodeRequest.AccessionGuid)
                            .Select(bc => new { Number = bc.Number, CustomData = JObject.Parse(bc.CustomData) }).ToList();
                }
                else if (barcodeRequest.SpecimenGuids?.Count() > 0)
                {
                    //TODO lookup by specimen
                    retVal = new { Number = "", CustomData = new JObject() };
                }
                else
                {
                    retVal = new { Number = "", CustomData = new JObject() };
                }
            }
            return retVal;
        }

        [HttpPost]
        public string SaveBarcode([FromBody]dynamic SaveBarcodeRequest) //could get user from identity/stormpath but need to think about api usage and caching
        {
            SaveRequestBarcode barcodeRequest;
            var bcJson = ((JObject)SaveBarcodeRequest);

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
                    dbBarcode = newBarcode(barcodeRequest, context);

                if (string.IsNullOrEmpty(dbBarcode.CustomData))
                    dbBarcode.CustomData = "{}";

                var customData = JObject.Parse(dbBarcode.CustomData);

                if (customData.GetValue("orgNameKey") == null)
                    customData.Add("orgNameKey", barcodeRequest.OrgNameKey);

                dbBarcode.AccessionGuid = barcodeRequest.AccessionGuid;
                //SetAccessionGuids(barcodeRequest, customData);

                SetSpecimenGuids(barcodeRequest, customData);

                if (barcodeRequest.CaseGuid != Guid.Empty)
                {
                    //TODO
                }

                dbBarcode.CustomData = customData.ToString();

                context.SaveChanges();

                return dbBarcode.Number;
            }
        }

        private static Barcode newBarcode(SaveRequestBarcode barcodeRequest, ArsMachinaLIMSContext context)
        {
            Barcode dbBarcode = new Barcode();
            dbBarcode.AccessionGuid = barcodeRequest.AccessionGuid;
            context.Barcodes.Add(dbBarcode);
            if (!String.IsNullOrEmpty(barcodeRequest.Number))
                dbBarcode.Number = barcodeRequest.Number;          
            else //save, then set the barcode string to its ID if not provided by user
            {
                context.SaveChanges();
                dbBarcode.Number = dbBarcode.Id.ToString();
            }

            return dbBarcode;
        }

        //private static Guid GetAccessionGuid(JObject customData)
        //{
        //    var retVal = Guid.Empty;
        //    Guid.TryParse(customData["accessionGuid"]?.Value<string>(), out retVal);
        //    return retVal;
        //}

        //private static void SetAccessionGuids(SaveRequestBarcode barcodeRequest, JObject customData)
        //{
        //    if (barcodeRequest.AccessionGuid == Guid.Empty)
        //        throw new Exception("Accession ID must be supplied.");
        //    else
        //    {
        //        Guid existingAccGuidToken;
        //        if (customData.GetValue("accessionGuid") != null && Guid.TryParse(customData.GetValue("accessionGuid").Value<string>(), out existingAccGuidToken))
        //        {
        //            var existingAccGuid = existingAccGuidToken;
        //            if (existingAccGuid != barcodeRequest.AccessionGuid)
        //                throw new Exception("Barcode exists for a different accession.");
        //        }
        //        else
        //            customData.Add("accessionGuid", barcodeRequest.AccessionGuid);
        //    }
        //}

        private static void SetSpecimenGuids(SaveRequestBarcode barcodeRequest, JObject customData)
        {
            var invalidList = false;
            List<Guid> specGuids = null;

            try { specGuids = customData["specimenGuids"]?.Value<List<Guid>>(); }
            catch { invalidList = true; }

            if (invalidList || specGuids == null)
                specGuids = new List<Guid>();

            foreach (var specimenGuid in barcodeRequest.SpecimenGuids)
            {
                if (specimenGuid != Guid.Empty)
                    specGuids.Add(specimenGuid);
            }

            customData["specimenGuids"] = JToken.FromObject(specGuids);
        }
    }
}
