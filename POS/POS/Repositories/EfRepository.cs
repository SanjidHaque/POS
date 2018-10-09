using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using POS.Models;
using PosClassLibrary;
using System.Data.Entity;
using System.Web.Mvc;


namespace POS.Repositories
{
    public class EfRepository : IRepository
    {
        private ApplicationDbContext _context;

        public EfRepository()
        {
            _context = new ApplicationDbContext();
        }
        public List<Stock> Items()
        {
            var items = _context.Stocks.Include(s => s.Item).ToList();
            return items;
        }

        public BoughtItem SelectItems(int itemId)
        {
            var selectItems = _context.BoughtItems.FirstOrDefault(c => c.ItemId == itemId);
            return selectItems;
        }

        public Stock SelectStocks(int itemId)
        {
            var selectStocks = _context.Stocks.FirstOrDefault(c => c.ItemId == itemId);
            return selectStocks;
        }

        public void UpdateStocks()
        {
            _context.SaveChanges();
        }

        public void AddToNewCart(BoughtItem boughtItems)
        {
            _context.BoughtItems.Add(boughtItems);
            _context.SaveChanges();
        }

        public void AddToExistingCart(BoughtItem boughtItems)
        {
            _context.SaveChanges();
        }

        public List<BoughtItem> BoughtItems()
        {
            var boughtItems = _context.BoughtItems.Include(c => c.Item).ToList();
            return boughtItems;
        }

        public void DecreaseStock(int itemId, int quantity)
        {
            var stock = _context.Stocks.FirstOrDefault(c => c.ItemId == itemId);
            stock.Quantity -= quantity;
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            _context.BoughtItems.RemoveRange(BoughtItems());
            _context.SaveChanges();
        }

        public bool IfAlreadyExists(string itemName)
        {
            var alreadyExists =
                _context.Items.FirstOrDefault(c => c.Name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
            if (alreadyExists == null)
            {
                return false;
            }
            return true;
        }

        public int AddNewItem(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem.Id;
        }

        public void AddNewItemStock(Stock newItemStock)
        {
            _context.Stocks.Add(newItemStock);
            _context.SaveChanges();
        }
        
    }
}