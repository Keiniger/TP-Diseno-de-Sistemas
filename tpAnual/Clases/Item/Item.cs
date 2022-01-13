
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("item")]
	public class Item {
        [Key]
        [Column("ID_Item")]
        public int ID_Item { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("ValorTotal")]
        public float ValorTotal { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        public List<Categoria> Categorias { get; set; }

        public Item(string nombre, string descripcion, float valorTotal, List<Categoria> categorias)
        {
            Descripcion = descripcion;
            ValorTotal = valorTotal;
            Nombre = nombre;
            Categorias = categorias;
        }

        public Item() { }

        public void insertarCategoria(Categoria categoria)
        {
            bool estaEnLaLista = false;
            foreach (Categoria unaCategoria in Categorias)
            {
                if (Equals(unaCategoria.Criterio,categoria.Criterio))
                {
                    estaEnLaLista = true;
                }
            }

            if (!estaEnLaLista) { Categorias.Add(categoria); }
        }

    }//end Producto

}//end namespace TPANUAL