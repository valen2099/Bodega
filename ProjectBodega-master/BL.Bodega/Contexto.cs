using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bodega
{
    public class Contexto: DbContext
    {
        public Contexto():base("Data Source=yourfunnypics.db.4232052.hostedresource.com; Initial Catalog=yourfunnypics; User ID=yourfunnypics; Password='Temp%123';")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BodegaV");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Seguridad> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transaccion>  Transacciones{ get; set; }
        public DbSet<Ingres> Ingress { get; set; }
    }
}
