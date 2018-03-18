using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EDC.Configuration
{
    public class DomainConfig : ConfigurationSection
    {
        [ConfigurationProperty("Dogs", IsRequired = true)]
        public DogsSection Dogs
        {
            get { return (DogsSection)this["Dogs"]; }
            set { this["Dogs"] = value; }
        }
    }
}
