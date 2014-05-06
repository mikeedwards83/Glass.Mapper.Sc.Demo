using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Glass.Mapper.Caching;
using Glass.Mapper.Configuration;
using Glass.Mapper.Pipelines.ObjectConstruction;
using Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CacheAdd;
using Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CacheCheck;
using Glass.Mapper.Sc.CastleWindsor;
using Glass.Mapper.Sc.Demo.Core.DataHandlers;

namespace Glass.Mapper.Sc.Demo.App_Start
{
    public static  class GlassMapperScCustom
    {
		public static void CastleConfig(IWindsorContainer container){
			var config = new CastleWindsor.Config();

            container.Register(
                Component.For<ICacheManager>().ImplementedBy<InMemoryCache>().LifestyleSingleton()
                );
            
            container.Register(
                Component.For<IObjectConstructionTask>().ImplementedBy<CacheCheckTask>().LifestyleCustom<NoTrackLifestyleManager>()
                );

            container.Register(
                Component.For<AbstractDataMapper>().ImplementedBy<ExifImageFieldDataMapper>().LifestyleCustom<NoTrackLifestyleManager>()
               );
			container.Install(new SitecoreInstaller(config));


            container.Register(
                Component.For<IObjectConstructionTask>().ImplementedBy<CacheAddTask>().LifestyleCustom<NoTrackLifestyleManager>()
                );

		}

		public static IConfigurationLoader[] GlassLoaders(){			
			
			/* USE THIS AREA TO ADD FLUENT CONFIGURATION LOADERS
             * 
             * If you are using Attribute Configuration or automapping/on-demand mapping you don't need to do anything!
             * 
             */

			return new IConfigurationLoader[]{};
		}
		public static void PostLoad(){
			//Remove the comments to activate CodeFist
			/* CODE FIRST START
            var dbs = Sitecore.Configuration.Factory.GetDatabases();
            foreach (var db in dbs)
            {
                var provider = db.GetDataProviders().FirstOrDefault(x => x is GlassDataProvider) as GlassDataProvider;
                if (provider != null)
                {
                    using (new SecurityDisabler())
                    {
                        provider.Initialise(db);
                    }
                }
            }
             * CODE FIRST END
             */
		}
    }
}
