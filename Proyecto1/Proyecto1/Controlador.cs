using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
namespace Proyecto1
{
    class Controlador
    {
        private string fileName;
        private string path;
        public static string infofile = "";
        private static int numeroNodo = 0;
        public ListaVersiones<String> listaString { set; get; }

        public Controlador()
        {
            listaString = new ListaVersiones<string>();
        }

        //recorrer inverso
        public void rec() {
            if (this.listaString != null)
                listaString.RecorrerInverso(this.listaString);
        }

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
        }//GetFileText
        public static void FileSs()
        {
            //almacena toda la informacion de los archivos que se estan siguiendo
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Program.ubicacion);
            fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            /*esto es solo para ver la ruta almacenada en filelist*/
            var queryMatchingFiles =
               from file in fileList
               let fileText = GetFileText(file.FullName)
               select file.FullName;//FullName: indica que se está tomando la ruta de los archivos 
            foreach (string filenames in queryMatchingFiles)
            {
                Console.WriteLine("archivos en la ruta= "+filenames);            }
        }
        static IEnumerable<System.IO.FileInfo> fileList;


        public string Save(string comentario)
        {

            if (0 == Directory.GetFiles(Program.ubicacion).Length)
            {
                Console.WriteLine("no tiene archivos");
            }
            else
            {
                FileSs();
                DateTime fecha = DateTime.Now;
                String textInTheFile = "";// File.ReadAllText(Program.ubicacion);
                ListaVersiones<string> versiones = new ListaVersiones<string>();

                //El nodo ha sido agregado
                if (!textInTheFile.Equals(lastS()))
                {
                    infofile = textInTheFile;
                    numeroNodo = numeroNodo + 1;
                    Program.lastVnodo = numeroNodo;
                    listaString.Agregar(" " , comentario, fecha, numeroNodo);
                    Console.WriteLine("\nNode Added ");
                    //Creemos el archivo txt
                    listaString.Actualizar(listaString);
                    //versiones.Recorrer(versiones);
                    //this.listaString = versiones;

                    return listaString.primero.data;
                }
                else
                    Console.WriteLine("no hubieron cambios en el archivo");
            }
            return "";
        }



        public void Delete(int datobuscar)
        {
            this.listaString = this.listaString.Eliminar(this.listaString, datobuscar);
            this.listaString.Actualizar(this.listaString);
        }

        public int lasN() {
            if(listaString!=null)
            if (listaString.ultimo != null)
            {
                return listaString.ultimo.numeroNodo;
            } else { 
                return 0; 
            }
            return 0;
        }

        public string lastS()
        {
            if (listaString != null)
                if (listaString.ultimo != null)
                {
                    return listaString.ultimo.data;
                }
                else
                {
                    return null;
                }
            return null;
        }
        public int watch(int numBuscar)
        {
            //devuelve el numero de version del ultimo nodo
            int nodoB = this.listaString.Buscar(this.listaString, numBuscar);
            return nodoB;
            // Console.WriteLine("\n" + nodo);
        }
        public bool ifSave(int last)
        {
            return listaString.ifsave(this.listaString, last);
        }//ifsave()

        public void allDel()
        { 
            this.listaString=this.listaString.EliminarTodo(this.listaString);
        }

    }
}
