using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {


        //metoda ktora rekurencyjnie spr email itptip
        public static async Task Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("parametr url nie zostal podany");//mniej zagnierzdzen tym lepiej nic nie ma to wychodzi jak jest to leci dalej 
            string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            try
            {
                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");
                //kolekcje
                var list = new List<string>();
                var zbior = new HashSet<string>();
                var slownik = new Dictionary<string, int>();//hashmap z javy - klucz,wrt

                // pozbyc sie zagniedzenia poniezej i dodac 
                if (!result.IsSuccessStatusCode) return;
                    //if (result.IsSuccessStatusCode)
                
                    string html = await result.Content.ReadAsStringAsync();//czeka na pobranie calej strony
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                    var matches = regex.Matches(html);
                    foreach (var m in matches) { 
                        Console.WriteLine(m);
                    }

            }catch(Exception ex)
            {
               // string blad=string.Format("wsyatpil blad {0}", ex.ToString());//{0}-pozwala na konktatenacje
                Console.WriteLine($"blad!:{ ex.ToString()}");//to jest to co wyzej automatycznie to co jest w {} jest pzetwarzane na blad 
            }


            Console.WriteLine("Koniec!");
        }
    }
}
