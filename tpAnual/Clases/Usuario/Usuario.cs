using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;

namespace TPANUAL {

    [Table("usuario")]
	public class Usuario {

        [Key]
        [Column("ID_Usuario")]
        public int ID_Usuario { get; set; }

        [Column("Contrase�a")]
        public string Contrase�a { get; set; }

        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; }

        [Column("TipoUsuario")]
        public string TipoUsuario { get; set; }

        [Column("ID_Organizacion")]
        public int? ID_organizacion { get; set; }
        public Organizacion organizacionAsociada { get; set; }

        public List<Compra> ComprasRevisables{ get; set; }

        public Usuario(string contrase�a, string nombreUsuario)
        {
            Contrase�a = contrase�a;
            NombreUsuario = nombreUsuario;
            TipoUsuario = "estandar";
        }

        public Usuario() { }

        public void agregarCompra(Compra _compra)
        {
            if (ComprasRevisables == null) ComprasRevisables = new List<Compra> { };
            ComprasRevisables.Add(_compra);
        }

        public void sacarCompra(Compra _compra)
        {
            if(ComprasRevisables != null) ComprasRevisables.Remove(_compra);
        }

        public void verMensajes(Compra compra)
        {
            compra.mostrarMensajes(this);
        }

        public void cambiarTipoUsuario()
        {
            if(TipoUsuario == "estandar")
            {
                TipoUsuario = "administrador";
            }
            else{
                TipoUsuario = "estandar";
            }
        }

        public bool validarContrase�a()
        {
            return ValidadorDeContrase�a.getInstanceValidadorContra().validarContrase�a(this.Contrase�a);
        }

	}//end Usuario

}//end namespace TPANUAL