using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Version<T>
    {
        public Version<T> siguiente { set; get; }
        public T data { set; get; }

        public string versionComentario { set; get; }
        public int numeroNodo { set; get; }
        public DateTime fechaHora { set; get; }
       // public string 
       //
        public Version(T pData, string pVersionComentario,DateTime pfecha, int pNumeroNodo)
        {
            siguiente = null;
            data = pData;
            versionComentario = pVersionComentario;
            numeroNodo = pNumeroNodo;
            fechaHora = pfecha;
        }
 
        public static implicit operator Version(Version<T> v)
        {
            throw new NotImplementedException();
        }
    }
}
/*
  static string GetFileText(string name)
        {
            string fileContents = String.Empty;
            // If the file has been deleted since we took
            // the snapshot, ignore it and return the empty string.  
            if (System.IO.File.Exists(name))
            {
                fileContents = System.IO.File.ReadAllText(name);
            }
            return fileContents;
        }
        //recorrer inverso
        public void rec() {
            if(this.listaString!=null)
            listaString.RecorrerInverso(this.listaString);
        }
        public static void FileSs() 
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Program.ubicacion);
            fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
        }

        static IEnumerable<System.IO.FileInfo> fileList;
 */
