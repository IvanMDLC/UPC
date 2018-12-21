using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using UPC.Intranet.Bussines.Interfaz;
using System.Reflection;
using System.Web.Mvc;
using UPC.Intranet.Bussines.Implementacion;
using UPC.Intranet.Data.Implementacion;
using UPC.Intranet.Data.Interfaz;
using UPC.Intranet.Data;

namespace slnUPC
{
    public static class InitializeContainer
    {
        public static Container Container = new Container();
        public static void Start()
        {
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            Container.Register<UPC_BD_Context, UPC_BD_Context>(Lifestyle.Scoped);
            Container.Register<IDetalleSolicitudDal, DetalleSolicitudDal>(Lifestyle.Scoped);
            Container.Register<IDetalleSolicitudBl, DetalleSolicitudBl>(Lifestyle.Scoped);
            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}