using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    //c:\emusk begin c:\users\deleo\desktop\hola\ejemploffss
    class Lrad
    {
        int version { get; set; }
        DateTime fechahora { get; set; }
        string comentario { get; set; }
        String infoArchivo { get; set; }

        public override string ToString()
        {
            return $" {version} \t   {fechahora.ToString("MM/dd/yyyy HH:mm")}   \t {comentario}";
        }
    }
}
