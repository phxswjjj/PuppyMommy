using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EDC.Configuration
{
    [ConfigurationCollection(typeof(SniffSection), AddItemName = "Sniff", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DogSection : ConfigurationElementCollection
    {
        public DogSection()
        {
            //AddItemName not effect, so...
            this.AddElementName = "Sniff";
        }

        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
        }

        [ConfigurationProperty("Watch", IsKey = true, IsRequired = true)]
        public string Watch
        {
            get
            {
                return (string)this["Watch"];
            }
        }
        
        [ConfigurationProperty("CronScheduler", DefaultValue = "0/3 * * * * ? *")]
        public string CronScheduler
        {
            get
            {
                return (string)this["CronScheduler"];
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SniffSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((SniffSection)element).Loader;
        }

        public IEnumerable<SniffSection> Sniffs
        {
            get { return this.Cast<SniffSection>(); }
        }
    }
}
