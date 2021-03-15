using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class List
    {
        List<Propietarios> propietarios = new List<Propietarios>();
        List<Propiedades> propiedades = new List<Propiedades>();

        internal List<Propietarios> Propietarios { get => propietarios; set => propietarios = value; }
        internal List<Propiedades> Propiedades { get => propiedades; set => propiedades = value; }
    }
}
