using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DB_Context : DbContext
    {
        public DbSet<Mensaje> mensaje { get; set; }
        public DbSet<Ciudad> ciudad { get; set; }
        public DbSet<EntidadBase> entidadbase { get; set; }
        public DbSet<EntidadJuridica> entidadjuridica { get; set; }
        public DbSet<Direccion> direccion { get; set; }
        public DbSet<DocumentoComercial> documentoComercial { get; set; }
        public DbSet<Compra> compra { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<MedioDePago> mediodepago { get; set; }
        public DbSet<Moneda> moneda { get; set; }
        public DbSet<OperacionDeEgreso> operacionDeEgreso { get; set; }
        public DbSet<OperacionDeIngreso> operacionDeIngreso { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<OSC> oscs { get; set; }
        public DbSet<Pais> pais { get; set; }
        public DbSet<PersonaProveedora> personaProveedora { get; set; }
        public DbSet<EntidadJuridicaProveedora> entidadJuridicaProveedora { get; set; }
        public DbSet<Presupuesto> presupuesto { get; set; }
        public DbSet<Proyecto> proyecto { get; set; }
        public DbSet<Provincia> provincia { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Criterio> criterio { get; set; }



        // El string "dbConn" es el nombre del connection string definido en App.config
        public DB_Context() : base("db_tpanual")
        {
            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<DB_Context>(new CreateDatabaseIfNotExists<DB_Context>());
        }

        /*
        Enable-Migrations -EnableAutomaticMigrations -Force -Verbose
        Update-Database -Force -Verbose
        */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizacion>().ToTable("organizacion");

            modelBuilder.Entity<PersonaProveedora>().HasMany(m => m.compras);

            modelBuilder.Entity<PersonaProveedora>().HasMany(m => m.presupuestos);

            //modelBuilder.Entity<PersonaProveedora>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("personaproveedora");
            //});

            modelBuilder.Entity<EntidadJuridicaProveedora>().HasMany(m => m.compras);

            modelBuilder.Entity<EntidadJuridicaProveedora>().HasMany(m => m.presupuestos);

            //modelBuilder.Entity<EntidadJuridicaProveedora>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("entidadjuridicaproveedora");
            //});

            modelBuilder.Entity<EntidadBase>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidadbase");
            });

            modelBuilder.Entity<EntidadJuridica>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidadjuridica");
            });

            modelBuilder.Entity<OperacionDeEgreso>()
                .HasRequired(o => o.Compra)
                .WithRequiredPrincipal( c => c.OperacionDeEgreso);

            modelBuilder.Entity<Item>()
                 .HasMany<Categoria>(I => I.Categorias)
                 .WithMany(C => C.Items)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("ID_Item");
                     cs.MapRightKey("ID_Categoria");
                     cs.ToTable("categoriasxitem");
                 });

            modelBuilder.Entity<Compra>()
                .HasMany<Usuario>(c => c.Revisores)
                .WithMany(u => u.ComprasRevisables)
                .Map(cs =>
                {
                    cs.MapLeftKey("ID_Compra");
                    cs.MapRightKey("ID_Usuario");
                    cs.ToTable("usuariosxcompra");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
