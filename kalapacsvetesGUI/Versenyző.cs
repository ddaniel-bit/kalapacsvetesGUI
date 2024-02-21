using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalapacsvetesGUI
{
    internal class Versenyző
    {
        string nev;
        char csoport;
        string nemzet_kod;
        string d1;
        string d2;
        string d3;

        public Versenyző(string fajl_sor)
        {
            string[] splitelve = fajl_sor.Split(';');
            nev = splitelve[0];
            csoport = Convert.ToChar(splitelve[1]);
            nemzet_kod = splitelve[2];
            d1 = splitelve[3];
            d2 = splitelve[4];
            d3 = splitelve[5];
        }
        public double eredmeny()
        {
            List<double> osszesen = new List<double>();
            if (d1 != "X" && d1 != "-")
            {
                osszesen.Add(Convert.ToDouble(d1));
            }
            if (d2 != "X" && d2 != "-")
            {
                osszesen.Add(Convert.ToDouble(d2));
            }
            if (d3 != "X" && d3 != "-")
            {
                osszesen.Add(Convert.ToDouble(d3));
            }
            double eredmeny = 0;
            if (osszesen.Count != 0)
            {
                foreach (double s in osszesen)
                {
                    if (eredmeny < s)
                    {
                        eredmeny = s;
                    }
                }
                return eredmeny;
            }
            else
            {
                return -1.0;
            }

        }
        public string kod()
        {
            int startindex = nemzet_kod.IndexOf('(');
            int endindex = nemzet_kod.IndexOf(')');
            return nemzet_kod.Substring(startindex + 1, endindex - startindex - 1);

        }
        public string nemzet()
        {
            int endindex = nemzet_kod.IndexOf(' ');
            return nemzet_kod.Substring(0, endindex - 0);

        }

        public string Nev { get => nev; set => nev = value; }
        public char Csoport { get => csoport; set => csoport = value; }
        public string Nemzet_kod { get => nemzet_kod; set => nemzet_kod = value; }
        public string D1 { get => d1; set => d1 = value; }
        public string D2 { get => d2; set => d2 = value; }
        public string D3 { get => d3; set => d3 = value; }
        public double Eredmeny { get => eredmeny(); }
        public string Kod { get => kod(); }
        public string Nemzet { get => nemzet(); }

    }
}
