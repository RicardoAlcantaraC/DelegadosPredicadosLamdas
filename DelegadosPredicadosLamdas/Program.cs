using System;

namespace DelegadosPredicadosLamdas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion del objeto delegado apuntando al mensaje bienvenida
            ObjetoDelegado miDelegado = new ObjetoDelegado(MensajeBienvenida.SaludoBienvenida);

            //utilizacion del objeto delegado
            miDelegado("Hola acabo de llegar");

            miDelegado = new ObjetoDelegado(MensajeDespedida.SaludoDespedida);

            miDelegado("Hola, ya me voy!!");
        }

        //Definicion del objeto delegado
        //delegate tipo nombreDelegado(parametros);
        delegate void ObjetoDelegado(string msj);

    }

    class MensajeBienvenida
    {
        public static void SaludoBienvenida(string msj)
        {
            Console.WriteLine("Mensaje de bienvenida: {0}",msj);
        }
    }

    class MensajeDespedida
    {
        public static void SaludoDespedida(string msj)
        {
            Console.WriteLine("Mensaje de despedida: {0}",msj);
        }
    }

}
