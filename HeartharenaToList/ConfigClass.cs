using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HeartharenaToList
{
    static class ConfigClass
    {
        public static void CreateNew(Config conf)
        {
            var x = new XmlSerializer(conf.GetType());
            x.Serialize(Console.Out, conf);
            Console.WriteLine();
            Console.ReadLine();


            
        }

        public static void Save()
        {
            
        }

        public static bool IfConfigExist()
        {

            return false;
        }
    }
}
