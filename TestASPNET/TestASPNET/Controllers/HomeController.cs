using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace TestASPNET.Controllers
{
    public class HomeController : Controller
    {
        private  Models.MyDatabaseEntities1 db = new Models.MyDatabaseEntities1();

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public string AjaxTest(string Name, string Secondname, string Adress, string Weight, string Comment, string Radio)
        {
            //Вартість доставки розраховується за принципом:
            //вартість доставки в місто + вага * вартість за кг.
            //вартість за кг - 30 грн
            //Полтава - 20 грн, Київ - 60 грн.Харків - 40 грн
            float costDelivery = 0;
            float weightNum = float.Parse(Weight);
            if (Adress == "Полтава")
            {
                costDelivery = 20 + weightNum * 30;
            }
            if (Adress == "Киев")
            {
                costDelivery = 60 + weightNum * 30;
            }
            if (Adress == "Харьков")
            {
                costDelivery = 40 + weightNum * 30;
            }
            Models.Delivery person = new Models.Delivery
            {
                first_name = Name,
                second_name = Secondname,
                adress = Adress,
                weight = weightNum,
                coment = Comment,
                type = Radio,
                cost = costDelivery
            };
            db.Deliveries.Add(person);
            db.SaveChanges();
            return costDelivery.ToString();
        }
    }
}