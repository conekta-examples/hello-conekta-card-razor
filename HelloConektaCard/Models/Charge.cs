using System;
using conekta;

namespace HelloConektaCard
{
	public class Charge : conekta.Charge
	{	
		public Shipping shipment { get; set; }
	}
}
