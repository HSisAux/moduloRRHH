using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using Antlr.Runtime.Misc;

namespace moduloRRHH.salario
{
    public class MetodosSalarios
    {
        //============ Variables
        private string _noEmpleado;
        private decimal _SalarioAnterior;
        private decimal _SalarioActual;


        List<clsHerramientas.clsParametros> Parametros;
        //============ Constructor
        public MetodosSalarios() { }

        public MetodosSalarios(string noEmpleado, decimal salarioAnterior, decimal salarioActual)
        {
            this._noEmpleado = noEmpleado;
            this._SalarioAnterior = salarioAnterior;
            this._SalarioActual = salarioActual;
        }

        public DataTable ObtenerSalarios(string valor)
        {
            Parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{ NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="ALL" },
                new clsHerramientas.clsParametros{ NombreParametro="@valor", TipoParametro=SqlDbType.VarChar, ValorParametro=valor }
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Salarios",Parametros);
        }

        public string RegistrarSalario()
        {
            DataTable dt = clsHerramientas.SQLConsulta("SELECT * FROM Salario WHERE no_empleado='" + _noEmpleado + "'");
            if(dt.Rows.Count > 0)
            {
                this._SalarioAnterior = Convert.ToDecimal(dt.Rows[0]["salario_actual"].ToString());
                return EditarSalario();
            }
            Parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{ NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="INSERT" },
                new clsHerramientas.clsParametros{ NombreParametro="@Fecha_cambio", TipoParametro=SqlDbType.Date, ValorParametro= DateTime.Now.ToString("yyyy-MM-dd") },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_actual", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioActual.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@no_empleado", TipoParametro=SqlDbType.VarChar, ValorParametro= _noEmpleado }
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Salarios", Parametros);
            return resultado.Item2;
        }

        public string EditarSalario()
        {
            string accion = "UPDATE";
            if (clsHerramientas.SQLConsulta("SELECT * FROM Salario WHERE no_empleado='" + _noEmpleado + "'").Rows.Count == 0)
            {
                accion = "INSERT";
            }
            Parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{ NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro=accion },
                new clsHerramientas.clsParametros{ NombreParametro="@Fecha_cambio", TipoParametro=SqlDbType.Date, ValorParametro= DateTime.Now.ToString("yyyy-MM-dd") },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_actual", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioActual.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_anterior", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioAnterior.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@no_empleado", TipoParametro=SqlDbType.VarChar, ValorParametro= _noEmpleado }
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Salarios", Parametros);
            return resultado.Item2;
        }

    }
}