using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FilterRLC.Models;

namespace FilterRLC.Controllers
{
    public class FilterController : Controller
    {
        private static FilterParams selectedFilter;   //selectec filer by user
        private static int? filterID;                 //ID selected filter to edit
        private static int? IDtoChange;

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FilterForm()
        {
            return View();
        }
        [HttpPost]

        [HttpGet]
        public IActionResult Calculations()
        {
            return View();
        }


        [HttpPost]
        public IActionResult FilterForm(FilterParams filterParams)
        {
            if (ModelState.IsValid)
            {
                if (filterID != null)
                {
                    Repository.ReplaceFilter(filterParams, (int)filterID);
                    filterParams.ID = selectedFilter.ID;
                    filterID = null;
                }
                else
                {
                    filterParams.ID = Repository.Filters.Count();
                    Repository.AddFilter(filterParams);
                    filterID = null;
                }
                return View("Confirmation", filterParams);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListFilters()
        {
            return View(Repository.Filters);
        }
        public IActionResult Waveform(int id)
        {
            FilterParams filter = Repository.Filters.Where(elem => elem.ID == id).
           Select(item => item).First();
            selectedFilter = filter;
            return View(filter);
        }
        [HttpPost]
        public JsonResult JsonData()
        {
            var results = Transmittance.GetTransmittance(selectedFilter);
            return Json(results);
        }

        //The method to edit the parameters of an existing filter.
        [HttpPost]
        public IActionResult EditForm(int id)
        {
            //Based on id, selects filter from repository that matches id
            FilterParams filter = Repository.Filters.Where(elem => elem.ID == id).Select(item => item).First();

            
            //We substitute the search result into the selectedFilter variable
            selectedFilter = filter;
            filterID = filter.ID;                //Stores the selected filter ID for selection
            return View(filter);
        }


        //The method to remove a filter from the repository.
        [HttpPost]
        public IActionResult Delete(int id)
        {
            FilterParams filterToDelete = Repository.Filters.Where(item => item.ID == id).Select(setOfFilters => setOfFilters).First();
            Repository.RemoveFilter(filterToDelete, id);

            //Updating the list of IDs.

            for (IDtoChange = id + 1; IDtoChange < Repository.Filters.Count() + 1; IDtoChange++)
            {
                FilterParams filterToChange = Repository.Filters.Where(item => item.ID == IDtoChange).Select(setOfFilters => setOfFilters).First();
                filterToChange.ID--;
            }
            return RedirectToAction("ListFilters");
        }
    }

}
