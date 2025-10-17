using ProvaTecnica.EShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica
{
	public interface IPricingStrategy
	{
		public string Name { get; }
		public float GetCost(float baseCost);
	}

	public class WholeSalePricing : IPricingStrategy
	{
		public string Name => "Wholesale Pricing";

		public float GetCost(float baseCost)
		{
			// wholesale, vendita senza iva
			return baseCost;
		}
	}

	public class StandardPricing : IPricingStrategy
	{
		public string Name => "Standard Pricing";

		public float GetCost(float baseCost)
		{
			// price with no special promotions, but with tax
			return baseCost + (baseCost * AppContext.Instance.Iva / 100);
		}
	}

	public class PromoPricing : IPricingStrategy
	{
		public string Name => "Promo Pricing";
		public float GetCost(float baseCost)
		{
			// takes the price WITH TAX from StandardPricing strategy, and applies a discount
			// the discount has to be applied before tax
			float discountedBaseCost = baseCost * AppContext.Instance.ShopWideDiscount / 100;
			return new StandardPricing().GetCost(discountedBaseCost);
		}
	}

	public class PricingContext
	{
		private IPricingStrategy currentStrategy;

		public PricingContext()
		{
			// by default we apply standard strategy
			currentStrategy = new StandardPricing();
		}

		public void SetStrategy()
		{
			// although we could set a strategy directly, it would make more sense if it was done via observer pattern
			// when the server/app context discloses the presence of a wholesale, or a discount, or a user using a discount code, it would make sense to listen to these events and change strategy accordingly
			// then we would have to mix and match strategies for stuff like wholesale + discount, and we can do that internally here in the context
		}

		public float GetCost(float baseCost)
		{
			return currentStrategy.GetCost(baseCost);
		}
	}

}
