using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Usuario
    {
        #region Atributos
        public string nombre;
        public  string direccion;
        //public List<Carrito>;
        #endregion

        #region Constructores
        public Usuario()
        { }

        public Usuario(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
        }
        #endregion

        #region Metodos

        #endregion

    }
}
