using GreenRiverMedia_ComparisonApp.Models;
using GreenRiverMedia_ComparisonApp.Repository;
using GreenRiverMedia_ComparisonApp.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenRiverMedia_ComparisonApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemRepository items;

        public ItemController(ItemRepository items)
        {
            this.items = items;
        }

        public ActionResult Index()
        {
            var model = items.getAllItems();
            return View(model);
        }

        public ActionResult Comparison()
        {
            ItemViewModel newModel = new ItemViewModel();

            var model = items.getAllItems().ToList();

            var pairs = items.getPairsOfTuples(model);

            newModel.pairsOfItems = items.returningNewItems(pairs, 0, newModel);

            return View("ComparisonItem", newModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comparison(int valueOfFirst, int valueOfSecond, int positionOfFirst, int positionOfSecond, int counter)
        {
            if(ModelState.IsValid)
            {
                var allModel = items.getAllItems().ToList();


                var pairs = items.getPairsOfTuples(allModel);

                items.checkValues(valueOfFirst, valueOfSecond, positionOfFirst, positionOfSecond);

                ModelState.Clear();

                ItemViewModel newModel = new ItemViewModel();

                newModel.counter = items.increasingCounter(counter, newModel);


                if (items.checkValueOfCounter(newModel.counter, newModel, pairs))
                {
                    newModel.pairsOfItems = items.returningNewItems(pairs, counter, newModel);

                    return PartialView("_ComparisonForm", newModel);

                }

                if (!items.checkValueOfCounter(newModel.counter, newModel, pairs))
                {
                    return Json(new { url = Url.Action("Index") });
                }
            }

            return View();
        }

    }
}