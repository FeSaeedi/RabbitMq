using BusManagment.Core;
using BusManagment.Host.Models;
using ChannelManagment.Core;
using ChannelManagment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusManagment.Host.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            return View(model);
        }

        [HttpPost]
        
        public ActionResult Index(string Exchange, string QeueuName, string Address, int TypeId)
        {
            IConsumerService consumerServ = new ConsumerService();
            consumerServ.Add(Exchange, QeueuName, Address, TypeId);

            return Index();
        }
        public ActionResult About()
        {

          
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}