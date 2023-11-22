using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using moduloRRHH.App_Code;

namespace moduloRRHH.App_Code
{
    public class DocumentosEmpleado
    {
        public string No_Empleado { get; set; }
        public string Documentos_ID { get; set; }
        public string Vencimiento { get; set; }
        public string detalles { get; set; }
    }
    public class MetodosInicio
    {
        public DataTable ObtenerDocumentosEntregados(string noEmp)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>() {
                new clsHerramientas.clsParametros { NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro = "docrequerido" },
                new clsHerramientas.clsParametros { NombreParametro = "@no_empleado", TipoParametro = SqlDbType.VarChar, ValorParametro = noEmp }
            };
            return clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
        }
        public Dictionary<string,string> ObtenerEmpleados()
        {
            Dictionary<string, string> Employees = new Dictionary<string, string>();

            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>() {
                new clsHerramientas.clsParametros {NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro = "ListaNombres" }
            };
            DataTable dt =  clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
            foreach (DataRow Row in dt.Rows)
            {
                Employees.Add(Row["no_empleado"].ToString(), Row["Nombre"].ToString());
            }
            return Employees;
        }
        
        //regresar tupla de tablas
        public (DataTable, DataTable) ObtenerDocumentacion()
        {
            Dictionary<string, string> empleados = ObtenerEmpleados();
            //DataTable Documentos = ObtenerDocumentos();

            //Crear tabla de archivos que faltan :D | Documentos 
            DataTable dtDocumentos = new DataTable("DocumentosFaltantes");
            //Columnas no_empleado | nombre completo | archivo que falta
            dtDocumentos.Columns.Add(new DataColumn("No_empleado", typeof(string)));
            dtDocumentos.Columns.Add(new DataColumn("Empleado", typeof(string)));
            dtDocumentos.Columns.Add(new DataColumn("Archivo_faltante", typeof(string)));

            //------------------
            //Crear tabla de archivos que faltan :D | Documentos 
            DataTable dtVencidos = new DataTable("DocumentosVencidos");
            //Columnas no_empleado | nombre completo | archivo que falta
            dtVencidos.Columns.Add(new DataColumn("no Empleado", typeof(string)));
            dtVencidos.Columns.Add(new DataColumn("Empleado", typeof(string)));
            dtVencidos.Columns.Add(new DataColumn("Archivo vencido", typeof(string)));


            //Obtener los documentos faltantes con banderas bool;
            foreach (var kvp in empleados)
            {
                // kvp representa KeyValuePair, donde Key es la clave y Value es el valor
                //Console.WriteLine($"Clave: {kvp.Key}, Valor: {kvp.Value}");
                DataTable tabla = ObtenerDocumentosEntregados(kvp.Key);
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    string dato = tabla.Rows[i]["detalles"].ToString();
                    if (tabla.Rows[i]["detalles"].ToString() == "")
                    {
                        dtDocumentos.Rows.Add(dtDocumentos.NewRow().ItemArray = new object[] { kvp.Key,kvp.Value,tabla.Rows[i][0].ToString()  });
                    }else if(tabla.Rows[i]["detalles"].ToString() == "vencido")
                    {
                        dtVencidos.Rows.Add(dtDocumentos.NewRow().ItemArray = new object[] { kvp.Key, kvp.Value, tabla.Rows[i][0].ToString() });

                    }
                }
            }
            return (dtDocumentos,dtVencidos);
        }

        public DataTable Separacion()
        {
            DataTable dtDocumentos = new DataTable("DocumentosFaltantes");
            // Columnas no_empleado | nombre completo | archivo que falta
            dtDocumentos.Columns.Add(new DataColumn("No_empleado", typeof(string)));
            dtDocumentos.Columns.Add(new DataColumn("Empleado", typeof(string)));
            dtDocumentos.Columns.Add(new DataColumn("Archivo_faltante", typeof(string)));

            var dt = ObtenerDocumentacion();
            DataTable tabla = dt.Item1;

            string dtAux = "";
            string archivo = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (dtAux == "")
                {
                    dtAux = tabla.Rows[i]["No_empleado"].ToString();
                }

                if (dtAux == tabla.Rows[i]["No_empleado"].ToString())
                {
                    archivo += "<div>" + tabla.Rows[i]["Archivo_faltante"].ToString() + "</div>";
                }
                else
                {
                    // Agregar la fila a dtDocumentos con la lista de archivos formateada
                    dtDocumentos.Rows.Add(dtDocumentos.NewRow().ItemArray = new object[] { tabla.Rows[i - 1]["No_empleado"].ToString(), tabla.Rows[i - 1]["Empleado"].ToString(), archivo });

                    // Reiniciar la cadena para el próximo empleado
                    archivo = "<div>" + tabla.Rows[i]["Archivo_faltante"].ToString() + "</div>";
                }

                dtAux = tabla.Rows[i]["No_empleado"].ToString();
            }

            // Agregar la última fila después de salir del bucle
            if (!string.IsNullOrEmpty(dtAux))
            {
                dtDocumentos.Rows.Add(dtDocumentos.NewRow().ItemArray = new object[] { tabla.Rows[tabla.Rows.Count - 1]["No_empleado"].ToString(), tabla.Rows[tabla.Rows.Count - 1]["Empleado"].ToString(), archivo });
            }

            return dtDocumentos;
        }



    }
}