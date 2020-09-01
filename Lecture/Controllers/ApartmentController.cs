using Lecture.DAO;
using Lecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lecture.Controllers
{
    public class Apartment : Controller
    {
        private readonly ApartmentDbContext _context;
        public Apartment(ApartmentDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddResident(string resName, int resApartmentNumber, bool resHasPets)
        {
            // create new resident object
            ResidentModel newResident = new ResidentModel(){name = resName, apartmentNumber = resApartmentNumber, hasPets = resHasPets};
            // added new resident to database
            _context.Add(newResident);
            // save changes made (addition)
            _context.SaveChanges();
            // return Content($"Created Resident {resName}");
            return View("ViewAllResidents",_context);
        }
        [HttpGet]
        public IActionResult ViewAllResidents()
        {
            // // create display string to build output
            // string displayStr = "";
            // // cast db set property of db context to list
            // List<ResidentModel> residents = _context.residents.ToList();
            // // iterate through list of residents and append properties to display string
            // residents.ForEach(res => displayStr += $"Id : {res.id}\nName : {res.name}\nHas Pets : {res.hasPets}\n");
            // // display displayStr in browser
            // return Content(displayStr);

            // pass ref to db context to default view
            return View(_context);
        }
        [HttpPut]
        public IActionResult UpdateResidentPets(int resID, bool resHasPets)
        {
            // find resident by id
            ResidentModel matchingRes = _context.residents.FirstOrDefault(res => res.id == resID);
            if(matchingRes != null)
            {
                // update resident property
                matchingRes.hasPets = resHasPets;
                // save changes to database
                _context.SaveChanges();
                // return Content("Update Resident");
                return View("ViewAllResidents",_context);
            } else {
                return Content("Resident not found");
            }
            
        }
        
        [HttpDelete]
        public IActionResult DeleteResident(int resID)
        {
            // find resident by id
            ResidentModel matchingRes = _context.residents.FirstOrDefault(res => res.id == resID);
            // removed matching resident
            _context.Remove(matchingRes);
            // save changes to database
            _context.SaveChanges();
            // return Content("Delete Resident");
            return View("ViewAllResidents",_context);
        }

    }
}