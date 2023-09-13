using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace moduloRRHH.App_Code
{
    public class clsHerramientas
    {
        public class clsParametros
        {
            public string NombreParametro { get; set; }
            public string ValorParametro { get; set; }
            public SqlDbType TipoParametro { get; set; }
        }

        public static string strConexion = ConfigurationManager.ConnectionStrings["rrhh_ConnectionString"].ConnectionString;
        public static string strUser_admin = ConfigurationManager.ConnectionStrings["user_admin_ConneccionString"].ConnectionString;

        public static DataTable SQLConsulta(string sqlCommand)
        {
           DataTable dt = new DataTable();
            
           SqlConnection con = new SqlConnection(strConexion);
           SqlCommand cmd = new SqlCommand(sqlCommand, con);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           try
           {
               da.Fill(dt);
               con.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return dt;            
        }
        public static DataTable SQLConsultaTUser(string sqlCommand)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(strUser_admin);
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static string SQLEjecutar(string sqlCommand)
        {
            string sqlResult = "";
            SqlConnection conn = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand(sqlCommand, conn);

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                sqlResult = "done";
                conn.Close();
            }
            catch (SqlException ex)
            {
                sqlResult = ex.Message;
            }

            return sqlResult;
        }

        public static string VerificarConexion()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(strConexion);
            try
            {
                cnn.Open();
                cnn.Close();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static DataTable ProcedimientoAlmacenado(string TextoComando, List<clsParametros> Parametros)
        {
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = TextoComando,
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };

            for (int i = 0; i < Parametros.Count; i++)
            {
                cmd.Parameters.Add(Parametros[i].NombreParametro, Parametros[i].TipoParametro).Value = Parametros[i].ValorParametro;
            }
            cmd.Parameters.Add("@message", SqlDbType.NVarChar, 10000).Direction = ParameterDirection.Output;
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();
            return dt;
        }
        public static (DataTable, string) TProcedimientoAlmacenado(string TextoComando, List<clsParametros> Parametros)
        {
            DataTable dt = new DataTable();
            
            SqlConnection con = new SqlConnection(strConexion);     
                try
                {
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = TextoComando,
                        Connection = con,
                        CommandType = CommandType.StoredProcedure
                    };

                    for (int i = 0; i < Parametros.Count; i++)
                    {
                        cmd.Parameters.Add(Parametros[i].NombreParametro, Parametros[i].TipoParametro).Value = Parametros[i].ValorParametro;        
                    }
                    cmd.Parameters.Add("@message", SqlDbType.NVarChar, 10000).Direction = ParameterDirection.Output;                    
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    sa.Fill(dt);
                    string res= Convert.ToString(cmd.Parameters["@message"].Value);   
                    con.Close();

                return (dt, res);
                }
                catch (SqlException ex)
                {
                    return (dt, ex.Message);
                }
            
        }

    }
}