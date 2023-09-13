using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using moduloRRHH.App_Code;
using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web.UI;

namespace moduloRRHH.empleados
{
    public class CapaManejoEmpleados
    {
        private string NoEmpleado;
        private string Nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private bool status;
        private string rfc;
        private string nss;
        private string FechaNac;
        private string FechaIngreso;
        private string Calle;
        private string colonia;
        private string cp;
        private string estado;
        private string ciudad;
        private string telefono;
        private string correo;
        private string TelEmergencia;
        private string ContactoEmergencia;
        private string IDDepartamento;
        private string idpuesto;
        private string empresa;
        private string foto;

        HttpFileCollection files = HttpContext.Current.Request.Files;
        //Constructores
        public CapaManejoEmpleados(string noEmpleado, string nombre, string apellidoPaterno, string apellidoMaterno, bool status, string rfc, string nss, string fechaNac, string fechaIngreso, string calle, string colonia, string cp, string estado, string ciudad, string telefono, string correo, string telEmergencia, string contactoEmergencia, string iDDepartamento, string idpuesto, string empresa)
        {
            this.NoEmpleado = noEmpleado;
            this.Nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.status = status;
            this.rfc = rfc;
            this.nss = nss;
            this.FechaNac = fechaNac;
            this.FechaIngreso = fechaIngreso;
            this.Calle = calle;
            this.colonia = colonia;
            this.cp = cp;
            this.estado = estado;
            this.ciudad = ciudad;
            this.telefono = telefono;
            this.correo = correo;
            this.TelEmergencia = telEmergencia;
            this.ContactoEmergencia = contactoEmergencia;
            this.IDDepartamento = iDDepartamento;
            this.idpuesto = idpuesto;
            this.empresa = empresa;
        }

        public CapaManejoEmpleados()
        {

        }

        public string RegistrarEmpleado(string accion)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=accion},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= NoEmpleado },
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= Nombre },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoP", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= apellidoPaterno },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoM", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= apellidoMaterno},
                new clsHerramientas.clsParametros{NombreParametro="@status", TipoParametro=System.Data.SqlDbType.Bit , ValorParametro= status.ToString() },
                new clsHerramientas.clsParametros{NombreParametro="@rfc", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= rfc },
                new clsHerramientas.clsParametros{NombreParametro="@nss", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= nss },
                new clsHerramientas.clsParametros{NombreParametro="@fechaNacimiento", TipoParametro=System.Data.SqlDbType.Date, ValorParametro= FechaNac },
                new clsHerramientas.clsParametros{NombreParametro="@fechaIngreso", TipoParametro=System.Data.SqlDbType.Date, ValorParametro= FechaIngreso },
                new clsHerramientas.clsParametros{NombreParametro="@Calle", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= Calle},
                new clsHerramientas.clsParametros{NombreParametro="@Colonia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= colonia},
                new clsHerramientas.clsParametros{NombreParametro="@cp", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= cp},
                new clsHerramientas.clsParametros{NombreParametro="@Estado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= estado},
                new clsHerramientas.clsParametros{NombreParametro="@Ciudad", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= ciudad},
                new clsHerramientas.clsParametros{NombreParametro="@Telefono", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= telefono},
                new clsHerramientas.clsParametros{NombreParametro="@TelEmergencia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro = TelEmergencia},
                new clsHerramientas.clsParametros{NombreParametro="@ContactoEmergencia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= ContactoEmergencia},
                new clsHerramientas.clsParametros{NombreParametro="@Correo", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= correo},
                new clsHerramientas.clsParametros{NombreParametro="@IDdepartamento", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= IDDepartamento},
                new clsHerramientas.clsParametros{NombreParametro="@IDpuesto", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= idpuesto},
                new clsHerramientas.clsParametros{NombreParametro="@Empresa", TipoParametro=System.Data.SqlDbType.Int, ValorParametro= empresa}
            };
            if (accion == "insert")
            {
                if (files.Count > 0)
                {
                    HttpPostedFile file = files[0];
                    if (file.FileName != "")
                    {
                        try
                        {
                            //se genera una direccion, que apunta a la carpeta de archivos/ la empresa en la que esta registrado el empleado,/ su numero y nombre completo
                            string link = "\\Archivos\\" + empresa + "\\" + NoEmpleado+" "+Nombre+" "+apellidoPaterno+" "+apellidoMaterno;

                            //reviso si la direccion existe y si no, la creo
                            if (!Directory.Exists(HttpContext.Current.Request.MapPath(link)))
                            {
                                DirectoryInfo di = System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(link));
                            }
                            //Se genera la direccion en la que se guardara la foto
                            foto = link + "\\" + file.FileName;

                            //Se guarda la foto en una carpeta
                            file.SaveAs(HttpContext.Current.Server.MapPath(foto));
                        }
                        catch(Exception ex)
                        {
                            return "Ocurrio un error: " + ex.Message;
                        }
                    }
                    else
                    {
                        //foto generica
                        foto = "\\Assets\\img\\default-user.png";
                    }
                }
                else
                {
                    //foto generica
                    foto = "\\Assets\\img\\default-user.png";
                }

                //Guardamos la foto 
                parametros.Add(new clsHerramientas.clsParametros { NombreParametro = "@foto", TipoParametro = System.Data.SqlDbType.VarChar, ValorParametro = foto });
            }
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
            return resultado.Item2;
        }

        public (string,string) CambiarFoto(string id, string empresa, string nombre)
        {
            
            if (files.Count > 0)
            {                
                HttpPostedFile file = files[0];
                if (file.FileName != "")
                {
                    try
                    {
                        string link = "\\Archivos\\" + empresa + "\\" + nombre;

                        if (!Directory.Exists(HttpContext.Current.Request.MapPath(link)))
                        {
                            DirectoryInfo di = System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(link));
                        }
                        foto = link + "\\" + file.FileName;
                        file.SaveAs(HttpContext.Current.Server.MapPath(foto));
                        
                        List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                        {
                            new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="Fotoperfil"},
                            new clsHerramientas.clsParametros{NombreParametro="@foto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=foto},
                            new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= id}
                        };
                        var ejecutarquery = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);

                        return (ejecutarquery.Item2,foto) ;
                    }
                    catch (Exception ex)
                    {
                        return (ex.Message,"");

                    }

                }
                else
                {
                    return ("No ha seleccionado una foto","");
                }
            }
            else
            {
                return ("No ha seleccionado una foto", "");
            }
        }
        public bool BuscarNoEmpleado(string str)
        {
            DataTable dt = clsHerramientas.SQLConsulta("SELECT no_empleado FROM Empleado WHERE no_empleado='" + str + "'");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable LlenarComboDepartamento()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=""}
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
        }

        public DataTable LLenarComboPuestos(string id)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="seleccionarPuesto"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=id}
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
        }
        /*=================== obtiene la informacion del empleado con el ID especificado, 
         * Regresa un diccionario donde Key es el nombre de la columna y value es el valor del campo================*/
        public Dictionary<string,string> ObtenerInformacion(string id, string accion)
        {
            Dictionary<string, string> Informacion = new Dictionary<string, string>();

            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro=id},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=accion},
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                foreach (DataColumn col in dt.Columns)
                {
                    Informacion.Add(col.ColumnName, row[col.ColumnName].ToString());
                }
                Informacion["foto"] = Informacion["foto"].Replace('\\', '/');

            }

            return Informacion;
        }

        /*============== Cambia el estado de activo/inactivo del empleado  ===============*/
        public string CambiarStatus(string id, string status)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="switch"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=id},
                new clsHerramientas.clsParametros{NombreParametro="@Estado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=status},
            };
             var cambio = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
            return cambio.Item2;
        }
        /*=================== Obtener lista de empleados ==========================*/
        public DataTable ObtenerListaEmpleados()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion",TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="all" }
            };

            return clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
        }

        /*================= obtener lista con valor de busqueda*/
        public DataTable ObtenerEmpleadosBusqueda(string valor, string parametroBD, string tipoBusqueda)
        {
            SqlDbType tipo = SqlDbType.VarChar;
            if(parametroBD == "@status")
            {
                tipo = SqlDbType.Bit;
            }else if(parametroBD == "@Empresa")
            {
                tipo = SqlDbType.Int;

            }
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion",TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro=tipoBusqueda },
                new clsHerramientas.clsParametros{NombreParametro=parametroBD,TipoParametro=tipo, ValorParametro=valor }

            };

            return clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
        }
    }
}