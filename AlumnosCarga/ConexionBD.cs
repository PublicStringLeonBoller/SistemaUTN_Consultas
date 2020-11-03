using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace AlumnosCarga
{
    class ConexionBD
    {
        private OleDbConnection conexion { set; get; } = new OleDbConnection(); //Crea una variable para conectarse 
        public OleDbCommand comando { set; get; } = new OleDbCommand(); //Comando de OledbCommand
        public OleDbDataReader lector { set; get; } = null; //Barrido de registro


        public string conexionString = @"Provider=SQLNCLI11;Data Source=localhost\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=UTN_tecnicatura_TP_Final22222";

        public string paSQL{set;get;}="";

        public ConexionBD()
        {
            conexion.ConnectionString= conexionString;
        }
        public void conectar()
        {
            conexion.ConnectionString = conexionString;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        public DataTable leerPA(string paSQL)
        {
            conectar();
            DataTable dt = new DataTable();
            comando.CommandText = "exec " + paSQL;
            dt.Load(comando.ExecuteReader());
            desconectar();
            return dt;
        }
        public void desconectar()
        {
            conexion.Close();
            conexion.Dispose();
        }
        public void leerTabla(string nombreTabla) //
        {
            conectar();
            comando.CommandText = $"select * from {nombreTabla}";
            lector = comando.ExecuteReader();
        }

        public DataTable recuperarTabla(string nombreTabla) // recupera los datos de la consulta
        {
            conectar();

            comando.CommandText = $"select * from {nombreTabla}";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
                      
            desconectar();
            return tabla;
        }
        public void actualizar(string consulta)// consultas que modifica registros
        {
            conectar();
            comando.CommandText = consulta;
            comando.ExecuteNonQuery();
            desconectar();
        }
    }
}
