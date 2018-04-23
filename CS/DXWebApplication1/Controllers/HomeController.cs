using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial(int? focusedRowIndex, int? draggingIndex, int? targetIndex, string command) {
            var model = DBHelper.DB.Products
                    .OrderBy(q => q.DisplayIndex)
                    .Take(10);

            if (command == "MOVEUP" || command == "MOVEDOWN") {
                int index = focusedRowIndex.Value;
                int focusedRowKey = DBHelper.GetKeyIdByDisplayIndex(index);
                int newIndex = index;
                if (command == "MOVEUP") {
                    newIndex = (index == 0) ? index : index - 1;
                }
                if (command == "MOVEDOWN") {
                    newIndex = (index == model.Count()) ? index : index + 1;
                }
                int rowKey = DBHelper.GetKeyIdByDisplayIndex(newIndex);
                DBHelper.UpdateDisplayIndex(focusedRowKey, newIndex);
                DBHelper.UpdateDisplayIndex(rowKey, index);
                ViewBag.VisibleIndex = newIndex;
            }
            if (command == "DRAGROW") {
                int draggingRowKey = DBHelper.GetKeyIdByDisplayIndex(draggingIndex);
                int targetRowKey = DBHelper.GetKeyIdByDisplayIndex(targetIndex);
                int draggingDirection = (targetIndex < draggingIndex) ? 1 : -1;
                for (int rowIndex = 0; rowIndex < model.Count(); rowIndex++) {
                    int rowKey = DBHelper.GetKeyIdByDisplayIndex(rowIndex);
                    if ((rowIndex > Math.Min(targetIndex.Value, draggingIndex.Value)) && (rowIndex < Math.Max(targetIndex.Value, draggingIndex.Value))) {
                        DBHelper.UpdateDisplayIndex(rowKey, rowIndex + draggingDirection);
                    }
                }
                DBHelper.UpdateDisplayIndex(draggingRowKey, targetIndex);
                DBHelper.UpdateDisplayIndex(targetRowKey, targetIndex + draggingDirection);
            }

            return PartialView("_GridViewPartial", model);
        }
    }
}
