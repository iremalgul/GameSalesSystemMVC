
using GameSalesSystemMVC.Contexts;
using GameSalesSystemMVC.Services;
using GameSalesSystemMVC.Services.Implements;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GameSalesSystemMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IRepository<>),typeof(Repository<>));
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IGameService, GameService>();
            container.RegisterType<IPurchaseService, PurchaseService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IReviewService, ReviewService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}