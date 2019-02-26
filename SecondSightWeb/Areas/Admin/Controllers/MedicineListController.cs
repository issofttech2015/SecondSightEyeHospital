using SecondSightWeb.Areas.Admin.Models.ViewModels;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class MedicineListController : Controller
    {
        IMedicineTypeListService medicineTypeListService = new MedicineTypeListService();
        IMedicineListService medicineListService = new MedicineListService();
        // GET: Admin/MedicineList
        public ActionResult Index()
        {
            var medicineList = medicineListService.GetAll();

            var medicineTypeList = medicineTypeListService.GetAll();
            List<MedicineListViewModel> result = (from mct in medicineTypeList
                                                  join ml in medicineList on mct.MedicineTypeId equals ml.MedicineTypeId
                                                  select new MedicineListViewModel
                                                  {
                                                      Id = ml.Id,
                                                      MedicineName = ml.MedicineName,
                                                      MedicineTypeShortCode = mct.MedicineTypeShortCode,
                                                      MedicineTypeName = mct.MedicineTypeName
                                                  }).ToList();
            return View(result);
        }

        public JsonResult GetMedicineList()
        {
            var result = from medicineTypeList in medicineTypeListService.GetAll()
                         join medcineList in medicineListService.GetAll() on medicineTypeList.MedicineTypeId equals medcineList.MedicineTypeId
                         select new
                         {
                             Id = medcineList.Id,
                             MedicineName = medcineList.MedicineName,
                             MedicineTypeShortCode = medicineTypeList.MedicineTypeShortCode,
                             MedicineTypeName = medicineTypeList.MedicineTypeName
                         };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/MedicineList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MedicineList/Create
        public ActionResult Create()
        {
            MedicineListEditModel medicineList = new MedicineListEditModel();
            //medicineList.MedicineTypeList = medicineTypeListService.GetAll();
            BindDatamedicineList(medicineList);
            return View(medicineList);
        }
        private void BindDatamedicineList(MedicineListEditModel medicineList)
        {
            medicineList.MedicineTypeList = medicineTypeListService.GetAll();
        }
        // POST: Admin/MedicineList/Create
        [HttpPost]
        public ActionResult Create(MedicineListEditModel MedicineListEditModel)
        {
            MedicineListEditModel medicineListEditModel = new MedicineListEditModel();
            BindDatamedicineList(medicineListEditModel);
            try
            {
                if (ModelState.IsValid)
                {
                    MedicineList medicineList = new MedicineList()
                    {
                        MedicineName = MedicineListEditModel.MedicineName,
                        MedicineTypeId = MedicineListEditModel.MedicineTypeId
                    };
                    medicineListService.Add(medicineList);
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(medicineListEditModel);
                }
                //medicineList.MedicineTypeList = medicineTypeListService.GetAll();

            }
            catch
            {
                return View(medicineListEditModel);
            }
        }

        // GET: Admin/MedicineList/Edit/5
        public ActionResult Edit(int id)
        {
            MedicineListEditModel medicineListEditModel = new MedicineListEditModel();
            BindDatamedicineList(medicineListEditModel);
            MedicineList medicineList = new MedicineList();
            medicineList = medicineListService.GetById(id);

            medicineListEditModel.MedicineName = medicineList.MedicineName;
            medicineListEditModel.MedicineTypeId = medicineList.MedicineTypeId;
            medicineListEditModel.Id = medicineList.Id;

            return View(medicineListEditModel);
        }

        // POST: Admin/MedicineList/Edit/5
        [HttpPost]
        public ActionResult Edit(MedicineListEditModel medicineListEditModel)
        {
            MedicineListEditModel medicineListEditModelView = new MedicineListEditModel();
            BindDatamedicineList(medicineListEditModelView);
            try
            {
                MedicineList medicineList = new MedicineList();

                medicineList.MedicineName = medicineListEditModel.MedicineName;
                medicineList.MedicineTypeId = medicineListEditModel.MedicineTypeId;
                medicineList.Id = medicineListEditModel.Id;

                medicineListService.Update(medicineList);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(medicineListEditModelView);
            }
        }

        // GET: Admin/MedicineList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MedicineList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
