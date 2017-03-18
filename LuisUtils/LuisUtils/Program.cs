using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using LuisUtils.Model;
using Microsoft.Cognitive.LUIS;

namespace LuisUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            var appId = ConfigurationManager.AppSettings["appId"].ToString();
            var appKey = ConfigurationManager.AppSettings["appKey"].ToString();

            var client = new LUISClient(appId, appKey);

            var intent = new Intent()
            {
                Name = "Internacional"
            };

            var result = client.CreateIntent(intent);


            for (int i = 0; i < 10; i++)
            {
                Console.ReadLine();

            }

        }
    }
}
