using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosClassLibrary;

namespace POS.Repositories
{
   public interface IRepository
   {
       List<Stock> Items();
       BoughtItem SelectItems(int itemId);
       Stock SelectStocks(int itemId);
       void UpdateStocks();
       void AddToNewCart(BoughtItem boughtItems);
       List<BoughtItem> BoughtItems();
       void DecreaseStock(int itemId, int quantity);
       void ClearCart();
       bool IfAlreadyExists(string itemName);
       int AddNewItem(Item newItem);
   }
}
