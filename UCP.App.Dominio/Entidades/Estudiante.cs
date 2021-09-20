using System;

namespace UCP.App.Dominio
{
    public class Estudiante : Persona
    {
        public int id{get;set;}
        
        public float tarifaEstudiante{get;set;}

        public string programa { get;set;}
    }
}