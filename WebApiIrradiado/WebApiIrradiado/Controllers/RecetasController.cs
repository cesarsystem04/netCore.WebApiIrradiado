using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                RecetasResponse recetas = new RecetasResponse();
                recetas.recetas = receta;
                recetas.codError = 0;
                recetas.msgRespuesta = "Ejecución exitosa";

                return Ok(recetas);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("PutReceta")]
        public ActionResult PutReceta(RecetasRequest request)
        {
            try
            {
                RecetasResponse recetas = new RecetasResponse();
                recetas.recetas = request.data.recetas[0] ?? null;
                recetas.codError = 0;
                recetas.msgRespuesta = "Ejecución exitosa";

                return Ok(recetas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]
        [Route("PutReceta2")]
        public void PutReceta2(RecetasRequest request)
        {
            try
            {
                
            }
            catch (Exception e)
            {
              
            }
        }

    }
}
