using System;
using conekta;

namespace HelloConektaCard
{
	public class Shipping : ShippingAddress
	{
		public string street3 { get; set; }
		public string carrier { get; set; }
		public string service { get; set; }
		public int price { get; set; }
		public string tracking_id { get; set; }
	}
}
