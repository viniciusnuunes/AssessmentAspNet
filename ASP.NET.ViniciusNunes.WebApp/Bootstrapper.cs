using ASP.NET.ViniciusNunes.WebApp.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;

namespace ASP.NET.ViniciusNunes.WebApp
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<ILivroRepository, LivroRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}