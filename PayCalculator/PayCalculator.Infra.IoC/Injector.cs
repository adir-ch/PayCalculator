using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Infra.IoC
{
    public class Injector
    {
        private static readonly Lazy<Injector> _instance = new Lazy<Injector>(() => new Injector());
        private IUnityContainer _container;

        public static Injector Instance
        {
            get { return _instance.Value; }
        }

        public T Inject<T>(string Name = null)
        {
            return _container.Resolve<T>(Name);
        }

        private Injector()
        {
            _container = new UnityContainer();
            _container.LoadConfiguration();
            ContainerAdditionalConfiguration();
        }

        private void ContainerAdditionalConfiguration()
        {
        }
    }
}
