/*************************************

DO NOT CHANGE THIS FILE - UPDATE GlassMapperScCustom.cs

**************************************/

using System;
using System.Linq;
using Glass.Mapper.Sc.CastleWindsor;
using Glass.Mapper.Sc.Configuration.Attributes;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Glass.Mapper.Sc.Demo.App_Start.GlassMapperSc), "Start")]

namespace Glass.Mapper.Sc.Demo.App_Start
{
	public static class  GlassMapperSc
	{
	    static  GlassMapperSc()
	    {
            _resolver = DependencyResolver.CreateStandardResolver();
	    }
	    public static volatile DependencyResolver _resolver;
	    public static DependencyResolver Resolver
	    {
	        get { return _resolver; }
	    }

		public static void Start()
		{
			//create the resolver
			

			//install the custom services
			GlassMapperScCustom.CastleConfig(_resolver.Container);

			//create a context
			var context = Glass.Mapper.Context.Create(_resolver);
			context.Load(      
				GlassMapperScCustom.GlassLoaders()        				
				);


			GlassMapperScCustom.PostLoad();
		}
	}
}