using System;
using System.Web.Mvc;
using POS.Repositories;
using PosClassLibrary;

namespace POS.Controllers
{
    public class PosController : Controller
    {
        // GET: Pos
        private EfRepository _repository;
        private Pos _pos;

        public PosController()
        {
            _repository = new EfRepository();
            _pos =  new Pos();
        }

        public ActionResult Index()
        {
            _repository.ClearCart();
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Customer()
        {
            var items = _repository.Items();
            return View(items);
        }
        

        [Route("Pos/AddToCart/{itemId}")]
        public ActionResult AddToCart(int itemId, int quantity)
        {
            var boughtItems = _repository.SelectItems(itemId);
            if (boughtItems == null)
            {
                var addToNewCart = _pos.ForNewItem(boughtItems, quantity, itemId);
                _repository.AddToNewCart(addToNewCart);
                _repository.DecreaseStock(itemId,quantity);
                return RedirectToAction("Customer");
            }
            else
            {
                var addToExistingCart = _pos.ForExistingItem(boughtItems, quantity);
                _repository.AddToExistingCart(addToExistingCart);
                _repository.DecreaseStock(itemId, quantity);
                return RedirectToAction("Customer");
            }
        }

        public ActionResult CheckOut()
        {
            var boughtItems = _repository.BoughtItems();
            return View(boughtItems);
        }

        public ActionResult ShopAgain()
        {
           _repository.ClearCart();
            return RedirectToAction("Customer");
        }

      
        public ActionResult AddToStock()
        {
            var stock = _repository.Items();
            return View(stock);
        }

        [HttpPost]
        public ActionResult IncreaseStock(int itemId, int quantity)
        {
            var selectStocks = _repository.SelectStocks(itemId);
            _pos.UpdateStock(selectStocks, quantity);
            _repository.UpdateStocks();
            return RedirectToAction("AddToStock");
        }

        public ActionResult GetNewItem()
        {
            return View();
        }

        public ActionResult AddNewItem(string itemName, int itemPrice, int quantity)
        {
            if (_repository.IfAlreadyExists(itemName))
            {
                return View("AlreadyExists");
            }
            else
            {
                var newItem = _pos.AddNewItem(itemName, itemPrice);
                var newItemId = _repository.AddNewItem(newItem);
                var addNewItemStock = _pos.NewItemStock(newItemId, quantity);
                _repository.AddNewItemStock(addNewItemStock);
                var items = _repository.Items();
                return View(items);
            }
           
        }

    }
}