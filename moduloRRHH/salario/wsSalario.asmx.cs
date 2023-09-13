using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace moduloRRHH.salario
{
    /// <summary>
    /// Descripción breve de wsSalario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsSalario : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public  string[] BuscarEmpleado(string prefix)
       {
            List<string> empleados = new List<string>();
            List<clsHerramientas.clsParametros> lista = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="BuscarEmpleado"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro=prefix}
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Salarios", lista);
            foreach (DataRow row in dt.Rows)
            {
                empleados.Add(string.Format("{0}-{1}", row["Nombre"].ToString() + " " + row["Apellido_P"].ToString() + " " + row["Apellido_M"].ToString(), row["no_empleado"].ToString()));
            }

            return empleados.ToArray();
        }
    }
}
