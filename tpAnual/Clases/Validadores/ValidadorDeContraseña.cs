using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Reflection;
using System.Web;

namespace TPANUAL
{
    public class ValidadorDeContraseña
    {
        private static ValidadorDeContraseña instanceContraseña = null;

        protected ValidadorDeContraseña() { }

        public static ValidadorDeContraseña getInstanceValidadorContra()
        {
            if (instanceContraseña == null)
            {
                instanceContraseña = new ValidadorDeContraseña();
            }
            return instanceContraseña;
        }

        //VALIDADOR DE CONTRASEÑAS

        public void mostrarMsjValidador(string contraseña)
        {
            bool[] lista = listaDeValidaciones(contraseña);

            for (int i = 0; i<lista.Length; i++)
            {
                if (!lista[i])
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine(" (X) La contraseña no debe estar vacia. \n");
                            break;
                        case 1:
                            Console.WriteLine(" (X) La contraseña no debe contener caracteres unicode. \n");
                            break;
                        case 2:
                            Console.WriteLine(" (X) La contraseña no debe estar incluida en el top 10.000 de contraseñas mas frecuentes. \n");
                            break;
                        case 3:
                            Console.WriteLine(" (X) La contraseña debe contener al menos una letra minuscula. \n");
                            break;
                        case 4:
                            Console.WriteLine(" (X) La contraseña debe contener al menos una letra mayuscula. \n");
                            break;
                        case 5:
                            Console.WriteLine(" (X) La contraseña debe contener al menos un numero. \n");
                            break;
                        case 6:
                            Console.WriteLine(" (X) La contraseña debe contener de 8 a 64 caracteres. \n");
                            break;
                        case 7:
                            Console.WriteLine(" (X) La contraseña no debe tener numeros consecutivos \n");
                            break;
                        case 8:
                            Console.WriteLine(" (X) La contraseña no debe tener caracteres seguidos repetidos \n");
                            break;
                        case 9:
                            Console.WriteLine(" (X) La contraseña no debe tener letras consecutivas \n");
                            break;
                    }
                }
            }
        }

        public List<String> mostrarMsjValidadorLista(string contraseña)
        {
            bool[] lista = listaDeValidaciones(contraseña);
            List<String> msj = new List<string> { };

            for (int i = 0; i < lista.Length; i++)
            {
                if (!lista[i])
                {
                    switch (i)
                    {
                        case 0:
                            msj.Add("La contraseña no debe estar vacia.");
                            break;
                        case 1:
                            msj.Add("La contraseña no debe contener caracteres unicode.");
                            break;
                        case 2:
                            msj.Add("La contraseña no debe estar incluida en el top 10.000 de contraseñas mas frecuentes.");
                            break;
                        case 3:
                            msj.Add("La contraseña debe contener al menos una letra minuscula.");
                            break;
                        case 4:
                            msj.Add("La contraseña debe contener al menos una letra mayuscula.");
                            break;
                        case 5:
                            msj.Add("La contraseña debe contener al menos un numero.");
                            break;
                        case 6:
                            msj.Add("La contraseña debe contener de 8 a 64 caracteres.");
                            break;
                        case 7:
                            msj.Add("La contraseña no debe tener numeros consecutivos.");
                            break;
                        case 8:
                            msj.Add("La contraseña no debe tener caracteres seguidos repetidos." );
                            break;
                        case 9:
                            msj.Add("La contraseña no debe tener letras consecutivas.");
                            break;
                    }
                }
            }
            return msj;
        }

        public bool validarContraseña(string contraseña)
        {
            bool[] lista = listaDeValidaciones(contraseña);

            foreach(bool booleano in lista)
            {
                if (!booleano)
                {
                    return false;
                }
            }
            return true;
        }

        private bool[] listaDeValidaciones(string contraseña)
        {
            bool[] listaBool = new bool[10];

            listaBool[0] = !string.IsNullOrWhiteSpace(contraseña);

            listaBool[1] = !EsUnicode(contraseña);

            listaBool[2] = !EstaEnLaBaseDeDatos(contraseña);
            //listaBool[2] = true;


            var tieneMinusculas = new Regex(@"[a-z]+");
            var tieneMayusculas = new Regex(@"[A-Z]+");
            var tieneNumeros = new Regex(@"[0-9]+");
            var tieneCantidad = new Regex(@".{8,64}");

            listaBool[3] = tieneMinusculas.IsMatch(contraseña);

            listaBool[4] = tieneMayusculas.IsMatch(contraseña);

            listaBool[5] = tieneNumeros.IsMatch(contraseña);

            listaBool[6] = tieneCantidad.IsMatch(contraseña);

            listaBool[7] = !NumerosConsecutivos(contraseña);

            listaBool[8] = !CaracteresRepetidos(contraseña);

            listaBool[9] = !LetrasConsecutivas(contraseña);

            return listaBool;
        }

        //FUNCIONES AUXILIARES PARA EL VALIDADOR

        // Cuando inicia el servidor, el path del archivo de 10000 contraseñas c
        //private bool EstaEnLaBaseDeDatos(string unString)
        //{
        //    string currentDirectory = Environment.CurrentDirectory;
        //    string directorioArchivoContrasenias = Path.Combine(currentDirectory, "10000Contasenas.txt");
        //    string[] archivoDeContasenias = System.IO.File.ReadAllLines(directorioArchivoContrasenias);

        //    foreach (string linea in archivoDeContasenias)
        //    {
        //        if (linea == unString)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private bool EstaEnLaBaseDeDatos(string unString)
        {
            string sFileName = HttpContext.Current.Server.MapPath(@"~/10000Contrasenas.txt");

            string[] archivoDeContasenias = System.IO.File.ReadAllLines(sFileName);

            foreach (string linea in archivoDeContasenias)
            {
                if (linea == unString)
                {
                    return true;
                }
            }
            return false;
        }

        private bool NumerosConsecutivos(string OtroString)
        {
            List<string> listaConsecutivos = new List<string> { "012", "123", "234", "345", "456", "567", "678", "789" };

            foreach(string consecutivo in listaConsecutivos)
            {
                if (OtroString.Contains(consecutivo))
                {
                    return true;
                }
            }
            return false;

        }

        private bool LetrasConsecutivas(string otroString)
        {
            char[] unString = otroString.ToCharArray();

            for (int i = 0; i < unString.Length - 2; i++)
            {
                if (((int)unString[i+1] == ((int)unString[i] +1)) && (((int)unString[i + 1] +1) == ((int)unString[i + 2])))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CaracteresRepetidos(string otroString)
        {
            char[] unString = otroString.ToCharArray();

            for (int i = 0; i < unString.Length -2; i++)
            {
                if (((int)unString[i] == (int)unString[i + 1]) && ((int)unString[i + 1] == (int)unString[i + 2]))
                {
                    return true;
                } 
            }

            return false;

        }

        private bool EsUnicode(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodBytesCount;
        }

        //END VALIDADOR CONTRASEÑA

    }
}
