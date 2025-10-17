using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Observer
{
	// when the pricing context changes, the user has to be notified
	// this allows us to send notifications such as new sales happening
	public interface IPricingContextObserver
	{
		public void ContextChanged();
	}

	public interface IPricingContextObservable
	{
		public void AddObserver(IPricingContextObserver observer); 
		public void RemoveObserver(IPricingContextObserver observer);
		public void NotifyObservers();
	}
}
