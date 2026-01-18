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
            // A container is a logical unit that holds registrations of types
            var container = new UnityContainer();

            // transient ( default )
            container.RegisterType<IMessageService, MessageService>();
            //container.RegisterType<IMessageService, MessageService>(new TransientLifetimeManager());

            // singleton
            //container.RegisterSingleton<IMessageService, MessageService>();
            //container.RegisterType<IMessageService, MessageService>(new ContainerControlledLifetimeManager());

            // scoped
            //container.RegisterType<IMessageService, MessageService>(new HierarchicalLifetimeManager());

            // Set the dependency resolver for Web API to use Unity
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}