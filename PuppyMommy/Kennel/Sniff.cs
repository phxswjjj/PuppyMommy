using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.Kennel
{
    public class Sniff
    {
        private Sniff() { }

        public static Sniff Create(string loader, string feeder)
        {
            var sniff = new Sniff();
            sniff.Loader = new Loader.SimpleLoader();
            sniff.Feeder = new Feeder.SimpleFeeder();
            return sniff;
        }

        Loader.ILoader Loader { get; set; }
        Feeder.IFeeder Feeder { get; set; }
    }
}
