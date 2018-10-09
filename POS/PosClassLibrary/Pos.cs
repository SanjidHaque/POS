using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosClassLibrary
{
    public class Pos
    {

        public BoughtItem ForNewItem(BoughtItem boughtItem, int quantity, int itemId)
        {
            var boughtItems = new BoughtItem()
            {
                ItemId = itemId,
                Quantity = quantity
            };
            return boughtItems;
        }

        public BoughtItem ForExistingItem(BoughtItem boughtItem, int quantity)
        {
            boughtItem.Quantity += quantity;
            return boughtItem;
        }

        public void UpdateStock(Stock stock, int quantity)
        {
            stock.Quantity += quantity;
        }

        public Item AddNewItem(string itemName, int itemPrice)
        {
            var newItem = new Item()
            {
                Name = itemName,
                Price = itemPrice
            };
            return newItem;
        }

        public Stock NewItemStock(int itemId, int quantity)
        {
            var newItemStock = new Stock()
            {
                ItemId = itemId,
                Quantity = quantity
            };
            return newItemStock;
        }
    }
}
