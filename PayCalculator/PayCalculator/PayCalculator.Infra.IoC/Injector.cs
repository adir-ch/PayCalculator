using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

        public void RegisterInstance<T>(T instance, string name)
        {
            _container.RegisterInstance(name, instance);
        }

        public void RegisterType<TFrom, TTo>(string name = null) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(name);
        }

        private Injector()
        {
            _container = new UnityContainer();
            TryLoadingConfigurationFile();
            ContainerAdditionalConfiguration();
        }

        private void TryLoadingConfigurationFile()
        {   
            // needed for testing (since the section does not exist when running tests)
            var configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (configuration != null)
            {
                configuration.Configure(_container);
            }
            else
            {
                // Ugly hack for the integration tests
                TryLoadingAlternateConfigurationFile();
            }
        }

        private void TryLoadingAlternateConfigurationFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unity.config");
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };

            System.Configuration.Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            unitySection.Configure(_container);
        }

        private void ContainerAdditionalConfiguration()
        {
        }
    }
}
