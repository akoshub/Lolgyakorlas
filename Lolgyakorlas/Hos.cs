using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolgyakorlas
{
    public class Hos
    {
        public Hos(string name, string title, string category, string tag, double hp, double attackdamage, double attackdamageperlevel)
        {
            Name = name;
            Title = title;
            Category = category;
            Tag = tag;
            Hp = hp;
            Attackdamage = attackdamage;
            Attackdamageperlevel = attackdamageperlevel;
        }

        public Hos(string sor)
        {
            string[] elemek = sor.Split(';');
            Name = elemek[0];
            Title = elemek[1];
            Category = elemek[2];
            Tag = elemek[3];
            Hp = double.Parse(elemek[4]);
            Attackdamage = double.Parse(elemek[5]);
            Attackdamageperlevel = double.Parse(elemek[6]);
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Tag { get; private set; }
        public double Hp { get; private set; }
        public double Attackdamage { get; private set; }
        public double Attackdamageperlevel { get; private set; }

        public double ADLevel(int szint)
        {
            if (szint >= 1 || szint <= 18)
            {
                return Attackdamage + (szint - 1) * Attackdamageperlevel;
            }
            else
            {
                return -1;
            }
        }
    }
}
