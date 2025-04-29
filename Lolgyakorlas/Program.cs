using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolgyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hos> hosok = new List<Hos>();
            foreach (var h in File.ReadAllLines("champions2017_V4.txt").Skip(1))
            {
                hosok.Add(new Hos(h));
            }
            Console.WriteLine($"Az állományban {hosok.Count} hős található");
            Console.WriteLine("Kérem adja meg a hős nevét:");
            string kereses = Console.ReadLine();
            int i = 0;
            bool talalat = false;
            while (talalat == false)
            {
                if (i >= hosok.Count)
                {
                    Console.WriteLine("Kérem adja meg a hős nevét:");
                    kereses = Console.ReadLine();
                }
                i = 0;
                while (i < hosok.Count)
                {
                    i++;
                    if (i < hosok.Count && kereses == hosok[i].Name)
                    {
                        Console.WriteLine($"{hosok[i].Name} adatai: HP:{hosok[i].Hp}; Sebzés:{hosok[i].Attackdamage}");
                        talalat = true;
                    }
                }
            }
            int min = 0;
            for (int j = 0; j < hosok.Count; j++)
            {
                if (hosok[j].Attackdamageperlevel < hosok[min].Attackdamageperlevel)
                {
                    min = j;
                }
            }
            Console.WriteLine($"5.szinten a legkisebb sebzéssel rendelkező hős {hosok[min].Name}; Sebzés={hosok[min].ADLevel(5)}");
            Console.ReadKey();
        }
    }
}
