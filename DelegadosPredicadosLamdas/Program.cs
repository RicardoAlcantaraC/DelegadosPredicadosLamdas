using System;
using System.Collections.Generic;

namespace DelegadosPredicadosLamdas
{
    class Program
    {
        static void Main(string[] args)
        {
            ejemploDelegados();
            ejemploDelegadoPredicado();
            ejemploPredicados2();
           
        }

        //Definicion del objeto delegado
        //delegate tipo nombreDelegado(parametros);
        delegate void ObjetoDelegado(string msj);
        static void ejemploDelegados()
        {
            
            //Creacion del objeto delegado apuntando al mensaje bienvenida
            ObjetoDelegado miDelegado = new ObjetoDelegado(MensajeBienvenida.SaludoBienvenida);

            //utilizacion del objeto delegado
            miDelegado("Hola acabo de llegar");

            miDelegado = new ObjetoDelegado(MensajeDespedida.SaludoDespedida);

            miDelegado("Hola, ya me voy!");

        }

        

        static void ejemploDelegadoPredicado()
        {
            List<int> listaNumeros = new List<int>();
            Console.WriteLine("¿Hasta que numero desea saber los numeros primos?");
            int limite = int.Parse(Console.ReadLine());

            for (int i = 1; i <= limite; i++)
            {
                listaNumeros.Add(i);
            }

           
            //declaramos delegado predicado
            Predicate<int> miDelPredicado = new Predicate<int>(dameNumerosPrimos);

            List<int> numPares = listaNumeros.FindAll(miDelPredicado);

            foreach (int num in numPares)
            {
                Console.WriteLine(num);
            }
        }

        static bool dameNumerosPrimos(int dividendo)
        {
            
            int modulo=0, totalDivisores=0, divisor=1;
                      
            for (divisor = 1; divisor <= dividendo  ; divisor++)
            {
                modulo = dividendo % divisor;

                if (modulo == 0)
                totalDivisores++;
                
            }

            if (totalDivisores == 2) 
            { 
                return true; 
            }
            else return false;

           
            


        }


       
        
        static void ejemploPredicados2()
        {
            List<Personas> gente = new List<Personas>();

            Personas p1 = new Personas();
            p1.Nombre = "Josue";
            p1.Edad = 18;

            Personas p2 = new Personas();
            p2.Nombre = "Gerardo";
            p2.Edad = 28;

            Personas p3 = new Personas();
            p3.Nombre = "Ricardo";
            p3.Edad = 18;

            gente.AddRange(new Personas[]{ p1,p2,p3});

            Predicate<Personas> predGente = new Predicate<Personas>(existePersona);

            bool existe = gente.Exists(predGente);

            if (existe) Console.WriteLine("Hay personas que se llaman Ricardo");
            else Console.WriteLine("No hay gente con ese nombre");

            Predicate<Personas> predGenteMayor = new Predicate<Personas>(hayAdultos);

            bool mayores = gente.Exists(predGenteMayor);

            if (mayores) Console.WriteLine("Hay personas Adultas");
            else Console.WriteLine("No hay mayores de edad");


        }

        static bool existePersona(Personas prs)
        {
            if (prs.Nombre=="Ricardo") return true;
            else return false;
        }

        static bool hayAdultos(Personas prs)
        {
            if (prs.Edad >= 18) return true;
            else return false;
        }

    }

      

}
