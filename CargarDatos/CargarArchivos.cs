using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CargarDatos.Models;


namespace CargarDatos
{
    public class CargarArchivos
    {
        string _rutaArchivo {get;set;}
        public CargarArchivos(string rutaArchivo)
        {
            _rutaArchivo = rutaArchivo;
        }

        public void cargarEntidades(){

            var datosEnElArchivo = File.ReadLines(_rutaArchivo);
            
               List<EntidadFederativa> Entidades = new List<EntidadFederativa>();

            foreach (var linea in datosEnElArchivo)
            {
                Console.WriteLine(linea);
                    var arregloDatos = linea.Split(',');
                    EntidadFederativa entidadesInsertar = new EntidadFederativa();
                    int EntidadId = 0;
                    if(int.TryParse(arregloDatos[0].Replace('"', ' ').TrimEnd().TrimStart(), out EntidadId))
                    {

                    

                        entidadesInsertar.EntidadId = EntidadId;
                        entidadesInsertar.Nombre = arregloDatos[1].Replace('"', ' ').TrimEnd().TrimStart();
                        entidadesInsertar.NombreAbreviado = arregloDatos[2].Replace('"', ' ').TrimEnd().TrimStart();
                        
                    }
                    int PoblacionTotal = 0;
                    if(int.TryParse(arregloDatos[3].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionTotal)){
                        
                        entidadesInsertar.PoblacionTotal = PoblacionTotal;
                        
                        
                    }

                    int PoblacionMasculina = 0;
                    if(int.TryParse(arregloDatos[4].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionMasculina)){

                        entidadesInsertar.PoblacionMasculina = PoblacionMasculina;
                        
                        
                    }
                    int PoblacionFemenina = 0;
                    if(int.TryParse(arregloDatos[5].Replace('"', ' ').TrimEnd().TrimStart(), out PoblacionFemenina)){

                        entidadesInsertar.PoblacionFemenina = PoblacionFemenina;

                        
                    }
                    Entidades.Add(entidadesInsertar);

                
                } 
            
                
                using(var BaseDeDatos = new EmmaElcoBitContext()){

                    foreach (var Entidad in Entidades){
                    Console.WriteLine($"{Entidad.Nombre} ");
                    Console.WriteLine($"{Entidad.EntidadId} ");
                    BaseDeDatos.EntidadFederativas.Add(Entidad);
                      BaseDeDatos.SaveChanges();
                       Console.WriteLine($"Ya cargue  la Entidad:{Entidad.Nombre} ");
                        
                    }
                     
                }

        }

    }
    
}