using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClinicaCloudPlatform.Model.ViewModels;

namespace ClinicaCloudPlatform.API.Controllers
{
    /// <summary>
    /// This controller is being exposed via ArsMachina
    /// See comments in ArsMachina/Startup.cs
    /// </summary>
    [Route("api/[controller]")]
    public class AccessioningController : Controller
    {
        private static string[] Users = new[]
        {
            "jjones", "ifield", "skratochvil", "tdill", "mthomas", "jbailey", "mgomez", "lzhu", "cwilde", "mkomorowski"
        };

        [HttpGet("[action]")] //new action tokens are cool
        public IEnumerable<Accession> Accessions()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Accession
            {
                ID = index,
                LaunchDateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                Released = ((rng.Next(-20, 55) % 2) == 0).ToString(),
                User = Users[rng.Next(Users.Length)]
            });
        }

        [HttpGet("[action]/{id}")]
        public Accession Accessions(int id)
        {
            var rng = new Random();
            return new Accession
            {
                ID = id,
                LaunchDateFormatted = DateTime.Now.AddDays(id).ToString("d"),
                Released = ((rng.Next(-20, 55) % 2) == 0).ToString(),
                User = Users[rng.Next(Users.Length)]
            };
        }

    }
}
