
using ContactManager.Extensions;
using ContactManager.Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.WEBUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICVSFacade _cVSFacade;
        public HomeController(ICVSFacade cVSFacade)
        {
            _cVSFacade = cVSFacade;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Opens()
        {
            // this.WriteToCSV();
            return View();
        }


        [HttpPost]
        public IActionResult Opens(IFormFile file)
        {
            if (file != null)
            {
                var result = file.DataCSVReader();
                if (result is null)
                {
                    return Json("it is emoty");
                }
                else
                {
                    foreach (var item in result)
                    {
                        _cVSFacade.Add(item);
                    }
                    return RedirectToAction("Index");
                }
            }




            return View();
        }





        //public IActionResult LoadData()
        //{

        //    try
        //    {
        //        var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //        // Skiping number of Rows count  
        //        var start = Request.Form["start"].FirstOrDefault();
        //        // Paging Length 10,20  
        //        var length = Request.Form["length"].FirstOrDefault();
        //        // Sort Column Name  
        //        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        // Sort Column Direction ( asc ,desc)  
        //        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //        // Search Value from (Search box)  
        //        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //        //Paging Size (10,20,50,100)  
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;

        //        // Getting all Customer data  
        //        var customerData = _cVSFacade.GetAll()
        //           .AsQueryable()
        //            ;
        //        //var customerData = (from tempcustomer in _cVSFacade.GetAll()

        //        //                    select tempcustomer)
        //        //                    .AsQueryable();

        //        //Sorting  
        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //        {

        //            customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);

        //            //customerData = customerData.Where(m => m.Name == searchValue ||
        //            //               (m.Name != null && m.Name.StartsWith(searchValue) ||

        //            //                m.DateofBirth.ToShortDateString() == searchValue ||
        //            //                (m.DateofBirth.ToShortDateString() != null && m.DateofBirth.ToShortDateString().StartsWith(searchValue)) ||

        //            //                 m.Phone == searchValue ||
        //            //                (m.Phone != null && m.Phone.StartsWith(searchValue)) ||

        //            //                m.Married.ToString() == searchValue ||
        //            //                (m.Married.ToString() != null && m.Married.ToString().StartsWith(searchValue))));
        //        }
        //        //Search  
        //        if (!string.IsNullOrEmpty(searchValue))
        //        {
        //            customerData = customerData.Where(m => m.First == searchValue);
        //        }

        //        //total number of rows count   
        //        recordsTotal = customerData.Count();
        //        //Paging   
        //        var data = customerData.Skip(skip).Take(pageSize).ToList();
        //        //Returning Json Data  
        //        return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
    }
}
