using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace EDC.Configuration
{
    [ConfigurationCollection(typeof(DogSection), AddItemName = "Dog", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class DogsSection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DogSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((DogSection)element).Name;
        }
    }
}
