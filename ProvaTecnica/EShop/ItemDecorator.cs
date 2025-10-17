using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.EShop
{
	public abstract class ItemDecorator : IShopItem
	{
		public string Name { get; private set; }

		public float BasePrice { get; private set; }

		protected IShopItem component;

		public ItemDecorator(string name, float basePrice, IShopItem component)
		{
			this.Name = name;
			this.BasePrice = basePrice;
			this.component = component;
		}

		public virtual float GetCost()
		{
			return component.GetCost();
		}

		public virtual string Description()
		{
			return component.Description();
		}
	}

	public class SimpleDecorator : ItemDecorator
	{
		public SimpleDecorator(string name, float basePrice, IShopItem component) : base(name, basePrice, component)
		{
		}

		public override float GetCost()
		{
			return base.GetCost() + AppContext.Instance.GetRealPrice(BasePrice);
		}

		public override string Description()
		{
			return $"{base.Description} + {Name}: {AppContext.Instance.GetRealPrice(BasePrice)}";
		}
	}
}
