using System;

namespace UCP.App.Dominio
{
    public class Administrativo : Persona
    {
        public int id{get;set;}

        public float tarifaAdministrativo{get;set;}
        
        public string unidad{get;set;}

        public int oficina{get;set;}
    }
}