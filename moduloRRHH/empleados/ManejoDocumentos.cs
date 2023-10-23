using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace moduloRRHH.empleados
{
    public static class ManejoDocumentos
    {
        public static string Registrar(string[] datos)
        {

            try
            {
                var parsedDate = DateTime.Parse(datos[3]);    
                datos[3] = parsedDate.ToString();
            }
            catch (Exception)
            {
                datos[3] = "sin expiracion";
            }

            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro="registrar"},
                new clsHerramientas.clsParametros{NombreParametro = "@no_empleado", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[0]},
                new clsHerramientas.clsParametros{NombreParametro = "@Documentos_ID", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[1]},
                new clsHerramientas.clsParametros{NombreParametro = "@Archivo", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[2]},
                new clsHerramientas.clsParametros{NombreParametro = "@Vencimiento", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[3]},
                new clsHerramientas.clsParametros{NombreParametro = "@detalles", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[4]},
                new clsHerramientas.clsParametros{NombreParametro = "@usuario", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[5]}
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Documentacion", parametros);
            return resultado.Item2;
        }

        public static string Editar(string[] datos)
        {
            try
            {
                var parsedDate = DateTime.Parse(datos[3]);
                datos[3] = parsedDate.ToString();
            }
            catch (Exception)
            {
                datos[3] = "sin expiracion";
            }
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro="editar"},
                new clsHerramientas.clsParametros{NombreParametro = "@no_empleado", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[0]},
                new clsHerramientas.clsParametros{NombreParametro = "@Documentos_ID", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[1]},
                new clsHerramientas.clsParametros{NombreParametro = "@Archivo", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[2]},
                new clsHerramientas.clsParametros{NombreParametro = "@Vencimiento", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[3]},
                new clsHerramientas.clsParametros{NombreParametro = "@detalles", TipoParametro = SqlDbType.VarChar, ValorParametro="editado"},
                new clsHerramientas.clsParametros{NombreParametro = "@usuario", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[5]},
                new clsHerramientas.clsParametros{NombreParametro = "@DocumentacionID", TipoParametro = SqlDbType.VarChar, ValorParametro=datos[6]}
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Documentacion", parametros);
            string resu = Historial(datos[6], "actualizado", datos[5], datos[0]);
            return resultado.Item2;
        }

        public static string AceptarDoc(string idDoc, string usuario, string noEmpleado, string detalles)
        {
            string resultado="";
            
            DataTable dt = clsHerramientas.SQLConsulta("SELECT * FROM Documentacion WHERE ID_Documentacion='"+idDoc+"'");
            if(dt.Rows.Count > 0)
            {
                //if (dt.Rows[0]["detalles"].ToString() == "actualizado" || dt.Rows[0]["detalles"].ToString() == "creado" || dt.Rows[0]["detalles"].ToString()=="vencido")
                //{

                 resultado = clsHerramientas.SQLEjecutar("UPDATE Documentacion SET detalles='"+detalles+"' WHERE ID_Documentacion='" + idDoc + "'");
                    if(resultado == "done")
                    {
                        if(detalles == "aceptado")
                        {
                            resultado = "aceptado";
                            string res = Historial(idDoc, "aceptado", usuario, noEmpleado);
                        }
                        else
                        {
                            resultado = "actulizar";
                            string res = Historial(idDoc, "actulizar", usuario, noEmpleado);
                        }
                        
                    }
                    else
                    {
                        return resultado;
                    }
               // }else if()
            

            }
            else
            {
                resultado = "no hay documento";
            }

            return resultado;
        }

        public static string Historial(string docId,string detalles,string user, string dueno)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro="historial"},
                new clsHerramientas.clsParametros{NombreParametro = "@detalles", TipoParametro = SqlDbType.VarChar, ValorParametro= detalles},
                new clsHerramientas.clsParametros{NombreParametro = "@usuario", TipoParametro = SqlDbType.VarChar, ValorParametro= user},
                new clsHerramientas.clsParametros{NombreParametro = "@no_empleado", TipoParametro = SqlDbType.VarChar, ValorParametro= dueno},
                new clsHerramientas.clsParametros{NombreParametro = "@DocumentacionID", TipoParametro = SqlDbType.VarChar, ValorParametro=docId}
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Documentacion", parametros);
            return resultado.Item2;
        }

        public static void ComprobacionVencimiento(string docid, string status, DateTime fechaVencimiento)
        {
            if (status !="vencido" )
            {
                int comparacion = DateTime.Compare(fechaVencimiento, DateTime.Now);
                if (comparacion < 0)
                {
                    //si la fecha de vencimiento es anterior a la fecha actual quiere decir
                    //se ha vencido
                    string act = clsHerramientas.SQLEjecutar("UPDATE Documentacion SET detalles='vencido' WHERE ID_Documentacion='" + docid + "'");
                    act+=Historial(docid, "vencido", "0","0");
                }
            }
        }

        public static DataTable ObtenerHistorial(string ID_Doc)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro="DocHistorial"},
                new clsHerramientas.clsParametros{NombreParametro = "@DocumentacionID", TipoParametro = SqlDbType.VarChar, ValorParametro=ID_Doc}
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Documentacion", parametros);
            
        }

    }
}