using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using UPC.Intranet.Data;
using UPC.Intranet.Data.Implementacion;
using UPC.Intranet.Data.Interfaz;
using UPC.Intranet.Bussines.Implementacion;
using UPC.Intranet.Bussines.Interfaz;

namespace UPC.Intranet.Bussines
{
    public static class InjectorConfiguration
    {
        public static void ConfigurationContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();
            container.Register<UPC_BD_Context, UPC_BD_Context>(Lifestyle.Scoped);
            container.Register<IDetalleSolicitudDal, DetalleSolicitudDal>(Lifestyle.Scoped);
            container.Register<IDetalleSolicitudBl, DetalleSolicitudBl>(Lifestyle.Scoped);
            container.Verify();

        }
    }
}
