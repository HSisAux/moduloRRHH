using moduloRRHH.App_Code;
using moduloRRHH.compania;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace moduloRRHH.documentos
{
    public class MetodoDocumentos
    {
        private string _ID;
        private string _Nombre;
        private string _Expiracion;
        private string _Requerido;

        public MetodoDocumentos(string iD, string nombre, string expiracion, string requerido)
        {
            _ID = iD;
            _Nombre = nombre;
            _Expiracion = expiracion;
            _Requerido = requerido;
        }
        public MetodoDocumentos() { }
        public MetodoDocumentos(string id) { _ID = id; }

        public DataTable ObtenerRegistros(string buscar)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="read"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro=SqlDbType.VarChar,ValorParametro=buscar}
            };

            return clsHerramientas.ProcedimientoAlmacenado("Master_Documentos", parametros);
        }

        public string CrearRegistro()
        {
            DataTable table = clsHerramientas.SQLConsulta("SELECT * FROM Documentos WHERE ID='" + _ID + "'");
            if (table.Rows.Count > 0)
            {
                return "ya existe un documento registrado con el ID especificado";     
            }
            else
            {
                List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="create"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro=_ID},
                    new clsHerramientas.clsParametros{NombreParametro="@nombre",TipoParametro=SqlDbType.VarChar, ValorParametro= _Nombre},
                    new clsHerramientas.clsParametros{NombreParametro="@expiracion",TipoParametro=SqlDbType.VarChar, ValorParametro= _Expiracion},
                    new clsHerramientas.clsParametros{NombreParametro="@requerido",TipoParametro=SqlDbType.VarChar, ValorParametro= _Requerido}

                };
                var ejecutacion = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);
                return ejecutacion.Item2;
            }
        }

        public string ActualizarRegistro()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="update"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro= _ID },
                    new clsHerramientas.clsParametros{NombreParametro="@nombre",TipoParametro=SqlDbType.VarChar, ValorParametro= _Nombre},
                    new clsHerramientas.clsParametros{NombreParametro="@expiracion",TipoParametro=SqlDbType.VarChar, ValorParametro= _Expiracion},
                    new clsHerramientas.clsParametros{NombreParametro="@requerido",TipoParametro=SqlDbType.VarChar, ValorParametro= _Requerido}

                };
            var ejecutado = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);
            return ejecutado.Item2;
        }

        public string BorrarRegistro()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="delete"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro= _ID  },
                };
            var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);

            return tupla.Item2;
        } 
    }
}