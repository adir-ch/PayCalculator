using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class LocationFactoryExt : LocationFactory
    {
        protected override ILocation GenerateLocationObject(string locationName)
        {
            string registeredLocationName; 
            switch (locationName.ToLower())
            {
                case "australia":
                    {
                        registeredLocationName = "AustraliaLocation";
                        break;
                    }
                case "germany":
                    {
                        registeredLocationName = "GermanyLocation";
                        break;
                    }
                case "newzealand":
                    {
                        registeredLocationName = "NewZealandLocation";
                        break;
                    }
                default:
                    {
                        registeredLocationName = "DefaultCoreLocation";
                        break;
                    }
            }

            var location = Injector.Instance.Inject<ILocation>(registeredLocationName);
            return location; 
        }
    }
}
