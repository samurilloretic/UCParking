using System;

namespace UCP.App.Dominio

{
    public class Visitante:Persona
    {
        public int id{get;set;}
        
        public float tarifaVisitante{get;set;}

        //public Persona autoriza{get;set;}

        public string autoriza{get;set;}

        public string actividad{get;set;}

    }
}