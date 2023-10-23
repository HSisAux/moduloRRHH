using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using moduloRRHH.App_Code;

namespace moduloRRHH.empleados
{
    public class CapaSalarios
    {
        private readonly string _NoEmpleado;
        private decimal _SalarioAnterior;
        private readonly decimal _SalarioActual;

        List<clsHerramientas.clsParametros> parametros;

        //Numero de empleado, salario anterior, salarios actual, fecha
        public CapaSalarios () { }
        public CapaSalarios(string NoEmpleado, decimal SalarioAnterior, decimal SalarioActual )
        {
            this._NoEmpleado = NoEmpleado;
            this._SalarioActual = SalarioActual;
            this._SalarioAnterior = SalarioAnterior;
        }

        public DataTable ObtenerSalario(string noEmpleado)
        {
             parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= SqlDbType.VarChar, ValorParametro="ObtenerSalario"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= SqlDbType.VarChar, ValorParametro= noEmpleado }
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Salarios", parametros);
        }

        public string RegistrarSalario()
        {
            DataTable dt = clsHerramientas.SQLConsulta("SELECT * FROM Salario WHERE no_empleado='" + _NoEmpleado + "'");
            if (dt.Rows.Count > 0)
            {
                this._SalarioAnterior = Convert.ToDecimal(dt.Rows[0]["salario_actual"].ToString());
                return EditarSalario();
            }


            parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{ NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="INSERT" },
                new clsHerramientas.clsParametros{ NombreParametro="@Fecha_cambio", TipoParametro=SqlDbType.Date, ValorParametro= DateTime.Now.ToString("yyyy-MM-dd") },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_actual", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioActual.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@no_empleado", TipoParametro=SqlDbType.VarChar, ValorParametro= _NoEmpleado }
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Salarios", parametros);
            return resultado.Item2;
        }

        public string EditarSalario()
        {
            string accion = "UPDATE";
            if (clsHerramientas.SQLConsulta("SELECT * FROM Salario WHERE no_empleado='" + _NoEmpleado + "'").Rows.Count == 0)
            {
                accion = "INSERT";
            }
            parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{ NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro=accion },
                new clsHerramientas.clsParametros{ NombreParametro="@Fecha_cambio", TipoParametro=SqlDbType.Date, ValorParametro= DateTime.Now.ToString("yyyy-MM-dd") },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_actual", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioActual.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@salario_anterior", TipoParametro=SqlDbType.Decimal, ValorParametro= _SalarioAnterior.ToString() },
                new clsHerramientas.clsParametros{ NombreParametro="@no_empleado", TipoParametro=SqlDbType.VarChar, ValorParametro= _NoEmpleado }
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Salarios", parametros);
            return resultado.Item2;
        }
    }
}