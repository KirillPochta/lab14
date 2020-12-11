using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;using System.Xml;
using System.Xml.Linq;

namespace lab14Serialization
{   
   public  class Program
    {
        static void Main(string[] args)
        {
            hud_film Chebyrashka = new hud_film("Чебурашка",2002,80,3);
            hud_film hud_film1 = new hud_film("Отход", 2001, 89, 9);
            hud_film hud_film2 = new hud_film();
            hud_film[] ArOfHudFilms = new hud_film[] {Chebyrashka,hud_film1 };
            string path = @"C:\Binary.dat";
            BinaryFormatter Bformatter = new BinaryFormatter();
            using (FileStream st = new FileStream(path, FileMode.OpenOrCreate))
            {
                Bformatter.Serialize(st, Chebyrashka);
                Console.WriteLine("Object serialized!");
            }
            using(FileStream st = new FileStream(path,FileMode.Open))
            {
                hud_film NewHudFilm = (hud_film)Bformatter.Deserialize(st);
                Console.WriteLine($"Object deserialized! {Chebyrashka.strct.name_of_film}");

            }
            ///soap
            SoapFormatter Sformatter = new SoapFormatter();
            using(FileStream st = new FileStream(@"C:/SOAP.soap", FileMode.OpenOrCreate))
            {
                Sformatter.Serialize(st, hud_film1);
                Console.WriteLine("Object serialized!");
            }
            using (FileStream st = new FileStream(@"C:/SOAP.soap", FileMode.Open))
            {
                hud_film NewHudFilm1 = (hud_film)Sformatter.Deserialize(st);
                Console.WriteLine($"Object deserialized! {hud_film1.strct.name_of_film}");

            }
            ///json 
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(hud_film));
            using (FileStream st = new FileStream(@"D:/json.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(st, hud_film1);
                Console.WriteLine("Object serialized!");
            }
            using (FileStream st = new FileStream(@"D:/json.json", FileMode.Open))
            {
                hud_film newfilm = (hud_film)jsonSerializer.ReadObject(st);
                Console.WriteLine($"Object deserialized! {hud_film1.strct.name_of_film}");
            }
            //string json = JsonSerializer.Serialize<hud_film>(hud_film1);
            //Console.WriteLine(json);
            //hud_film newd1wd1 = (hud_film)JsonSerializer.Deserialize<hud_film>(json);
            //Console.WriteLine(newd1wd1.strct.name_of_film); /// КУЧА ИСКЛЮЧЕНИЙ!!!!!

            /// xml
            XmlSerializer xml = new XmlSerializer(typeof(hud_film));
            using (FileStream st = new FileStream(@"C:/xml.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(st, hud_film1);
                Console.WriteLine("Object serialized!");
            }
            using (FileStream st = new FileStream(@"C:/xml.xml", FileMode.Open))
            {
                hud_film newfilm = (hud_film)xml.Deserialize(st);
                Console.WriteLine($"Object deserialized! {hud_film1.strct.name_of_film}");
            }


            BinaryFormatter task3 = new BinaryFormatter();
            using (FileStream st = new FileStream(@"C:/task3.txt", FileMode.OpenOrCreate))
            {
                task3.Serialize(st, ArOfHudFilms);
                Console.WriteLine("Object serialized!");
            }

            Console.WriteLine($"Object deserialized!");

            using (FileStream st = new FileStream(@"C:\task3.txt", FileMode.Open))
            {
                hud_film[] NewHudFilm = (hud_film[])task3.Deserialize(st);
                foreach (hud_film item in ArOfHudFilms) Console.WriteLine(item.strct.name_of_film);
            }

            XmlDocument doc = new XmlDocument(); 
            doc.Load(@"C:\\xml1.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("users");
            XmlNode node1 = doc.DocumentElement.SelectSingleNode("customer");
            foreach (XmlNode x in node)
                Console.WriteLine(x.InnerXml);
            foreach (XmlNode x in node1)
                Console.WriteLine(x.InnerXml);
            ///ling to xml 
            ///
            XElement users = new XElement("Users" 
               , new XElement("user", new XElement("Name", "Kirill Pochta"), new XElement("Age", "18"))
               , new XElement("user", new XElement("Name", "Batya"), new XElement("Age", "31"))
               , new XElement("user", new XElement("Name", "Kachalki"), new XElement("Age", "1000"))
               , new XElement("user", new XElement("Name", "Ne Mlinnikov"), new XElement("Age", "0")));
            var res = users.Descendants("user").Where(x => Int32.Parse(x.Element("Age").Value) >= 20).Select(x => x.Element("Name").Value);
            foreach (var item in res)
                Console.WriteLine(item);
        }
    }
}