using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Producto
    {
        #region Atributos
        public  string nombre;
        public  string categoria;
        public  string marca;
        public double precio;
        public int stock;
        #endregion

        #region Contructores
        public Producto()
        { }
        public Producto(string nombre, string categoria, string marca, double precio, int stock)
        {
            this.nombre = nombre;
            this.categoria = categoria;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
        }
        #endregion

        #region Metodos
         public void Agregar () 
         {
            
         }

        public void Eliminar()
        {

        }

        public void Buscar()
        {

        }

        #endregion
    }
}
