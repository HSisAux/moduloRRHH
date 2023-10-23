using Microsoft.Ajax.Utilities;
using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace moduloRRHH.compania
{
    public class ListaEmpleados
    {
        public string NoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Puesto { get; set; }

    }

    public class MetodosDepartamentos
    {
        private string _departamento;
        private string _IDDepartamento;
        private List<clsHerramientas.clsParametros> parametros;
        DataTable dt;
        public MetodosDepartamentos(){}

        public MetodosDepartamentos (string departamento, string iDDepartamento)
        {
            this._departamento = departamento;
            this._IDDepartamento = iDDepartamento;
        }

        public DataTable ObtenerDepartamentos(string valor)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=valor}
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            
        }

        public string RegistrarDepartamento()
        {
            parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="insert"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDDepartamento},
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _departamento},
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);

            return resultado.Item2;
        }

        public List<ListaEmpleados> PrevencionDepartamento()
        {
            List<ListaEmpleados> Lista = new List<ListaEmpleados>();
            //Revisar si tiene empleados
            parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="empleados"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDDepartamento}
            };
            dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Lista.Add(new ListaEmpleados { NoEmpleado = dr["no_empleado"].ToString(), NombreEmpleado = dr["Nombre"].ToString(), Puesto="" });
                }
            }            
            return Lista;
        }

        public string CambiarGenerico(List<ListaEmpleados>Emps)
        {
            for (int i = 0; i < Emps.Count; i++)
            {
                parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="gen"},
                    new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= Emps[i].NoEmpleado}
                };
                var data = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
                if(data.Item2 != "exito")
                {
                    return "Error : " + data.Item2;
                }
            }
            return EliminarDepartamento(_IDDepartamento);
        }

        public string EliminarDepartamento(string DptoID)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="delete"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= DptoID}
            };

            var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            return tupla.Item2;
        }
        public string EditarDepartamento()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="update"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDDepartamento },
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _departamento},
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            return resultado.Item2;
        }
    }
}