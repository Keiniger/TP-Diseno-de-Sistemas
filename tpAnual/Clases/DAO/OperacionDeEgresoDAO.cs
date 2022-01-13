using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TPANUAL.Clases.DAO
{
    public class OperacionDeEgresoDAO
    {
        private OperacionDeEgresoDAO() { }

        public static List<OperacionDeEgreso> obtenerEgresos(Usuario _usuario)
        {
            using (var contexto = new DB_Context())
            {
                var operacionesDeEgreso = contexto.operacionDeEgreso
                    .Where(oe => oe.ID_Organizacion == _usuario.ID_organizacion)
                    .Include(oe => oe.MedioDePago)
                    .Include(oe => oe.DocumentosComerciales)
                    .Include(oe => oe.IngresoAsociado)
                    .Include(oe => oe.Compra.Items
                        .Select(i => i.Categorias
                            .Select(c => c.Criterio)
                            )
                        )
                    .Include(oe => oe.Compra.Presupuestos
                        .Select(p => p.Items
                            .Select(i => i.Categorias
                                .Select(c => c.Criterio)
                                )
                            )
                        )
                    .Include(oe => oe.Compra.Presupuestos
                        .Select(p => p.Persona))
                    .Include(oe => oe.Compra.Presupuestos
                        .Select(p => p.Entidad))
                    .Include(oe => oe.Compra.Revisores)
                    .Include(oe => oe.Compra.Bandeja)
                    .Include(oe => oe.Compra.Persona)
                    .Include(oe => oe.Compra.Entidad)
                    .ToList();

                return operacionesDeEgreso;
            }
        }

        public static OperacionDeEgreso obtenerEgreso(int _ID)
        {
            using (var contexto = new DB_Context()) 
            {
                return contexto.operacionDeEgreso
                    .Where(oe => oe.ID_OperacionDeEgreso == _ID)
                    .Include(oe => oe.Compra.Revisores)
                    .FirstOrDefault();
            }
        }

        public static void guardar(OperacionDeEgreso _oe)
        {
            var contexto = new DB_Context();

            // Guardo revisores y los saco de la compra para 
            // agregarlos después
            var revisores = _oe.Compra.Revisores;
            _oe.Compra.Revisores = null;

            PersonaProveedora pp = _oe.Compra.Persona;
            EntidadJuridicaProveedora ejp = _oe.Compra.Entidad;

            _oe.Compra.Persona = null;
            _oe.Compra.Entidad = null;

            contexto.operacionDeEgreso.Add(_oe);
            contexto.SaveChanges();

            // Agrego revisores aparte(problemas del entity framework)
            foreach (Usuario u in revisores)
                OperacionDeEgresoDAO.agregarRevisorCompra(_oe.Compra.ID_Compra, u.ID_Usuario);

            // Agrego los proveedores aparte(problemas del entity framework)
            if (pp != null)
                OperacionDeEgresoDAO.agregarPersonaProveedoraCompra(_oe.Compra.ID_Compra, pp.ID_Proveedor);
            if (ejp != null)
                OperacionDeEgresoDAO.agregarEntidadJuridicaProvedoraCompra(_oe.Compra.ID_Compra, ejp.ID_Proveedor);

            Logger.getInstance.update("Se agregó una operacion de egreso a la base de datos" + _oe.ID_OperacionDeEgreso.ToString());
            //Junto con la operacion de egreso, se agregan todas las entidades asociadas a la misma
        }

        public static void agregarRevisorCompra(int _ID_Compra, int _ID_Usuario) 
        {
            using (var contexto = new DB_Context())
            {
                Compra c = contexto.compra.Find(_ID_Compra);
                Usuario u = contexto.usuario.Find(_ID_Usuario);

                c.agregarRevisor(u);

                contexto.SaveChanges();
                Logger.getInstance.update("Se modifica una compra agregando un revisor." + " ID Compra:" +_ID_Compra.ToString());
            }
        }

        
        public static void sacarRevisorCompra(int _ID_Compra, int _ID_Usuario)
        {
            using (var contexto = new DB_Context())
            {
                Compra c = contexto.compra.Find(_ID_Compra);
                Usuario u = contexto.usuario.Find(_ID_Usuario);

                c.sacarRevisor(u);

                contexto.Database.ExecuteSqlCommand(
                        "delete from usuariosxcompra where ID_Compra = {0} and ID_Usuario = {1};",
                        _ID_Compra,
                        _ID_Usuario
                        );

                contexto.SaveChanges();

                Logger.getInstance.update("Se modifica una compra quitando un revisor." + " ID Compra:" + _ID_Compra.ToString());
            }
        }

        public static void agregarPersonaProveedoraCompra(int _ID_Compra, int _ID_Proveedor)
        {
            using (var contexto = new DB_Context())
            {
                contexto.Database.ExecuteSqlCommand(
                        "update compra set Persona_ID_Proveedor = {0} where ID_Compra = {1};",
                        _ID_Proveedor,
                        _ID_Compra
                        );

                contexto.SaveChanges();
            }
        }

        public static void agregarEntidadJuridicaProvedoraCompra(int _ID_Compra, int _ID_Proveedor) 
        {
            using (var contexto = new DB_Context())
            {
                contexto.Database.ExecuteSqlCommand(
                        "update compra set Entidad_ID_Proveedor = {0} where ID_Compra = {1};",
                        _ID_Proveedor,
                        _ID_Compra
                        );

                contexto.SaveChanges();
            }
        }
    }
}
