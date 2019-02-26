using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.OtManager.Models.DTO;
using SecondSightWeb.Areas.OtManager.Models.EditModels;
using SecondSightWeb.Areas.OtManager.Models.ViewModels;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.OtManager.Controllers
{
    public class SurgicalConsumptionController : Controller
    {
        IExaminationDropsService examinationDropsService = new ExaminationDropsService();
        IKnivesService knivesService = new KnivesService();
        IDisposablesService disposablesService = new DisposablesService();
        IMiscellaneousService miscellaneousService = new MiscellaneousService();
        ITabletsService tabletsService = new TabletsService();
        IInjectablesService injectablesService = new InjectablesService();
        IStoreHistoryService storeHistoryService = new StoreHistoryService();
        IStoreService storeService = new StoreService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        ICategoryService categoryService = new CategoryService();

        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();

        // GET: OtManager/SurgicalConsumption
        public ActionResult Index()
        {
            SurgicalConsumptionViewModel surgicalConsumptionViewModel = new SurgicalConsumptionViewModel();
            BindSurgicalConsumption(surgicalConsumptionViewModel);
            List<SurgicalInjectableConsumptionList> SurgicalInjectableConsumptionList = new List<SurgicalInjectableConsumptionList>();
            //TempData["SurgicalInjectableConsumptionList"] = SurgicalInjectableConsumptionList;
            return View(surgicalConsumptionViewModel);
        }
        private void BindSurgicalConsumption(SurgicalConsumptionViewModel surgicalConsumptionViewModel)
        {
            surgicalConsumptionViewModel.Disposables = disposablesService.GetAll();
            surgicalConsumptionViewModel.ExaminationDrops = examinationDropsService.GetAll();
            surgicalConsumptionViewModel.Injectables = injectablesService.GetAll();
            surgicalConsumptionViewModel.Knives = knivesService.GetAll();
            surgicalConsumptionViewModel.StoreHistory = storeHistoryService.GetAll();
            surgicalConsumptionViewModel.Tablets = tabletsService.GetAll();
            surgicalConsumptionViewModel.Miscellaneous = miscellaneousService.GetAll();
            SearchStoreProcedureDB<OpeartionDetailsDTO> searchStoreProcedureDB = new SearchStoreProcedureDB<OpeartionDetailsDTO>();
            surgicalConsumptionViewModel.OpeartionDetailsDTO = searchStoreProcedureDB.GetOperationList();
        }

        public JsonResult GetItemDetailsByBatchNumber(string batchNumber)
        {
            //IEnumerable<OTCharges> lstOTCharges = oTChargesService.GetAll().Where(x => x.OtCategoryId == CategoryId);
            ItemDetails itemDetails = (from sHService in storeHistoryService.GetAll()
                                       join sService in storeService.GetAll() on sHService.StoreId equals sService.Storeid
                                       join cService in categoryService.GetAll() on sService.CategoryId equals cService.CategoryId
                                       join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                       where sHService.BatchNumber == batchNumber
                                       select new ItemDetails
                                       {
                                           CategoryName = cMService.CategoryName,
                                           ItemName = cService.ItemName,
                                           ItemDescription = cService.ItemDescription,
                                           ManufacturingDate = sHService.ManufacturingDate.ToString(),
                                           ExperyDate = sHService.ExperyDate.ToString(),
                                           Qty = sService.Qty
                                       }).FirstOrDefault();
            return Json(itemDetails, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveData(string SurgicalInjectableConsumptionList,string SurgicalDisposablesConsumptionList,string SurgicalDropsConsumptionList,string SurgicalKnivesConsumptionList,string SurgicalMiscellaneousConsumptionList,string SurgicalTabletsConsumptionList,string operationId)
        {
            Result result = new Result();
            try
            {
                ISurgicalDisposablesConsumptionListService surgicalDisposablesConsumptionListService = new SurgicalDisposablesConsumptionListService();
                ISurgicalDropsConsumptionListService surgicalDropsConsumptionListService = new SurgicalDropsConsumptionListService();
                ISurgicalMiscellaneousConsumptionListService surgicalMiscellaneousConsumptionListService = new SurgicalMiscellaneousConsumptionListService();
                ISurgicalKnivesConsumptionListService surgicalKnivesConsumptionListService = new SurgicalKnivesConsumptionListService();
                ISurgicalTabletsConsumptionListService surgicalTabletsConsumptionListService = new SurgicalTabletsConsumptionListService();
                ISurgicalInjectableConsumptionListService surgicalInjectablesConsumptionListService = new SurgicalInjectableConsumptionListService();

                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //List<SurgicalInjectableConsumptionList> surgicalInjectableConsumptionList = serializer.Deserialize<List<SurgicalInjectableConsumptionList>>(SurgicalInjectableConsumptionList);

                List<SurgicalInjectableConsumptionList> surgicalInjectableConsumptionList = new List<SecondSightWeb.Models.SurgicalInjectableConsumptionList>();
                surgicalInjectableConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalInjectableConsumptionList>>(surgicalInjectableConsumptionList, SurgicalInjectableConsumptionList);

                List<SurgicalKnivesConsumptionList> surgicalKnivesConsumptionList = new List<SecondSightWeb.Models.SurgicalKnivesConsumptionList>();
                surgicalKnivesConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalKnivesConsumptionList>>(surgicalKnivesConsumptionList, SurgicalKnivesConsumptionList);

                List<SurgicalMiscellaneousConsumptionList> surgicalMiscellaneousConsumptionList = new List<SecondSightWeb.Models.SurgicalMiscellaneousConsumptionList>();
                surgicalMiscellaneousConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalMiscellaneousConsumptionList>>(surgicalMiscellaneousConsumptionList, SurgicalMiscellaneousConsumptionList);

                List<SurgicalTabletsConsumptionList> surgicalTabletsConsumptionList = new List<SecondSightWeb.Models.SurgicalTabletsConsumptionList>();
                surgicalTabletsConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalTabletsConsumptionList>>(surgicalTabletsConsumptionList, SurgicalTabletsConsumptionList);

                List<SurgicalDisposablesConsumptionList> surgicalDisposablesConsumptionList = new List<SecondSightWeb.Models.SurgicalDisposablesConsumptionList>();
                surgicalDisposablesConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalDisposablesConsumptionList>>(surgicalDisposablesConsumptionList, SurgicalDisposablesConsumptionList);

                List<SurgicalDropsConsumptionList> surgicalDropsConsumptionList = new List<SecondSightWeb.Models.SurgicalDropsConsumptionList>();
                surgicalDropsConsumptionList = CRMSerializer.Instance.Deserialize<List<SurgicalDropsConsumptionList>>(surgicalDropsConsumptionList, SurgicalDropsConsumptionList);

                foreach (var item in surgicalInjectableConsumptionList)
                {
                    surgicalInjectablesConsumptionListService.Add(item);
                }

                foreach (var item in surgicalKnivesConsumptionList)
                {
                    surgicalKnivesConsumptionListService.Add(item);
                }

                foreach (var item in surgicalMiscellaneousConsumptionList)
                {
                    surgicalMiscellaneousConsumptionListService.Add(item);
                }

                foreach (var item in surgicalTabletsConsumptionList)
                {
                    surgicalTabletsConsumptionListService.Add(item);
                }

                foreach (var item in surgicalDisposablesConsumptionList)
                {
                    surgicalDisposablesConsumptionListService.Add(item);
                }

                foreach (var item in surgicalDropsConsumptionList)
                {
                    surgicalDropsConsumptionListService.Add(item);
                }
                int id = 0;
                id= CRMSerializer.Instance.Deserialize<int>(id, operationId);
                OperarionDetails operarionDetails = operarionDetailsService.GetById(id);
                operarionDetails.IsGeneratedSurgicalConsumptionList = true;
                operarionDetailsService.Update(operarionDetails);
                Session["OperationSuggesstionId"] = operarionDetails.OperationSuggestionId;
                Session["OperationId"] = id;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                result.Data = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: OtManager/SurgicalConsumption/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OtManager/SurgicalConsumption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtManager/SurgicalConsumption/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OtManager/SurgicalConsumption/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OtManager/SurgicalConsumption/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OtManager/SurgicalConsumption/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OtManager/SurgicalConsumption/Delete/5
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

    public class Result
    {
        public bool Data { get; set; } = true;
    }

}
