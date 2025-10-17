using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.EShop.Server
{
	public static class Server
	{
		public static List<IShopItem> CATALOGUE = new List<IShopItem>()
		{
			new ShopItem("Maglietta", 10f), new ShopItem("Giacca", 50f), new ShopItem("Giubbino", 20f), new ShopItem("Jeans", 15f)
		};

		
	}
}
