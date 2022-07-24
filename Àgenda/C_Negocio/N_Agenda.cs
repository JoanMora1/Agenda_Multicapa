using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;
using C_Entindad;

namespace C_Negocio
{
    public class N_Agenda
    {
        D_Agenda d_Agenda = new D_Agenda();

        public List<E_Agenda> Listar(string buscar)
        {
            return d_Agenda.ListarContactos(buscar);
        }

        public void InsertandoContacto (E_Agenda e_Agenda)
        {
            d_Agenda.InsertarContacto(e_Agenda);
        }

        public void EditandoContacto (E_Agenda e_Agenda)
        {
            d_Agenda.EditarContacto(e_Agenda);
        }
        public void EliminandoContacto (E_Agenda e_Agenda)
        {
            d_Agenda.EliminarContacto(e_Agenda);
        }
    }
}
