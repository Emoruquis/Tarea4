using System;
using System.IO;

namespace CargarDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string rutaArchivo = System.IO.Path.GetFullPath("Archivos/EntidadFederativa.csv");
            CargarArchivos carga = new CargarArchivos(rutaArchivo);
        }
    }
}
