using System;
using System.Threading.Tasks;
using System.IO;
namespace Proyecto1
{
    class ListaVersiones<T>
    {
        public Version<T> primero { set; get; }
        public Version<T> actual { set; get; }
        public Version<T> temporal { set; get; }
        public Version<T> ultimo { set; get; }


        public ListaVersiones()
        {
            primero = null;
            //public ListaVersiones<T> listaClase = new ListaVersiones<T>();
        }


        public bool ifsave(ListaVersiones<T> lista, int last) 
        {
            if (lista.ultimo!=null) 
            {

                if (lista.ultimo.numeroNodo ==last) {
                    return true;
                }
            }else

            {
                return true;
            }
            
            return false;
        }

        public ListaVersiones<T> EliminarTodo(ListaVersiones<T> lista)
        {
            if(lista.ultimo != null) {
                lista = null;
            }
            return lista;
        }


        public void Agregar(T pData, string pComentario, DateTime fecha, int pNumeroNodo)
        {
            //Si no hay ningún dato, cerremos el método
            if (pData == null) { }
            //return;
            else
            {
                if (primero == null)
                {
                    primero = new Version<T>(pData, pComentario, fecha, pNumeroNodo);
                    primero.siguiente = null;
                    ultimo = primero;

                }
                else
                {

                    actual = ultimo;
                    if (actual.siguiente == null)
                    {
                        actual.siguiente = new Version<T>(pData, pComentario, fecha, pNumeroNodo);
                        temporal = actual.siguiente;
                        temporal.siguiente = null;
                        ultimo = temporal;
                        actual = ultimo;
                    }
                }
            }
        }


        public void Actualizar(ListaVersiones<T> lista)
        {
            if (lista.primero != null)
            {
                int i = 0;
                lista.actual = lista.primero;
                do
                {
                    i++;
                   // Console.WriteLine(lista.actual.numeroNodo + ".\t " + lista.actual.fechaHora.ToString("MM/dd/yyyy HH:mm") + "\t " + lista.actual.versionComentario);
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);
            }


        }//fin del método



        public ListaVersiones<T> Eliminar(ListaVersiones<T> lista, int pNumeroNodo)
        {
            bool del = false;
            ListaVersiones<T> listaNueva = new ListaVersiones<T>();
            if (lista.primero != null)
            {
                // int i = 1;
                lista.actual = lista.primero;

                if (lista.actual.siguiente != null)
                {
                    while (lista.actual.siguiente != null)
                    {
                        if (lista.actual.numeroNodo.Equals(pNumeroNodo))
                        {
                            Program.lastVnodo = lista.ultimo.numeroNodo;
                            del = true;
                            lista.actual = lista.actual.siguiente;
                            Console.WriteLine("The node has been deleted!");
                            if (lista.actual.siguiente == null)
                            {
                                listaNueva.Agregar(lista.actual.data, lista.actual.versionComentario, lista.actual.fechaHora, lista.actual.numeroNodo);
                                return listaNueva;
                            }
                        }
                        if (lista.actual != null)
                        {
                            listaNueva.Agregar(lista.actual.data, lista.actual.versionComentario, lista.actual.fechaHora, lista.actual.numeroNodo);
                            lista.actual = lista.actual.siguiente;
                        }

                    }
                }
                if (lista.actual.siguiente == null && lista.actual != null)
                    listaNueva.Agregar(lista.actual.data, lista.actual.versionComentario, lista.actual.fechaHora, lista.actual.numeroNodo);
                lista = listaNueva;
            }
            if (!del)
                Console.WriteLine("nodo inexistente");
            return listaNueva;
        }



        public void RecorrerInverso(ListaVersiones<T> lista)
        {
            if (lista.primero != null)
            {
                //Recoree para contar cuántos elementos hay
                int i = 0;
                lista.actual = lista.primero;
                do
                {
                    i++;
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);
                //Hacemos un array con los datos de la lista y el tamaño establecido y guardamos en ese array los datos de la lista
                string[] coment = new string[i];
                DateTime[] fecha = new DateTime[i];
                int[] num = new int[i];
                i = 0;
                lista.actual = lista.primero;
                do
                {
                    coment[i] = lista.actual.versionComentario;
                    fecha[i] = lista.actual.fechaHora;
                    num[i] = lista.actual.numeroNodo;
                    i++;
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);
                //Imprimimos lo que obtuvimos de mayor a menor
                while (i > 0)
                {
                    i--;
                    Console.WriteLine(num[i] + "\t     " + fecha[i].ToString("MM/dd/yyyy HH:mm") + "      " + coment[i]);
                }

            }

        }//fin del método


        public int Buscar(ListaVersiones<string> lista, int nNodo)
        {
            Program p = new Program();
            bool cr = false;
            
            int nodoB = 0;
            string datoBuscado = null;
            if (lista.primero != null)
            {
                 nodoB=lista.ultimo.numeroNodo;
                lista.actual = lista.primero;
                do
                {

                    if (lista.actual.numeroNodo == nNodo)
                    {
                        Program.lastVnodo = nNodo;
                        datoBuscado = lista.actual.data;
                        try
                        {
                            writeFile(datoBuscado);
                            Console.WriteLine("se ha modificado correctamente");
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        cr = true; 
                    }
                    lista.actual = lista.actual.siguiente;
                }
                while (lista.actual != null);
            }
            if (!cr) Console.WriteLine("nodo inexistente");
            return nodoB;
        }//fin del método

        public static async Task writeFile(string text)
        {
            Program p = new Program();
            await File.WriteAllTextAsync(p.u, text);
        }
    }
}
 