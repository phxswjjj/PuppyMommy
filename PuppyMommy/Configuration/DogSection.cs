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

        [ConfigurationProperty("Watch", IsKey = true, IsRequired = true)]
        public string Watch
        {
            get
            {
                return (string)this["Watch"];
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
    }
}
