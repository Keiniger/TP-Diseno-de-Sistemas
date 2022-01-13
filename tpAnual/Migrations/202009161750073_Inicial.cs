namespace TPANUAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ciudad",
                c => new
                    {
                        ID_Ciudad = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Provincia = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Ciudad)
                .ForeignKey("dbo.provincia", t => t.ID_Provincia)
                .Index(t => t.ID_Provincia);
            
            CreateTable(
                "dbo.direccion",
                c => new
                    {
                        ID_Direccion = c.Int(nullable: false, identity: true),
                        Calle = c.String(unicode: false),
                        Depto = c.String(unicode: false),
                        Piso = c.Int(nullable: false),
                        ID_Ciudad = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.documentocomercial",
                c => new
                    {
                        ID_DocumentoComercial = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TipoDocumento = c.String(unicode: false),
                        ID_Egreso = c.Int(nullable: false),
                        ID_Presupuesto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DocumentoComercial)
                .ForeignKey("dbo.operaciondeegreso", t => t.ID_Egreso, cascadeDelete: true)
                .ForeignKey("dbo.presupuesto", t => t.ID_Presupuesto, cascadeDelete: true)
                .Index(t => t.ID_Egreso)
                .Index(t => t.ID_Presupuesto);
            
            CreateTable(
                "dbo.organizacion",
                c => new
                    {
                        ID_Organizacion = c.Int(nullable: false, identity: true),
                        NombreFicticio = c.String(unicode: false),
                        PromedioVentasAnuales = c.Single(nullable: false),
                        ActComisionistaoAgenciaDeViaje = c.Boolean(nullable: false),
                        CantidadDePersonal = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        TipoEntidad_ID_Entidad = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.operaciondeegreso",
                c => new
                    {
                        ID_Egreso = c.Int(nullable: false, identity: true),
                        ID_Ingreso = c.Int(nullable: false),
                        ID_Organizacion = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        ValorTotal = c.Single(nullable: false),
                        ID_MedioDePago = c.Int(nullable: false),
                        TipoEgreso_ID_Egreso = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Egreso)
                .ForeignKey("dbo.operaciondeingreso", t => t.ID_Ingreso, cascadeDelete: true)
                .ForeignKey("dbo.mediodepago", t => t.ID_MedioDePago, cascadeDelete: true)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.ID_Ingreso)
                .Index(t => t.ID_Organizacion)
                .Index(t => t.ID_MedioDePago);
            
            CreateTable(
                "dbo.operaciondeingreso",
                c => new
                    {
                        ID_Ingreso = c.Int(nullable: false, identity: true),
                        ID_Organizacion = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                        Monto = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Ingreso)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion, cascadeDelete: true)
                .Index(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.mediodepago",
                c => new
                    {
                        ID_MedioDePago = c.Int(nullable: false, identity: true),
                        ID_Pais = c.String(unicode: false),
                        Numero = c.String(unicode: false),
                        TipoPago = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_MedioDePago);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        ID_Item = c.Int(nullable: false, identity: true),
                        ID_Compra = c.Int(nullable: false),
                        ID_Presupuesto = c.Int(nullable: false),
                        Nombre = c.String(unicode: false),
                        ValorTotal = c.Single(nullable: false),
                        Descripcion = c.String(unicode: false),
                        Compra_ID_Egreso = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Item)
                .ForeignKey("dbo.compra", t => t.Compra_ID_Egreso)
                .ForeignKey("dbo.presupuesto", t => t.ID_Presupuesto, cascadeDelete: true)
                .Index(t => t.ID_Presupuesto)
                .Index(t => t.Compra_ID_Egreso);
            
            CreateTable(
                "dbo.presupuesto",
                c => new
                    {
                        ID_Presupuesto = c.Int(nullable: false, identity: true),
                        Detalle = c.String(unicode: false),
                        ID_Compra = c.Int(nullable: false),
                        ValorTotal = c.Single(nullable: false),
                        Compra_ID_Egreso = c.Int(),
                        Proveedor_ID_Proveedor = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Presupuesto)
                .ForeignKey("dbo.compra", t => t.Compra_ID_Egreso)
                .Index(t => t.Compra_ID_Egreso);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        ID_Usuario = c.Int(nullable: false, identity: true),
                        Contraseña = c.String(unicode: false),
                        NombreUsuario = c.String(unicode: false),
                        TipoUsuario = c.String(unicode: false),
                        ID_Organizacion = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Usuario)
                .ForeignKey("dbo.organizacion", t => t.ID_Organizacion)
                .Index(t => t.ID_Organizacion);
            
            CreateTable(
                "dbo.moneda",
                c => new
                    {
                        ID_Moneda = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descripcion = c.String(unicode: false),
                        Simbolo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Moneda);
            
            CreateTable(
                "dbo.pais",
                c => new
                    {
                        ID_Pais = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Moneda = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Pais)
                .ForeignKey("dbo.moneda", t => t.ID_Moneda)
                .Index(t => t.ID_Moneda);
            
            CreateTable(
                "dbo.provincia",
                c => new
                    {
                        ID_Provincia = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(unicode: false),
                        ID_Pais = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID_Provincia)
                .ForeignKey("dbo.pais", t => t.ID_Pais)
                .Index(t => t.ID_Pais);
            
            CreateTable(
                "dbo.usuariosxcompra",
                c => new
                    {
                        ID_Compra = c.Int(nullable: false),
                        ID_Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID_Compra, t.ID_Usuario })
                .ForeignKey("dbo.compra", t => t.ID_Compra, cascadeDelete: true)
                .ForeignKey("dbo.usuario", t => t.ID_Usuario, cascadeDelete: true)
                .Index(t => t.ID_Compra)
                .Index(t => t.ID_Usuario);
            
            CreateTable(
                "dbo.entidadjuridicaproveedora",
                c => new
                    {
                        ID_Proveedor = c.Int(nullable: false, identity: true),
                        CodigoInscripcion = c.String(unicode: false),
                        CUIT = c.String(unicode: false),
                        RazonSocial = c.String(unicode: false),
                        ID_Compra = c.Int(nullable: false),
                        ID_Direccion = c.Int(nullable: false),
                        ID_Presupuesto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Proveedor)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion, cascadeDelete: true)
                .Index(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.personaproveedora",
                c => new
                    {
                        ID_Proveedor = c.Int(nullable: false, identity: true),
                        DNI = c.String(unicode: false),
                        Nombre = c.String(unicode: false),
                        ID_Compra = c.Int(nullable: false),
                        ID_Direccion = c.Int(nullable: false),
                        ID_Presupuesto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Proveedor)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion, cascadeDelete: true)
                .Index(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.compra",
                c => new
                    {
                        ID_Egreso = c.Int(nullable: false, identity: true),
                        Proveedor_ID_Proveedor = c.Int(),
                        CantidadDePresupuestosRequeridos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Egreso);
            
            CreateTable(
                "dbo.entidadbase",
                c => new
                    {
                        ID_Entidad = c.Int(nullable: false),
                        JuridicaAsociada_ID_Entidad = c.Int(),
                        ID_Direccion = c.Int(),
                        ID_Organizacion = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                        ID_EntidadJuridica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Entidad)
                .ForeignKey("dbo.entidadjuridica", t => t.JuridicaAsociada_ID_Entidad)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion)
                .Index(t => t.JuridicaAsociada_ID_Entidad)
                .Index(t => t.ID_Direccion);
            
            CreateTable(
                "dbo.entidadjuridica",
                c => new
                    {
                        ID_Entidad = c.Int(nullable: false),
                        ID_Direccion = c.Int(),
                        ID_Organizacion = c.Int(nullable: false),
                        CodigoInscripcion = c.String(unicode: false),
                        CUIT = c.String(unicode: false),
                        RazonSocial = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID_Entidad)
                .ForeignKey("dbo.direccion", t => t.ID_Direccion)
                .Index(t => t.ID_Direccion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.entidadjuridica", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.entidadbase", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.entidadbase", "JuridicaAsociada_ID_Entidad", "dbo.entidadjuridica");
            DropForeignKey("dbo.personaproveedora", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.entidadjuridicaproveedora", "ID_Direccion", "dbo.direccion");
            DropForeignKey("dbo.provincia", "ID_Pais", "dbo.pais");
            DropForeignKey("dbo.ciudad", "ID_Provincia", "dbo.provincia");
            DropForeignKey("dbo.pais", "ID_Moneda", "dbo.moneda");
            DropForeignKey("dbo.usuariosxcompra", "ID_Usuario", "dbo.usuario");
            DropForeignKey("dbo.usuariosxcompra", "ID_Compra", "dbo.compra");
            DropForeignKey("dbo.usuario", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.operaciondeingreso", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.operaciondeegreso", "ID_Organizacion", "dbo.organizacion");
            DropForeignKey("dbo.item", "ID_Presupuesto", "dbo.presupuesto");
            DropForeignKey("dbo.documentocomercial", "ID_Presupuesto", "dbo.presupuesto");
            DropForeignKey("dbo.presupuesto", "Compra_ID_Egreso", "dbo.compra");
            DropForeignKey("dbo.item", "Compra_ID_Egreso", "dbo.compra");
            DropForeignKey("dbo.operaciondeegreso", "ID_MedioDePago", "dbo.mediodepago");
            DropForeignKey("dbo.operaciondeegreso", "ID_Ingreso", "dbo.operaciondeingreso");
            DropForeignKey("dbo.documentocomercial", "ID_Egreso", "dbo.operaciondeegreso");
            DropIndex("dbo.entidadjuridica", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadbase", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadbase", new[] { "JuridicaAsociada_ID_Entidad" });
            DropIndex("dbo.personaproveedora", new[] { "ID_Direccion" });
            DropIndex("dbo.entidadjuridicaproveedora", new[] { "ID_Direccion" });
            DropIndex("dbo.usuariosxcompra", new[] { "ID_Usuario" });
            DropIndex("dbo.usuariosxcompra", new[] { "ID_Compra" });
            DropIndex("dbo.provincia", new[] { "ID_Pais" });
            DropIndex("dbo.pais", new[] { "ID_Moneda" });
            DropIndex("dbo.usuario", new[] { "ID_Organizacion" });
            DropIndex("dbo.presupuesto", new[] { "Compra_ID_Egreso" });
            DropIndex("dbo.item", new[] { "Compra_ID_Egreso" });
            DropIndex("dbo.item", new[] { "ID_Presupuesto" });
            DropIndex("dbo.operaciondeingreso", new[] { "ID_Organizacion" });
            DropIndex("dbo.operaciondeegreso", new[] { "ID_MedioDePago" });
            DropIndex("dbo.operaciondeegreso", new[] { "ID_Organizacion" });
            DropIndex("dbo.operaciondeegreso", new[] { "ID_Ingreso" });
            DropIndex("dbo.documentocomercial", new[] { "ID_Presupuesto" });
            DropIndex("dbo.documentocomercial", new[] { "ID_Egreso" });
            DropIndex("dbo.ciudad", new[] { "ID_Provincia" });
            DropTable("dbo.entidadjuridica");
            DropTable("dbo.entidadbase");
            DropTable("dbo.compra");
            DropTable("dbo.personaproveedora");
            DropTable("dbo.entidadjuridicaproveedora");
            DropTable("dbo.usuariosxcompra");
            DropTable("dbo.provincia");
            DropTable("dbo.pais");
            DropTable("dbo.moneda");
            DropTable("dbo.usuario");
            DropTable("dbo.presupuesto");
            DropTable("dbo.item");
            DropTable("dbo.mediodepago");
            DropTable("dbo.operaciondeingreso");
            DropTable("dbo.operaciondeegreso");
            DropTable("dbo.organizacion");
            DropTable("dbo.documentocomercial");
            DropTable("dbo.direccion");
            DropTable("dbo.ciudad");
        }
    }
}
