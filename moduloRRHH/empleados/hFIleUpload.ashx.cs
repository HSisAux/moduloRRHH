using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace moduloRRHH.empleados
{
    /// <summary>
    /// Descripción breve de hFIleUpload
    /// </summary>
    public class hFIleUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Nombre = context.Request.Params["nombre"];
            string NoEmpleado = context.Request.Params["noempleado"];
            string Empresa = context.Request.Params["empresa"];
            string Expiracion = context.Request.Params["expiracion"];
            string Documento = context.Request.Params["documento"];
            string DocumentacionID = context.Request.Params["DocumentacionID"];
            string fecha = context.Request.Params["fecha"];

            string fname = "";
            string strRsultado = "";

            string accion = context.Request.Params["accion"];

            //reviso si hay dcumentos
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                HttpPostedFile file = files[0];

                //============= Guardamos el archivo ===============
                string link = "\\Archivos\\" + Empresa + "\\" + NoEmpleado + " " + Nombre + "\\Documentos";
                if (!Directory.Exists(HttpContext.Current.Request.MapPath(link)))
                {
                    DirectoryInfo di = System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(link));
                }
                link = link + "\\" + file.FileName;
                file.SaveAs(HttpContext.Current.Server.MapPath(link));

                string[] datos = { NoEmpleado, Documento, link, FechaVencimiento(Expiracion)=="1"?fecha: FechaVencimiento(Expiracion), "creado", "014", DocumentacionID };

                string ruta = fname.ToString();
                if (accion == "subir")
                {
                    strRsultado = ManejoDocumentos.Registrar(datos);
                    if(strRsultado == "Registro exitoso")
                    {
                        //Registro en el historial 
                        strRsultado = ManejoDocumentos.Historial("","creado", "114", NoEmpleado);
                    }
                }
                else if (accion == "editar")
                {
                    strRsultado = ManejoDocumentos.Editar(datos);
                    
                }

            }else{
                strRsultado = "No se ha detectado un documento";
            }
            

            
            
            context.Response.ContentType = "text/plain";
            context.Response.Write(strRsultado);
        }

        private string FechaVencimiento(string tipo)
        {
            string res="";
            switch (tipo)
            {
                case "0":
                    res = "sin expiracion";
                    break;
                case "1":
                    res = tipo;
                    break;
                case "2":
                    res = DateTime.Now.AddMonths(6).ToString();
                    break;
                case "3":
                    res = DateTime.Now.AddMonths(3).ToString();
                    break;
                case "4":
                    res = DateTime.Now.AddYears(1).ToString();
                    break;
            }
            return res;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

       
    }
}