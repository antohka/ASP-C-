using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Models.DatabaseAppEntities2 db = new Models.DatabaseAppEntities2();
        
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
            float cost = 0;
            float weightNum = float.Parse(Weight);
            if (Adress == "Полтава") {
                cost = 20 + weightNum * 30;
            }
            if (Adress == "Киев"){
                cost = 60 + weightNum * 30;
            }
            if (Adress == "Харьков"){
                cost = 40 + weightNum * 30;
            }
            Models.Delivery person = new Models.Delivery
            {
                first_name = Name,
                second_name = Secondname,
                adress = Adress,
                weight = weightNum,
                coment = Comment,
                type = Radio,
                cost_value = cost
            };
            db.Deliveries.Add(person);
            db.SaveChanges();
                      
            return "Ваша заявка принята";
        }





    }
}