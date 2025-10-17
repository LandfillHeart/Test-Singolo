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

		public void AddToOrder(IShopItem item)
		{
			ItemsInOrder.Add(item);
		}

		public void RemoveFromOrder(int index)
		{
			ItemsInOrder.RemoveAt(index);
		}

		public void ConcludeOrder()
		{
			// get all the pricing, return a bill
			DateOfCompletion = DateTime.Now;
		}

		public void CancelOrder()
		{

		}
	}
}
