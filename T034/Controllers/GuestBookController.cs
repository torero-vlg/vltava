using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Db.Dto;
using Db.Entity;
using Db.Services;
using Db.Services.Common;
using Ninject;
using OAuth2;
using T034.Tools.Attribute;
using T034.ViewModel;

namespace T034.Controllers
{
    public class GuestBookController : BaseController
    {
        [Inject]
        public IGuestBookItemService GuestBookItemService { get; set; }

        public GuestBookController(AuthorizationRoot authorizationRoot) : base(authorizationRoot)
        {
        }

        [Role("Administrator")]
        public ActionResult List()
        {
            try
            {
                var items = GuestBookItemService.Select();

                var model = new List<GuestBookItemViewModel>();
                model = Mapper.Map(items, model);

                return View(model);
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);
                return View("ServerError", (object)"Получение списка");
            }
        }

        [HttpGet]
        [Role("Administrator")]
        public ActionResult AddOrEdit(int? id)
        {
            var dto = new GuestBookItemDto();
            if (id.HasValue)
            {
                dto = GuestBookItemService.Get(id.Value);
            }

            return View(dto);
        }

        [Role("Administrator")]
        public ActionResult AddOrEdit(GuestBookItemDto model)
        {
            try
            {
                if (model.Id > 0)
                {
                    GuestBookItemService.Update(model);
                }
                else
                {
                    GuestBookItemService.Create(model);
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResult { Status = StatusOperation.Error, Message = ex.Message });
            }
            return Json(new OperationResult { Status = StatusOperation.Success, Message = "Операция выполнена успешно" });
        }

        [Role("Administrator")]
        public ActionResult Delete(int menuItemId)
        {
            try
            {
                var result = GuestBookItemService.Delete(menuItemId);
                if (result.Status == StatusOperation.Error)
                {
                    Logger.Error(result.Message);
                    return View("ServerError", (object)result.Message);
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);
                return View("ServerError", (object)"Получение списка");
            }
        }
    }
}
