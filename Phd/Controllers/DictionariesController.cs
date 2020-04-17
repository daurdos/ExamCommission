using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phd.Models;

namespace Phd.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly PhdContext _context;
        public DictionariesController(PhdContext phdContext)
        {
            _context = phdContext;
        }

        [HttpGet]
        public IActionResult GetDisCouncils()
        {
            try
            {
                
                return Json(_context.DisCouncil.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult GetMajors()
        {
            try
            {

                return Json(_context.Major.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }










        // добавляю по гак
        [HttpGet]
        public IActionResult GetCertificationCommission()
        {
            try
            {

                return Json(_context.CertificationCommission.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }









    }
}