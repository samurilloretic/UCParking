using System;

namespace UCP.App.Dominio
{
    public class Puesto
    {
        public int id{get;set;}
        
        public int numero{get;set;}

        public Estado estado{get;set;}

        public TipoVehiculo tipoVehiculo{get;set;}
    }
}