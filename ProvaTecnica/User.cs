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

		private List<Order> ordersMade = new List<Order>();
		
		private Order basket = new Order();

		public void AddToOrder(IShopItem newItem)
		{
			basket.AddToOrder(newItem);
		}

		public void ConcludeOrder()
		{
			ordersMade.Add(basket);
			basket = new Order();
		}

	}
}
