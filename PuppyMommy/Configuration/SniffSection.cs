using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EDC.Configuration
{
    public class SniffSection : ConfigurationElement
    {
        [ConfigurationProperty("Loader", IsKey = true, IsRequired = true)]
        public string Loader
        {
            get { return (string)this["Loader"]; }
            set { this["Loader"] = value; }
        }

        [ConfigurationProperty("Feeder", DefaultValue = "SimpleStorer")]
        public string Feeder
        {
            get { return (string)this["Feeder"]; }
            set { this["Feeder"] = value; }
        }
    }
}
