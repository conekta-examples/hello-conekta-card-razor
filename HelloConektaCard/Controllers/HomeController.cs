using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using conekta;

namespace HelloConektaCard.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			var token_id = Request.Form["conektaTokenId"];
			if (!String.IsNullOrEmpty(token_id))
			{
				return Create(token_id);
			}
			else { 
				return View();
			}


		}

		public ActionResult Create(string token) {
			var resultCharge = CreateCharge(token);

			ViewData["Result"] = resultCharge;

			return View("Create");
		}

		private String CreateCharge(string token) {
			try {
				HelloConektaCard.Charge charge_params = new HelloConektaCard.Charge();

				charge_params.description = "Stogies";
				charge_params.amount = 2000; //Prices in cents
				charge_params.currency = "MXN";
				charge_params.reference_id = "9839-wolf_pack"; //This reference can be your order_id
				charge_params.card = token;
				charge_params.details.name = "Arnulfo Quimare";
				charge_params.details.phone = "403-342-0642";
				charge_params.details.email = "logan@x-men.org";
				charge_params.details.line_items[0].name = "Box of Cohiba S1s";
				charge_params.details.line_items[0].description = "Imported From Mex.";
				charge_params.details.line_items[0].quantity = 1;
				charge_params.details.line_items[0].unit_price = 2000;
				charge_params.details.line_items[0].category = "food";
				charge_params.details.billing_address.street1 = "77 Mystery Lane";
				charge_params.details.billing_address.street2 = "Suite 124";
				charge_params.details.billing_address.city = "Darlington";
				charge_params.details.billing_address.state = "NJ";
				charge_params.details.billing_address.zip = "10192";
				charge_params.details.billing_address.country = "Mexico";
				charge_params.details.billing_address.tax_id = "xmn671212drx";
				charge_params.details.billing_address.company_name = "X-Men Inc.";
				charge_params.details.billing_address.phone = "77-777-7777";
				charge_params.details.billing_address.email = "purshasing@x-men.org";
				charge_params.shipment.carrier = "estafeta";
				charge_params.shipment.service = "international";
				charge_params.shipment.price = 20000;
				charge_params.shipment.tracking_id = "XXYYZZ-9990000";
				charge_params.shipment.street1 = "250 Alexis St";
				charge_params.shipment.street2 = "Interior 303";
				charge_params.shipment.street3 = "Col. Condesa";
				charge_params.shipment.city = "Red Deer";
				charge_params.shipment.state = "Alberta";
				charge_params.shipment.zip = "T4N 0B8";
				charge_params.shipment.country = "Canada";

				conekta.Charge charge = new conekta.Charge().create(charge_params.ToString());

				return charge.id.ToString();
			}
			catch (Exception ex) {
				return ex.Message.ToString();
			}
		}
	}
}
