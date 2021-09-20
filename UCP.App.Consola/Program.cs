using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;

namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AdicionarProfesor();
            //ActualizarProfesor(1);
            //EncontrarProfesor(1);
            //EncontrarProfesor(2);
            //EncontrarProfesor(3);
            EncontrarProfesores();
            //EliminarProfesor(2);
        }

        //CRUD
        //AdicionarProfesor
        private static void AdicionarProfesor()
        {
            var profesor = new Profesor
            {
                nombre = "Natalia",
                apellidos = "Segura",
                identificacion = 100002,
                telefono = "30000000200",
                correoElectronico = "nataliasegura.tic@ucaldas.edu.co",
                condicionEspecial = "Embarazo",
                Vehiculo_1 = null,
                Vehiculo_2 = null,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 3
            };
            _repoProfesor.AddProfesor(profesor);
        }

        //ActualizarProfesor
        private static void ActualizarProfesor(int idProfesor)
        {
            var profesor = new Profesor
            {
                id =idProfesor,
                nombre = "Santiago",
                apellidos = "Murillo",
                identificacion = 100000,
                telefono = "30000000000",
                correoElectronico = "santiagomurillo.tic@ucaldas.edu.co",
                condicionEspecial = "Ninguna",
                Vehiculo_1 = null,
                Vehiculo_2 = null,
                facultad = "Ingeniería",
                tarifaProfesor = 2500f,                
                cubiculo = 3
            };
            Profesor profesorActualizado=_repoProfesor.UpdateProfesor(profesor);
            if (profesorActualizado!=null)
                Console.WriteLine("Se actualizó el profesor");
            
        }

        //EncontrarProfesor
        private static void EncontrarProfesor(int idProfesor)
        {
            var profesorEncontrado = _repoProfesor.GetProfesor(idProfesor);
            Console.WriteLine(profesorEncontrado.nombre);
        }

        //EncontrarProfesores
        private static void EncontrarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();

            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre+" "+profesor.apellidos+" "+profesor.condicionEspecial);
            }
        }
        //Eliminar Profesor
        private static void EliminarProfesor(int idProfesor)
        {
            bool bandera=_repoProfesor.DeleteProfesor(idProfesor);
            if (bandera)
                Console.WriteLine("Se eliminó el profesor");
            else
            {
                Console.WriteLine("Hubo un error al acceder a la base de datos");
            }
        }
    }
}
