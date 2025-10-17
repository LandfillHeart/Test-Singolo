using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.EShop
{
	public interface IShopItem
	{
		public string Name { get; }
		public float BasePrice { get; }
		public float GetCost();
	}

	public class ShopItem : IShopItem
	{
		public string Name { get; private set; }
		public float BasePrice { get; private set; }

		public ShopItem(string name, float basePrice)
		{
			Name = name;
			BasePrice = basePrice;
		}

		public float GetCost()
		{
			return AppContext.Instance.GetRealPrice(BasePrice);
		}
	}
}
