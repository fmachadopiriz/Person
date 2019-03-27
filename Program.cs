// NO ENTREGAR ESTE CÓDIGO A LOS ALUMNOS SIN BORRAR LO QUE ESTÁ COMENTADO ENTRE /* Y */
using System;
using System.Linq;

namespace Person
{
    /* BORRAR DESDE ACÁ */
    public class Person
    {
        public Person(string name, string id)
        {
            this.Name = name;
            this.ID = id;
        }
        public string Name { get; set; }
        public string ID { get; set; }

        public void IntroduceYourself()
        {
            Console.WriteLine($"Soy {this.Name} y mi cédula es {this.ID}");
        }
    }    
    /* HASTA ACÁ */

    public class IdUtils
    {
        /// <summary>
        /// Valida un número de cédula de identidad sin puntos ni guiones. Adaptado de https://es.wikipedia.org/wiki/C%C3%A9dula_de_Identidad_de_Uruguay#Match_on_Card
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si el número de cédula es válido y false en caso contrario.</returns>
        public static bool IdIsValid(string id)
        {
            long tempOut;

            // Quitar puntos y guiones
            id = id.Replace(".", "");
            id = id.Replace("-", "");

            // Validar largo
            if (id.Length == 8 && long.TryParse(id, out tempOut))
            {
                var idAsCharArray = id.ToArray();
                var idAsIntArray = idAsCharArray.Select(c => int.Parse(c.ToString())).ToArray();
                var referenceArray = "2987634".ToArray().Select(c => int.Parse(c.ToString())).ToArray();
                var inputCheckDigit = idAsIntArray[7];

                // Calcular número verificador
                int checkSum = 0;
                for (int i = 0; i < referenceArray.Length; i++)
                {
                    checkSum = checkSum + (idAsIntArray[i] * referenceArray[i]);
                }

                int checkDigit = 10 - (checkSum % 10);

                if (checkDigit == 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit != inputCheckDigit)
                {
                    /// Número verificador ingresado inválido
                    return false;
                }
            }
            else
            {
                // Formato de cédula de identidad inválido
                return false;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person("John Doe", "1.234.567-2");
            Person jane = new Person("Jane Doe", "8.765.432-7");
            john.IntroduceYourself();
            jane.IntroduceYourself();
            /* BORRAR DESDE AQUÍ */
            Console.WriteLine(IdUtils.IdIsValid(john.ID));
            Console.WriteLine(IdUtils.IdIsValid(jane.ID));
            john.ID = "1.234.567-8"; // <- Esto no debería ser válido
            jane.ID = "8.765.432-1"; // <- Esto no debería ser válido
            Console.WriteLine(IdUtils.IdIsValid(john.ID));
            Console.WriteLine(IdUtils.IdIsValid(jane.ID));
            /* HASTA AQUÍ */
        }
    }
}