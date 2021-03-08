using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SocialNetworking_Kata.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace SocialNetworking_Kata.Web
{
	public class ContainerConfig
	{
		internal static void RegisterContainer(HttpConfiguration httpConfiguration)
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
			//builder.RegisterType<InMemorySocialNetworkingKata_UserProfile>().As<ISocialNetworkingKata_UserProfile>().SingleInstance();
			builder.RegisterType<SocialNetworkingKata_UserProfile>().As<ISocialNetworkingKata_UserProfile>().InstancePerRequest();
			builder.RegisterType<SocialNetworkingKata_UserProfileDbContext>().InstancePerRequest();
			builder.RegisterType<SocialNetworkingKata_Publish>().As<ISocialNetworkingKata_Publish>().InstancePerRequest();
			builder.RegisterType<SocialNetworkingKata_Follow>().As<ISocialNetworkingKata_Follow>().InstancePerRequest();
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}