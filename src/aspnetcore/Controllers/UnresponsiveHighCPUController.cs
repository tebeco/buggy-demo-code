﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BuggyDemoCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuggyDemoCode.Controllers
{
    public class UnresponsiveHighCPUController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("highcpu/concatonate-large-strings")]
        public IActionResult ConcatString()
        {
            var html = "<table cellpadding=\"0\" cellspacing=\"0\"><tbody><tr>";
            var newrocord = new DataRecord() { FirstName = "Marco", LastName = "Polo", Address1 = "Lichfield Road", Address2 = "", City = "", State = "Indiana" };

            foreach (var rec in newrocord.MyList)
            {
                html += html + string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td> </tr>", rec.FirstName, rec.LastName, rec.Address1, rec.Address2, rec.City, rec.State);
            }

            html += html + "</table>";

            return Ok(html);
        }

        [HttpGet("highcpu/poorly-designed-regex")]
        public IActionResult PoorRegex()
        {
            string search = "https://www.poppastring.com/blog/photos/a.197028616990372.62904.196982426994991/1186500984709792/?type=1&permPage=1";

            return Ok(Regex.IsMatch(search, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"));
        }
    }
}
