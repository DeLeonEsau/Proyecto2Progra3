 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Proyecto1
{
    class Program
    {
        String  name = "emusk";
        public static String ubicacion;
        public string u=ubicacion;
        public static int lastVnodo;

        // public string cumpleAlvaro = "16 de junio";
        // public string cumpleAdriana ="4 de abril";
        // public string cumpleEsau  = "29 de marzo"; 
        /*holiiii*/

        static void Main(string[] args)
        {
            bool op = false;
            int ifSave = 0, numBus = 0;
            Controlador con = new Controlador();    
            Program p = new Program();
            string dir = @"c:\" + p.name + "begin ", comando;
            int nocommand;
            string[] allfiles = new string[10];
            do
            {
                Console.WriteLine("ingrese comando inicial:");
                comando = Console.ReadLine();
                if (comando != "exit")
                    if ((comando.Length > dir.Length))
                    {
                        op = directorio(comando);
                        if (op)
                        {
                            Console.WriteLine("ubicacion a dar seguimiento: " + ubicacion);
                        }
                    }
                    else 
                    { 
                        Console.WriteLine("valor inválido"); }
            } while (comando != "exit" && !op) ;
                do
                {
                    comando = Console.ReadLine();
                    string comando2 = comando;
                    nocommand = opcion(comando);
                    comando = comando.Replace(" ", "");
                    switch (nocommand)
                    {
                        case 1://save
                               //verifico que se encuentre en el ultimo nodo
                            int numL = con.lasN();
                            if (numL == lastVnodo)
                            {
                                con.Save(comentario(comando2));
                                ifSave = lastVnodo;
                            }
                            else
                            {
                                Console.WriteLine("solo puede guardar cuando se encuentre en el ultimo nodo");
                            }
                            break;
                        case 2://compass
                            Console.WriteLine("Version\t     fecha y hora\t   comentario");
                            Console.WriteLine("------------------------------------------------------------");
                            con.rec();
                            break;
                        case 3://watch

                            comando = comando.Remove(0, (p.name.Length + 5));
                            numBus = Int32.Parse(comando);
                            ifSave = con.watch(numBus);
                            break;
                        case 4://delete
                            comando = comando.Remove(0, (p.name.Length + 6));
                            int numDel = Int32.Parse(comando);
                            con.Delete(numDel);
                            break;
                      /*  case 5://cambiar de directorio
                            lastVnodo = 0;
                            Controlador.infofile = "";
                            Console.WriteLine("nueva ubicacion de archivo:" + ubicacion);
                          //  con.allDel();
                        break;*/
                        default:
                            //Console.WriteLine("comando no valido");
                        break;
                }//switch
            } while (comando != "exit");    
        }//main
       
        static int opcion(String pr)
        {
            string pt = pr;
            String comando;
            Program p = new Program();
            bool v=true;
            string dir = @"c:\ " + p.name + " begin";
            if (pr.Length> p.name.Length) 
            {
                if (!(pr.Substring(0, p.name.Length).Equals(p.name))) {
                    Console.WriteLine("valor incorrecto");
                    return 0;
                }
                pr = pr.Replace(" ","");
                if (p.name.Equals(pr.Substring(0, p.name.Length)))
                {
                    comando = pr.Remove(0, p.name.Length);
                    //save
                    if (comando.Length>=4)  { 

                        if (comando.Substring(0, 4)==("save"))
                        { 
                            comando = comando.Remove(0, 4);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar comentario");                  
                            }
                            else
                            {
                                return 1;
                            }
                        }//save
                        if(comando.Length>=5)
                         if (comando.Substring(0, 5)==("watch"))
                        {
                            comando = comando.Remove(0, 5);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar la version");
                            }
                            else
                            {
                                for (int i = 0; i < comando.Length; i++)
                                {
                                    if (!(comando.Substring(i, i + 1) == "1" || comando.Substring(i, i + 1) == "2" || comando.Substring(i, i + 1) == "3" || comando.Substring(i, i + 1) == "4" || comando.Substring(i, i + 1) == "5" || comando.Substring(i, i + 1) == "6" || comando.Substring(i, i + 1) == "7" || comando.Substring(i, i + 1) == "8" || comando.Substring(i, i + 1) == "9" || comando.Substring(i, i + 1) == "0"))
                                        v = false;
                                }
                                if (v)
                                {
                                    return 3;
                                }
                                else
                                {
                                    Console.WriteLine("la version que desea ver debe tener un valor numerico numericos");
                                }
                            }
                        }//watch
                        if(comando.Length>=6)
                        if (comando.Substring(0, 6)==("delete"))
                        {
                            comando = comando.Remove(0, 6);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar la version");
                            }
                            else
                            {
                                for (int i = 0; i < comando.Length; i++)
                                {
                                        string d;//= comando.Substring(0, 1);
                                        d = comando.Remove(0, 1);
                                        if (!(comando.Substring(i, i + 1) == "1" || comando.Substring(i, i + 1) == "2" || comando.Substring(i, i + 1) == "3" || comando.Substring(i, i + 1) == "4" || comando.Substring(i, i + 1) == "5" || comando.Substring(i, i + 1) == "6" || comando.Substring(i, i + 1) == "7" || comando.Substring(i, i + 1) == "8" || comando.Substring(i, i + 1) == "9" || comando.Substring(i, i + 1) == "0"))
                                        v = false;
                                }
                                if (v)
                                {
                                    return 4;
                                }
                                else
                                {
                                    Console.WriteLine("la version que desea eliminar debe llevar solo valores numericos");
                                }
                            }

                        }//delete
                        if(comando.Length>=7)
                        if (comando.Substring(0, 7)==("compass"))
                        {
                            comando = comando.Remove(0, 7);
                            if (comando.Equals(""))
                            {
                                return 2;
                            }
                            else
                            {
                                Console.WriteLine("comando incorrecto");
                            }
                        }//compass
                    }
                    else { Console.WriteLine("comando invalido"); }
                }
                else
                {
                    bool op=false;
                    if (pr.Length > dir.Length)
                        op = directorio(pt);
                    if (op) {
                        return 5;
                    } 
                }
            }
            else
            {
                Console.WriteLine("comando incorrecto");
            }
            return 0;
        }//opcion()

        public static void creaCarpeta(string ruta) 
        {
            Directory.CreateDirectory(ruta);
            Console.WriteLine("la carpeta fue creada, pero se encuentra vacia");
            CrearArchivo(ruta);
        }//crearCarpeta

        public static void CrearArchivo(string ruta)
        {
            TextWriter archivo;
            Console.WriteLine("ingrese el nombre del archivo");
            string file = Console.ReadLine();
            archivo = new StreamWriter(ruta + @"\" + file + @".txt");
            /*listaDeArchivos.recorrer(archivo);*/
            archivo.Close();
            //Console.Clear();
            Console.WriteLine("se ha guardado el archivo");
            //Program.ubicacion = ruta + @"\" + file + @".txt";
        }//crear

        public static bool separate(string dir)
        {
            bool pase1=false;
            string init = "begin";
            Program p = new Program();
            string d = @"c:\" + p.name;
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                { 
                    dir = dir.Remove(0, 1);
                }
                else   
                {
                    pase1 = true; 
                    break; 
                }
            } while (!pase1);
            if (dir.Length > d.Length)
            {
                if (d.Equals(dir.Substring(0, d.Length)))
                {
                    dir = dir.Remove(0, d.Length);
                }
                else
                {
                    return false;
                }
            }
            else { return false; }
            pase1 = false;
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                {
                    dir = dir.Remove(0, 1);
                }
                else
                {
                    pase1 = true;
                    break;
                }
            } while (!pase1);
            if (dir.Length > init.Length)
            {
                if (init == dir.Substring(0, init.Length))
                {
                    dir = dir.Remove(0, init.Length);
                }
                else
                {
                    return false;
                }
            }
            else { return false; }
            //ruta 
            pase1 = false;
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                {
                    dir = dir.Remove(0, 1);
                }
                else
                {
                    pase1 = true;
                    break;
                }
            } while (!pase1);
            //Console.WriteLine(dir);
                Program.ubicacion = dir;
                return true;
        }


        public static bool directorio(string comando)
        {
            string[] allfiles = new string[10];
            bool op = false;
            Program p = new Program();
            string dir = @"c:\" + p.name + " begin ", ruta, opc="";
            //ve que esten correctamente separadas las palabras del init
            bool verif = separate(comando);
            ruta = comando.Remove(0, dir.Length);
            ///si estan correcto el comando init
            if (verif)
            {
                //verificar que existe la ubicacion 
                if (Directory.Exists(ubicacion))
                {
                    //obtiene la cantidad de archivos en la ruta
                    int total = Directory.GetFiles(ubicacion, "*.*", SearchOption.AllDirectories).Length;
                    //si existen archivos en la ruta
                    if (total != 0)
                    {
                        op = true;
                    }
                    else
                    {
                        Console.WriteLine("no existen arhcivos en la ruta");
                       // op = false;
/**/
                        do
                        {
                            Console.WriteLine("desea crear un archivo\n1=si\n2=no");
                            opc = Console.ReadLine();
                            switch (opc)
                            {
                                case "1":
                                    CrearArchivo(ruta);
                                    op = true;
                                    break;
                                case "2":
                                    op = true;
                                    break;
                                default:
                                    Console.WriteLine(" valor no valido");
                                    break;
                            }//switch
                        } while (opc != "2" && opc != "1");
/**/
                    }
                }
                else
                {
                    op = false;
                    Console.WriteLine("ruta no encontrada");
 /**/         
                    //string opc;
                    do
                    {
                        Console.WriteLine("no se encontró la direccion, desea crearla?\n1=si\n2=no");
                        opc = Console.ReadLine();
                        switch (opc)
                        {
                            case "1":
                                creaCarpeta(ruta);
                                op = true;
                                break;
                            case "2":
                                break;
                            default:
                                Console.WriteLine(" valor no valido");
                                break;
                        }
                    } while (opc != "2" && opc != "1");
/**/
                }
            }
            else
            {
                Console.WriteLine("comando incorrecto");
            }
            return op;
        }

        public static string comentario( string dir) {
            bool pase1=true;
            Program p = new Program();
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                {
                    dir = dir.Remove(0, 1);
                }
                else
                {
                    pase1 = true;
                    break;
                }
            } while (!pase1);

            if (p.name == dir.Substring(0, p.name.Length))
            {
                dir =dir.Remove(0, p.name.Length);
            }
            //quita espacios de nuevo
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                {
                    dir = dir.Remove(0, 1);
                }
                else
                {
                    pase1 = true;
                    break;
                }
            } while (!pase1);
            if ("save" == dir.Substring(0, "save".Length))
            {
                dir = dir.Remove(0, "save".Length);
            }
            do
            {
                if (dir.Substring(0, 1).Equals(" "))
                {
                    dir = dir.Remove(0, 1);
                }
                else
                {
                    pase1 = true;
                    break;
                }
            } while (!pase1);
            return dir;
        }
    }//class
}
