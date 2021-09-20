using System.Collections.Generic;
using UCP.App.Dominio;

namespace UCP.App.Persistencia
{
    public interface IRepositorioProfesor
    {
        //CRUD 
        //GetAllProfesores
        IEnumerable<Profesor> GetAllProfesores();
        //GetProfesor 
        Profesor GetProfesor(int idProfesor);
        //AddProfesor
        Profesor AddProfesor(Profesor profesor);
        //UpdateProfesor
        Profesor UpdateProfesor(Profesor profesor);
        //DeleteProfesor
        bool DeleteProfesor(int idProfesor);
    }
}