using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoPruebas.SingletonPruebas
{
    public class RepositorioPruebaEditar
    {
        public static RepositorioPruebaEditar Instancia { get; } = new RepositorioPruebaEditar();

        public List<PruebasLab> Pruebas = new List<PruebasLab>();

        private RepositorioPruebaEditar()
        {

        }
    }
}
