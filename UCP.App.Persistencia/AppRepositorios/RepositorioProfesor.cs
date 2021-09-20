using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace UCP.App.Persistencia
{
    public class RepositorioProfesor: IRepositorioProfesor
    {
        private readonly AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD
        //GetAllProfesores
        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.profesores;
        }
        //GetProfesor
        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id==idProfesor);
            return profesorEncontrado;
        }
        //AddProfesor
        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.profesores.Add(profesor);
            _appContext.SaveChanges();
            return profesorAdicionado.Entity;
        }
        //UpdateProfesor
        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p => p.id==profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.telefono = profesor.telefono;
                profesorEncontrado.correoElectronico = profesor.correoElectronico;
                profesorEncontrado.condicionEspecial = profesor.condicionEspecial;
                profesorEncontrado.Vehiculo_1 = profesor.Vehiculo_1;
                profesorEncontrado.Vehiculo_2 = profesor.Vehiculo_2;
                profesorEncontrado.tarifaProfesor = profesor.tarifaProfesor;
                profesorEncontrado.cubiculo = profesor.cubiculo;
                profesorEncontrado.facultad = profesor.facultad;

                _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }
        //DeleteProfesor
        bool IRepositorioProfesor.DeleteProfesor(int idProfesor)
        {
            var profesorEncontrado = _appContext.profesores.FirstOrDefault(p=>p.id==idProfesor);
            if (profesorEncontrado == null)
                return false;
            _appContext.profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
            return true;
        }
    }
}