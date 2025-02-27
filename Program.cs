using System;
using System.ComponentModel;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //datos de almacenamiento
            int opciones = 0;
            int limite = 10;
            string[] nombre = new string[limite];
            int[] numero = new int[limite];
            int iConteo = 0;

            //Seguridad
            if (Seguridad())
            {//inicio de llave de seguridad 
                do
                {//inicio de llave de bucle do

                    //primera validacion de opciones 
                    //solo acepta numeros enteros 
                    try
                    {
                        //vista de menu
                        Console.WriteLine("Ingrese la opcion que desee realizar");
                        MenuOpciones();
                        opciones = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Error: No se permite letras");
                        continue; //nos ayudar evitar que guarde acciones anteriores
                    }


                    //vista de opciones
                    switch (opciones)
                    {
                        case 1:
                            Guardar(nombre, limite, numero, ref iConteo);
                            break;

                        case 2:
                            MostrarDatos(nombre, numero, iConteo);
                            break;

                        case 3:
                            Console.WriteLine("Gracias por tu participacion");
                            break;

                        default:
                            Console.WriteLine("Opcion no valida, vuelve elegir una de las 3 opciones asignadas");
                            break;
                    }

                }//final de bucle do
                while (opciones != 3);
            }//final de if seguridad
        }

        //metodo de opciones 
        static void MenuOpciones()
        {
            Console.WriteLine("1. Agregar datos para la agenda");
            Console.WriteLine("2. Mostrar datos guardados");
            Console.WriteLine("3. Exit");
        }

        //Metodo de autentificacion
        static bool Seguridad()
        {
            int contrasena = 0;
            int intento = 0;
            int limite = 3;

            while (intento < limite)
            {// inicio de llave while

                Console.WriteLine($"Intento {intento + 1 } de {limite}" );

                try
                {//inicio de try

                    contrasena = Convert.ToInt32(Console.ReadLine());

                    if (contrasena == 123)
                    {
                        Console.WriteLine("Correcto, Acceso permitido");
                        Console.Clear();
                        return (true);

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Contraseña incorrecto");

                    }

                }//fin de try
                catch(Exception)
                {//inicio de catch
                    Console.WriteLine("Error: la contraseña debe ser numeros");
                }//fin de catch
                
                //se ininicia fuera del if
                intento++;
            }//fin de llave while

            Console.WriteLine("Valio Chetos");
            //devuelve un valor en msj
            return (false);
        }

        //metodo logica de guardar
        static void Guardar(string[] nombre, int limite, int[] numero, ref int iConteo)
        {
            if (iConteo < limite)
            {
                Console.WriteLine("Escriba el nombre de la persona");
                nombre[iConteo] = Console.ReadLine();

                while(true){
                    try
                    {

                        Console.WriteLine("Escriba el Numero de telefono");
                        numero[iConteo] = Convert.ToInt32(Console.ReadLine());
                        iConteo++;
                        Console.Clear();
                        break;

                    }
                    catch (Exception)
                    {
                        
                        Console.WriteLine("Solo se puede guardar numeros. Intentalo de nuevo");
                    }
                }
               
               
            }
            else
            {
                Console.WriteLine("Ya no se puede ingresar mas datos");
            }
            
        }

        //metodo mostrar datos
        static void MostrarDatos(string[] nombre, int[] numero, int iConteo)
        {
            Console.WriteLine("---------Datos---------");
            for (int i = 0; i < iConteo; i++)
            {
                Console.WriteLine($"El numero de contacto es: {i+1} ");
                Console.WriteLine($"El nombre es: {nombre[i]} ");
                Console.WriteLine($"El número es: {numero[i] }"); // Solo el número correspondiente
            }

            Console.WriteLine("Presiona una tecla para continuar");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
