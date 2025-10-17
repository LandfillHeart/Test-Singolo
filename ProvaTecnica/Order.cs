using ProvaTecnica.EShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica
{
	public class Order
	{
		public List<IShopItem> ItemsInOrder = new List<IShopItem>();
		public DateTime DateOfCompletion { get; private set; }

		public bool IsCompleted { get; private set; }

		#region CRUD
		public void AddToOrder(IShopItem item)
		{
			if(IsCompleted) return;
			ItemsInOrder.Add(item);
		}

		public void RemoveFromOrder(int index)
		{
			if (IsCompleted) return;
			ItemsInOrder.RemoveAt(index);
		}

		public string OrderContent()
		{
			string msg = "";
			if (ItemsInOrder.Count == 0)
			{
				return "Il tuo carrello è vuoto";
			}
			int index = 0;
			foreach (IShopItem item in ItemsInOrder)
			{
				msg += $"{index} - {item.Description()} \n";
			}

			return msg;
		}
		#endregion

		public float GetOrderCost()
		{
			float total = 0f;
			foreach (IShopItem item in ItemsInOrder)
			{
				total = item.GetCost();
			}
			return total;
		}

		public void CheckOut()
		{
			IsCompleted = true;
			DateOfCompletion = DateTime.Now;
		}

		public void CancelOrder()
		{

		}
	}
}
