using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;

namespace PayPalSample1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePayment()
        {
            var config = ConfigManager.Instance.GetProperties();

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(accessToken);
            apiContext.Config = config;

            Amount amount = new Amount();
            amount.total = "40";
            amount.currency = "USD";

            Transaction transaction = new Transaction();
            transaction.amount = amount;
            transaction.item_list = new ItemList();
            transaction.item_list.items = new List<Item>();
            transaction.item_list.items.Add(
                new Item()
                {
                    name = "SurfaceBook",
                    description = "The best laptop ever, on a sale",
                    quantity = "2",
                    price = "40",
                    currency = amount.currency
                });

            Payer payer = new Payer();
            payer.payment_method = "paypal";

            Payment payment = new Payment();
            payment.intent = "sale";
            payment.payer = payer;
            payment.transactions = new List<Transaction>();
            payment.transactions.Add(transaction);
            payment.redirect_urls = new RedirectUrls();
            payment.redirect_urls.return_url
                = String.Format("http://{0}{1}",
                        Request.Url.Authority,
                        Url.Action("PaymentApproved"));
            payment.redirect_urls.cancel_url = 
                String.Format("http://{0}{1}",
                        Request.Url.Authority,
                        Url.Action("PaymentCanceled"));

            Payment createdPayment = payment.Create(apiContext);

            return Redirect(createdPayment.GetApprovalUrl());

        }

        public ActionResult PaymentApproved(string paymentId, string PayerId)
        {
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(accessToken);
            apiContext.Config = config;

            Payment payment = Payment.Get(apiContext, paymentId);
            PaymentExecution paymentExecution = new PaymentExecution();
            paymentExecution.payer_id = PayerId;

            Payment executedPayment = payment.Execute(apiContext, paymentExecution);

            return View();
        }

        public ActionResult PaymentCanceled()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}