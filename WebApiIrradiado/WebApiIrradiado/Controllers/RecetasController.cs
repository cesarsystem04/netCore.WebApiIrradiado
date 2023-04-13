using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebApiIrradiado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecetasController : Controller
    {

        // POST: RecetasController/Create
        [HttpPost]
        [Route("AddReceta")]
        public ActionResult AddReceta(Recetas receta)
        {
            try
            {
                RecetasResponse recetas = new()
                {
                    recetas = receta,
                    codError = 0,
                    msgRespuesta = "Ejecución exitosa"
                };

                return Ok(recetas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]
        [Route("PutReceta")]
        public ActionResult PutReceta([Bind("Id,Name,Number,Address")]RecetasRequest request)
        {
            try
            {
                cDatos objDatos = new cDatos();
                string strSQLuno = string.Format(@"INSERT INTO [Configuration].[Recetas](date_modify)
                                                VALUES('{0}')",
                                           DateTime.Now.ToString()
                                           );

                var dstDatosuno = objDatos.EjecutaConsultaSqlServer(strSQLuno);

                if (request.data != null)
                {
                    string strSQL = string.Format(@"INSERT INTO [Configuration].[Recetas]([recipe_num],[empaque],[parametro],[nom_value],[uom],[min_value],[max_value],[manual],[detenido],[tipo],[trans_erp])
                                                VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                                    request.data.recetas[0].recipe_num.ToString(),
                                                    request.data.recetas[0].empaque.ToString(),
                                                    request.data.recetas[0].parametro.ToString(),
                                                    request.data.recetas[0].nom_value.ToString(),
                                                    request.data.recetas[0].uom.ToString(),
                                                    request.data.recetas[0].min_value.ToString(),
                                                    request.data.recetas[0].max_value.ToString(),
                                                    request.data.recetas[0].manual.ToString(),
                                                    request.data.recetas[0].detenido.ToString(),
                                                    request.data.recetas[0].tipo.ToString(),
                                                    request.data.recetas[0].trans_erp.ToString()
                                                    );

                    var dstDatos = objDatos.EjecutaConsultaSqlServer(strSQL);
                }

                RecetasResponse2 recetas = new()
                {
                    messages = "Hola Mundo, por fin tenemos  nuestra interfaz de salida REST",
                    success = "Ok"
                };

                return Ok(recetas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        //[HttpPost]
        //[Route("PutReceta")]
        //public ActionResult PutReceta(RecetasRequest2 request)
        //{
        //    try
        //    {
        //        cDatos objDatos = new cDatos();
        //        string strSQLuno = string.Format(@"INSERT INTO [Configuration].[Recetas](date_modify)
        //                                        VALUES('{0}')",
        //                                   DateTime.Now.ToString()
        //                                   );

        //        var dstDatosuno = objDatos.EjecutaConsultaSqlServer(strSQLuno);

        //        if (request.recetas != null)
        //        {
        //            string strSQL = string.Format(@"INSERT INTO [Configuration].[Recetas]([recipe_num],[empaque],[parametro],[nom_value],[uom],[min_value],[max_value],[manual],[detenido],[tipo],[trans_erp])
        //                                        VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
        //                                            request.recetas.recipe_num.ToString(),
        //                                            request.recetas.empaque.ToString(),
        //                                            request.recetas.parametro.ToString(),
        //                                            request.recetas.nom_value.ToString(),
        //                                            request.recetas.uom.ToString(),
        //                                            request.recetas.min_value.ToString(),
        //                                            request.recetas.max_value.ToString(),
        //                                            request.recetas.manual.ToString(),
        //                                            request.recetas.detenido.ToString(),
        //                                            request.recetas.tipo.ToString(),
        //                                            request.recetas.trans_erp.ToString()
        //                                            );

        //            var dstDatos = objDatos.EjecutaConsultaSqlServer(strSQL);
        //        }

        //        RecetasResponse2 recetas = new()
        //        {
        //            messages = "Hola Mundo, por fin tenemos  nuestra interfaz de salida REST",
        //            success = "Ok"
        //        };

        //        return Ok(recetas);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}




        [HttpPost]
        [Route("PutReceta2")]
        public void PutReceta2(RecetasRequest request)
        {
            try
            {
                cDatos objDatos = new cDatos();

                string strSQLuno = string.Format(@"INSERT INTO [Configuration].[Recetas](date_modify)
                                                VALUES('{0}')",
                                           DateTime.Now.ToString()
                                           );
                var dstDatosuno = objDatos.EjecutaConsultaSqlServer(strSQLuno);

                string strSQL = string.Format(@"INSERT INTO [Configuration].[Recetas]([recipe_num],[empaque],[parametro],[nom_value],[uom],[min_value],[max_value],[manual],[detenido],[tipo],[trans_erp])
                                                VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                                request.data.recetas[0].recipe_num.ToString(),
                                                request.data.recetas[0].empaque.ToString(),
                                                request.data.recetas[0].parametro.ToString(),
                                                request.data.recetas[0].nom_value.ToString(),
                                                request.data.recetas[0].uom.ToString(),
                                                request.data.recetas[0].min_value.ToString(),
                                                request.data.recetas[0].max_value.ToString(),
                                                request.data.recetas[0].manual.ToString(),
                                                request.data.recetas[0].detenido.ToString(),
                                                request.data.recetas[0].tipo.ToString(),
                                                request.data.recetas[0].trans_erp.ToString()
                                                );

                var dstDatos = objDatos.EjecutaConsultaSqlServer(strSQL);
            }
            catch (Exception)
            {

            }
        }



        [HttpPost]
        [Route("PutReceta3")]
        public void PutReceta3(RecetasRequest request)
        {
            try
            {

                using (StreamWriter writer = new StreamWriter(Path.Combine("C:\\Temp\\pruebasIrradiado", "reg.txt"), append: true))
                {
                    string mensaje = "Inicio: " + DateTime.Now.ToString() + " ";
                    mensaje += "recipe_num = " + request.data.recetas[0].recipe_num + ", ";
                    mensaje += "empaque = " + request.data.recetas[0].empaque + ", ";
                    mensaje += "parametro = " + request.data.recetas[0].parametro + ", ";
                    mensaje += "nom_value = " + request.data.recetas[0].nom_value + ", ";
                    mensaje += "min_value = " + request.data.recetas[0].min_value + ", ";
                    mensaje += "max_value = " + request.data.recetas[0].max_value + ", ";
                    mensaje += "manual = " + request.data.recetas[0].manual + ", ";
                    mensaje += "detenido = " + request.data.recetas[0].detenido + ", ";
                    mensaje += "tipo = " + request.data.recetas[0].tipo + ", ";
                    mensaje += "trans_erp = " + request.data.recetas[0].trans_erp + ", ";
                    mensaje += "date_modify = " + request.data.recetas[0].date_modify + ", ";
                    writer.WriteLine(String.Format("{0}", mensaje));
                    writer.Flush();
                    writer.Close();
                }

                string mensajes = string.Empty;
                var propiedades = typeof(RecetasRequest).GetProperties();
                foreach (var propiedad in propiedades)
                {
                    if (propiedad.Name == "recipe_num")
                        mensajes += "recipe_num = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "empaque")
                        mensajes += "empaque = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "parametro")
                        mensajes += "parametro = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "nom_value")
                        mensajes += "nom_value = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "min_value")
                        mensajes += "min_value = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "max_value")
                        mensajes += "max_value = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "manual")
                        mensajes += "manual = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "detenido")
                        mensajes += "detenido = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "tipo")
                        mensajes += "tipo = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "trans_erp")
                        mensajes += "trans_erp = " + propiedad.GetValue(request) + ", ";

                    if (propiedad.Name == "date_modify")
                        mensajes += "date_modify = " + propiedad.GetValue(request) + ", ";
                }



                cDatos objDatos = new cDatos();
                string strSQLuno = string.Format(@"INSERT INTO [Configuration].[Recetas](date_modify)
                                                VALUES('{0}')",
                                           DateTime.Now.ToString()
                                           );
                var dstDatosuno = objDatos.EjecutaConsultaSqlServer(strSQLuno);

                string strSQL = string.Format(@"INSERT INTO [Configuration].[Recetas]([recipe_num],[empaque],[parametro],[nom_value],[uom],[min_value],[max_value],[manual],[detenido],[tipo],[trans_erp])
                                                VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                                request.data.recetas[0].recipe_num.ToString(),
                                                request.data.recetas[0].empaque.ToString(),
                                                request.data.recetas[0].parametro.ToString(),
                                                request.data.recetas[0].nom_value.ToString(),
                                                request.data.recetas[0].uom.ToString(),
                                                request.data.recetas[0].min_value.ToString(),
                                                request.data.recetas[0].max_value.ToString(),
                                                request.data.recetas[0].manual.ToString(),
                                                request.data.recetas[0].detenido.ToString(),
                                                request.data.recetas[0].tipo.ToString(),
                                                request.data.recetas[0].trans_erp.ToString()
                                                );

                var dstDatos = objDatos.EjecutaConsultaSqlServer(strSQL);

            }
            catch (Exception)
            {

            }
        }


    }
}
