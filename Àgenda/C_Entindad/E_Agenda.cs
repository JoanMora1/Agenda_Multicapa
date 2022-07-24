using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entindad
{
    public class E_Agenda
    {
        private int _ID;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private DateTime _FechaNacimeinto;
        private string _Genero;
        private string _EstadoCivil;
        private string _Movil;
        private string _Telefono;
        private string _Correo;

        public int ID { get => _ID; set => _ID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public DateTime FechaNacimeinto { get => _FechaNacimeinto; set => _FechaNacimeinto = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public string EstadoCivil { get => _EstadoCivil; set => _EstadoCivil = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
    }
}
