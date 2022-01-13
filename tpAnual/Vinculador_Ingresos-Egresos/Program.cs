using System;
using System.Collections.Generic;
using TPANUAL;

class Program
{
    static void Main(string[] args)
    {
            // Creo condiciones
            List<Condicion> condiciones = new List<Condicion>() { new PeriodoDeAceptabilidad(20) };

            // Creo el vinculador con sus parametros
            Vinculador vinculador = new Vinculador(condiciones);

            CriterioVinculador criterio = new Orden_Valor_PrimeroEgreso();
            criterio.Vinculador = vinculador;

            vinculador.cambiarCriterio( criterio );

            vinculador.vincular(1);        
    }
}

