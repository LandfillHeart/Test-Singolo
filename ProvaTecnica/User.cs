using ProvaTecnica.EShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica
{
	public class User
	{
		#region Singleton
		private static User instance;
		public static User Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new User();
				}
				return instance;
			}
		}
		private User() { }
		#endregion

		// all the orders the user has completed in the past
		private List<Order> ordersMade = new List<Order>();
		
		// basket is the order the user is currently making - eshops usually only allow one basket
		private Order basket = new Order();

		public void AddToOrder(IShopItem newItem)
		{
			basket.AddToOrder(newItem);
		}

		public void ConcludeOrder()
		{
			ordersMade.Add(basket);
			basket.CheckOut();
			basket = new Order();
		}

		public void CheckOut()
		{
			Console.WriteLine($"Grazie per aver ordinato da noi! Il tuo totale è di : {AppContext.Instance.Currency}{basket.GetOrderCost()}");
			ConcludeOrder();
		}

	}
}
