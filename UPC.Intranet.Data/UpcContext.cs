using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UPC.Intranet.Model.Dto.Request;
using UPC.Intranet.Model.Dto.Response;
using UPC.Intranet.Model.Dto.General;
using UPC.Intranet.Model.Model;
using static UPC.Intranet.Model.Dto.General.General;

namespace UPC.Intranet.Data
{
    public class UPC_BD_Context : DbContext, IQueryableUnitOfWork
    {
        public UPC_BD_Context() : base("name=cnUPC")
        {
            Database.Log = (sql) => Debug.Write(sql);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UPC_BD_Context>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Solicitud>()
               .ToTable("SOLICITUD");


            modelBuilder.Entity<Detalle_Solicitud>()
                 .ToTable("DETALLE_SOLICITUD");
        }

        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Detalle_Solicitud> Detalle_Solicitud { get; set; }


        #region IQueryableUnitOfWork
        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }
        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }
        public void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
        public async Task<int> CommitAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;
            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });
                }
            } while (saveFailed);
        }
        public void RollbackChanges()
        {
            base.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }
        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }
        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
        public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await base.Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
        }
        public DbContextTransaction BeginTransaction()
        {
            return base.Database.BeginTransaction();
        }

        #endregion

        public Detalle_SolicitudDtoResponse ListDetailSolution(Detalle_SolicitudDtoRequest objDetalleSolicitud)
        {
            try
            {
                object[] parametros = {
                new OracleParameter("Val_COD_LINEA_NEGOCIO", OracleDbType.Char,( objDetalleSolicitud.COD_LINEA_NEGOCIO ==variables.nulo) ? variables.vacio :objDetalleSolicitud.COD_LINEA_NEGOCIO, ParameterDirection.Input),
                new OracleParameter("Val_COD_MODAL_EST", OracleDbType.Char,( objDetalleSolicitud.COD_MODAL_EST ==variables.nulo) ? variables.vacio:objDetalleSolicitud.COD_MODAL_EST, ParameterDirection.Input),
                new OracleParameter("Val_COD_PERIODO", OracleDbType.Char, (objDetalleSolicitud.COD_PERIODO ==variables.nulo) ?  variables.vacio :objDetalleSolicitud.COD_PERIODO , ParameterDirection.Input),
                new OracleParameter("Val_COD_TRAMITE", OracleDbType.Int32, (objDetalleSolicitud.COD_TRAMITE ==null) ? variables.cero : objDetalleSolicitud.COD_TRAMITE, ParameterDirection.Input),
                new OracleParameter("Val_ESTADO", OracleDbType.Varchar2, (objDetalleSolicitud.ESTADO ==variables.nulo) ? variables.vacio : objDetalleSolicitud.ESTADO, ParameterDirection.Input),
                new OracleParameter("ObjResponse", OracleDbType.RefCursor, ParameterDirection.Output)
            };
                var ResponseStore = ExecuteQuery<Detalle_SolicitudDtoResponse>("BEGIN STP_LIST_SOLICITUD_DETALLE(:Val_COD_LINEA_NEGOCIO, :Val_COD_MODAL_EST,:Val_COD_PERIODO,:Val_COD_TRAMITE,:Val_ESTADO,:ObjResponse); end;", parametros).ToList();
                var Response = new Detalle_SolicitudDtoResponse
                {
                    ListDetalle_SolicitudDtoResponse = ResponseStore

                };

                return Response;
            }
            catch
            {

                List<Detalle_SolicitudDtoResponse> a = new List<Detalle_SolicitudDtoResponse>();
                var Response = new Detalle_SolicitudDtoResponse
                {
                    ListDetalle_SolicitudDtoResponse = a

                };
                return Response;
                     
            }
         




        }
    }

    public abstract class BaseDomainContext : DbContext
    {
        static BaseDomainContext()
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }

}
