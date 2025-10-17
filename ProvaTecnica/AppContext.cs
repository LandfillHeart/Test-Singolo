using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica
{
	public class AppContext
	{
		#region Singleton
		private static AppContext instance;
		public static AppContext Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AppContext();
				}
				return instance;
			}
		}
		private AppContext()
		{
			// read from server the user's location, applicable discounts, etc
			// statically defined now, but in the future this could make a server request based on the user's IP
			currency = "€";
			iva = 22f;
			shopWideDiscount = 10f;
		}
		#endregion

		private string currency;
		public string Currency => currency;

		private float iva;
		public float Iva => iva;

		private float shopWideDiscount;
		public float ShopWideDiscount => shopWideDiscount;

		private PricingContext pricingContext = new PricingContext();

		/// <summary>
		/// Takes base price, translates to user's currency, calculates price based on context (wholesale, discount, standard, etc)
		/// </summary>
		/// <param name="basePrice"></param>
		/// <returns></returns>
		public float GetRealPrice(float basePrice)
		{
			// TO-DO: translate from user currency to server currency
			return pricingContext.GetCost(basePrice);
		}
	}
}
