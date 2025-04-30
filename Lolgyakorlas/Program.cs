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
            Console.WriteLine("A játékban szereplő kategóriák:");
            List<string> kategoriak = new List<string>();
            foreach (var kategoria in hosok)
            {
                if (!kategoriak.Contains(kategoria.Category))
                { 
                    kategoriak.Add(kategoria.Category);
                }
            }
            for (int k = 0; k < kategoriak.Count; k++)
            {
                Console.WriteLine(kategoriak[k]);
            }
            int harcosAssassin = 0;
            foreach (var hos in hosok)
            {
                if (hos.Category == "Fighter" || hos.Category == "Assassin")
                {
                    harcosAssassin++;
                }
            }
            Console.WriteLine($"Összesen {harcosAssassin} harcos és assassin champion van a játékban");
            double osszharcosdamage = 0;
            foreach (var harcos in hosok)
            {
                if (harcos.Category == "Fighter")
                {
                    osszharcosdamage += harcos.Attackdamage;
                }
            }
            Console.WriteLine($"Harcos kategória össz damage: {osszharcosdamage}");
            double osszmagusdamage = 0;
            foreach (var magus in hosok)
            {
                if (magus.Category == "Mage")
                {
                    osszmagusdamage += magus.Attackdamage;
                }
            }
            Console.WriteLine($"Mágus kategória össz damage: {osszmagusdamage}");
            double osszassassindamage = 0;
            foreach (var assassin in hosok)
            {
                if (assassin.Category == "Assassin")
                {
                    osszassassindamage += assassin.Attackdamage;
                }
            }
            Console.WriteLine($"Assassin kategória össz damage: {osszassassindamage}");
            double ossztankdamage = 0;
            foreach (var tank in hosok)
            {
                if (tank.Category == "Tank")
                {
                    ossztankdamage += tank.Attackdamage;
                }
            }
            Console.WriteLine($"Tank kategória össz damage: {ossztankdamage}");
            double osszmarksmandamage = 0;
            foreach (var marksman in hosok)
            {
                if (marksman.Category == "Marksman")
                {
                    osszmarksmandamage += marksman.Attackdamage;
                }
            }
            Console.WriteLine($"Marksman kategória össz damage: {osszmarksmandamage}");
            double osszsupportdamage = 0;
            foreach (var support in hosok)
            {
                if (support.Category == "Support")
                {
                    osszsupportdamage += support.Attackdamage;
                }
            }
            Console.WriteLine($"Support kategória össz damage: {osszsupportdamage}");
            Console.ReadKey();
        }
    }
}
