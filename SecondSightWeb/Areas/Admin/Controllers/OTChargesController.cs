using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.EditModel;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class OTChargesController : Controller
    {
        IOTChargesService oTChargesService = new OTChargesService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();
        // GET: Admin/OTCharges
        public ActionResult Index()
        {
            List<OTChargesViewModel> otchargesviewmodel = (from oTCService in oTChargesService.GetAll()
                                                           join oTCCService in oTChargeCategoryService.GetAll() on oTCService.OtCategoryId equals oTCCService.Id
                                                           select new OTChargesViewModel
                                                           {
                                                               OtChargeCategory = oTCCService.OtChargeCategory,
                                                               AyaCharges = oTCService.AyaCharges,
                                                               ChargesforAnaesthesia = oTCService.ChargesforAnaesthesia,
                                                               ChargesforCardiacMonitor = oTCService.ChargesforCardiacMonitor,
                                                               ChargesforusingAnaestheticMachine = oTCService.ChargesforusingAnaestheticMachine,
                                                               ChargesofusingDiathermy = oTCService.ChargesofusingDiathermy,
                                                               DayCareCharge = oTCService.DayCareCharge,
                                                               DietCharges = oTCService.DietCharges,
                                                               DoctorFees = oTCService.DoctorFees,
                                                               Endolaser = oTCService.Endolaser,
                                                               IOL = oTCService.IOL,
                                                               MaterialsusedinOperation = oTCService.MaterialsusedinOperation,
                                                               MedicinesPurchasedviscoat = oTCService.MedicinesPurchasedviscoat,
                                                               Name = oTCService.Name,
                                                               OtChargeId = oTCService.OtChargeId,
                                                               OtCharges = oTCService.OtCharges,
                                                               OtEquipmentCharges = oTCService.OtEquipmentCharges,
                                                               RoomCharge = oTCService.RoomCharge
                                                           }).ToList();
            return View(otchargesviewmodel);
        }

        // GET: Admin/OTCharges/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private void BindOTChargesEditModel(OTChargesEditModel OTChargesEditModelParam)
        {
            OTChargesEditModelParam.OTChargeCategory = oTChargeCategoryService.GetAll();
        }
        // GET: Admin/OTCharges/Create
        public ActionResult Create()
        {
            OTChargesEditModel oTChargesEditModel = new OTChargesEditModel();
            BindOTChargesEditModel(oTChargesEditModel);
            return View(oTChargesEditModel);
        }

        // POST: Admin/OTCharges/Create
        [HttpPost]
        public ActionResult Create(OTChargesEditModel OTChargesEditModelParam)
        {
            OTChargesEditModel oTChargesEditModel = new OTChargesEditModel();
            BindOTChargesEditModel(oTChargesEditModel);
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    OTCharges oTCharges = new OTCharges();
                    oTCharges = OTChargesEditModelParam.OTCaharges;
                    oTChargesService.Add(oTCharges);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(oTChargesEditModel);
                }
            }
            catch(Exception ex)
            {
                return View(oTChargesEditModel);
            }
        }

        // GET: Admin/OTCharges/Edit/5
        public ActionResult Edit(int id)
        {
            OTChargesEditModel oTChargesEditModel = new OTChargesEditModel();
            oTChargesEditModel.OTCaharges = oTChargesService.GetById(id);
            BindOTChargesEditModel(oTChargesEditModel);
            return View(oTChargesEditModel);
        }

        // POST: Admin/OTCharges/Edit/5
        [HttpPost]
        public ActionResult Edit(OTChargesEditModel OTChargesEditModelParam)
        {
            OTChargesEditModel oTChargesEditModel = new OTChargesEditModel();
            BindOTChargesEditModel(oTChargesEditModel);
            try
            {
                // TODO: Add update logic here
                oTChargesEditModel = OTChargesEditModelParam;
                oTChargesService.Update(oTChargesEditModel.OTCaharges);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(oTChargesEditModel);
            }
        }

        // GET: Admin/OTCharges/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/OTCharges/Delete/5
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
