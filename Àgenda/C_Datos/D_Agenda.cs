using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using C_Entindad;

namespace C_Datos
{
    public class D_Agenda
    {
        SqlConnection conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public List<E_Agenda> ListarContactos(string buscar)
        {
            SqlDataReader Leer;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            Leer = cmd.ExecuteReader();

            List<E_Agenda> Listar = new List<E_Agenda>();
            while (Leer.Read())
            {
                Listar.Add(new E_Agenda
                {
                    ID = Leer.GetInt32(0),
                    Nombre = Leer.GetString(1),
                    Apellido = Leer.GetString(2),
                    Direccion = Leer.GetString(3),
                    FechaNacimeinto = Leer.GetDateTime(4),
                    Genero = Leer.GetString(5),
                    EstadoCivil = Leer.GetString(6),
                    Movil = Leer.GetString(7),
                    Telefono = Leer.GetString(8),
                    Correo = Leer.GetString(9)
                });
            }
            conectar.Close();
            Leer.Close();

            return Listar;
        }

        public void InsertarContacto(E_Agenda e_Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", e_Agenda.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", e_Agenda.Apellido);
            cmd.Parameters.AddWithValue("@DIRECCION", e_Agenda.Direccion);
            cmd.Parameters.AddWithValue("@NACIMIENTO", e_Agenda.FechaNacimeinto);
            cmd.Parameters.AddWithValue("@GENERO", e_Agenda.Genero);
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", e_Agenda.EstadoCivil);
            cmd.Parameters.AddWithValue("@MOVIL", e_Agenda.Movil);
            cmd.Parameters.AddWithValue("@TELEFONO", e_Agenda.Telefono);
            cmd.Parameters.AddWithValue("@CORREO", e_Agenda.Correo);

            cmd.ExecuteNonQuery();
            conectar.Close();
        }

        public void EditarContacto(E_Agenda e_Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_MODIFICAR", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();

            cmd.Parameters.AddWithValue("@ID", e_Agenda.ID);
            cmd.Parameters.AddWithValue("@NOMBRE", e_Agenda.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", e_Agenda.Apellido);
            cmd.Parameters.AddWithValue("@DIRECCION", e_Agenda.Direccion);
            cmd.Parameters.AddWithValue("@NACIMIENTO", e_Agenda.FechaNacimeinto);
            cmd.Parameters.AddWithValue("@GENERO", e_Agenda.Genero);
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", e_Agenda.EstadoCivil);
            cmd.Parameters.AddWithValue("@MOVIL", e_Agenda.Movil);
            cmd.Parameters.AddWithValue("@TELEFONO", e_Agenda.Telefono);
            cmd.Parameters.AddWithValue("@CORREO", e_Agenda.Correo);

            cmd.ExecuteNonQuery();
            conectar.Close();
        }

        public void EliminarContacto(E_Agenda e_Agenda)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();

            cmd.Parameters.AddWithValue("@ID", e_Agenda.ID);

            cmd.ExecuteNonQuery();
            conectar.Close();
        }
    }
}
