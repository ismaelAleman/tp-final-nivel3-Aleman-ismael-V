using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {


        public Articulo() { }


        public int Id { get; set; }
        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String UrlImagen { get; set; }
        public Double Precio { get; set; }
        public Marca IdMarca { get; set; }
        public Categoria IdCategoria { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Código: {Codigo}, Nombre: {Nombre}, Descripción: {Descripcion}, Precio: {Precio}, Marca: {IdMarca}, Categoría: {IdCategoria}, URL Imagen: {UrlImagen}";
        }


    }
}
