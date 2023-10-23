using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace moduloRRHH.compania
{
    public class MetodosPuestos
    {
        private readonly string _IDPuesto;
        private readonly string _Puesto;
        private readonly string _iDDepartamento;
        private DataTable dt;
        private List<clsHerramientas.clsParametros> parametros;
        public MetodosPuestos() { }
        public MetodosPuestos(string iDPuesto, string puesto, string iDDepartamento)
        {
            _IDPuesto = iDPuesto;
            _Puesto = puesto;
            _iDDepartamento = iDDepartamento;
        }


        public string RegistrarPuesto()
        {
             parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="insert"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDPuesto},
                new clsHerramientas.clsParametros{NombreParametro="@Puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _Puesto},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _iDDepartamento}
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
           
            return resultado.Item2;
        }

        public DataTable ObtenerPuestos(string valor)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=valor}
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
        }

        public string CambiarGenerico(List<ListaEmpleados> Emps)
        {
            for (int i = 0; i < Emps.Count; i++)
            {
                parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="gen"},
                    new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= Emps[i].NoEmpleado}
                };
                var data = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
                if (data.Item2 != "exito")
                {
                    return "Error : " + data.Item2;
                }
            }
            return EliminarPuesto(_IDPuesto);
        }

        public List<ListaEmpleados> PrevencionPuesto()
        {
            List<ListaEmpleados> Lista = new List<ListaEmpleados>();
            //Revisar si tiene empleados
            parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="empleados"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDPuesto}
            };
            dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Lista.Add(new ListaEmpleados { NoEmpleado = dr["no_empleado"].ToString(), NombreEmpleado = dr["Nombre"].ToString(), Puesto = "" });
                }
            }
            return Lista;
        }

        public string EliminarPuesto(string IDPuesto)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                    {
                        new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                        new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="delete"},
                        new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= IDPuesto}
                    };

            var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            return tupla.Item2;
        }

        public string EditarPuesto()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="update"},
                new clsHerramientas.clsParametros{NombreParametro="@Puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=_Puesto },
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _iDDepartamento },
                new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= _IDPuesto}
            };

            var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            return tupla.Item2;
        }

    }
}