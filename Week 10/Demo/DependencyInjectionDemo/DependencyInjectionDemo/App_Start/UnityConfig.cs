using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace DependencyInjectionDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // transient
            container.RegisterType<IMessageService, MessageService>();
            //container.RegisterType<IMessageService, MessageService>(new TransientLifetimeManager());

            // singleton
            //container.RegisterSingleton<IMessageService, MessageService>();
            //container.RegisterType<IMessageService, MessageService>(new ContainerControlledLifetimeManager());

            // scoped
            //container.RegisterType<IMessageService, MessageService>(new HierarchicalLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}