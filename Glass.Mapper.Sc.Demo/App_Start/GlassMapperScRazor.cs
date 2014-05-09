/*************************************

DO NOT CHANGE THIS FILE - UPDATE GlassMapperScCustom.cs

**************************************/

using System;
using System.Linq;
using Glass.Mapper.Sc.CastleWindsor;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Razor;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Glass.Mapper.Sc.Demo.App_Start.GlassMapperScRazor), "Start")]

namespace Glass.Mapper.Sc.Demo.App_Start
{
	public static class  GlassMapperScRazor
	{
		public static void Start()
		{
			//create config
            var config = new Glass.Mapper.Sc.CastleWindsor.Config();

			//create the resolver
			var resolver = DependencyResolver.CreateStandardResolver();

			resolver.Container.Install(new SitecoreInstaller(config));

			//create a context
			var context = Glass.Mapper.Context.Create(resolver, GlassRazorSettings.ContextName);

			var loader = new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Razor");

			context.Load(      
				loader       				
				);

			
		}
	}
}