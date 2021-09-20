using System;

namespace UCP.App.Dominio

{
    public class Profesor : Persona
    {
        public int id{get;set;}
        
        public float tarifaProfesor{get;set;}

        public string facultad{get;set;}

        public int cubiculo{get;set;}
    }
}