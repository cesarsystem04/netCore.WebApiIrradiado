namespace WebApiIrradiado
{
    public class Recetas
    {
        public string recipe_num { get; set; } = string.Empty;
        public string empaque { get; set; } = string.Empty;
        public string parametro { get; set; } = string.Empty;
        public decimal nom_value { get; set; }
        public string uom { get; set; } = string.Empty;
        public decimal min_value { get; set; }
        public decimal max_value { get; set; }
        public byte manual { get; set; }
        public byte detenido { get; set; }
        public string tipo { get; set; } = string.Empty;
        public byte trans_erp { get; set; }
        public string? date_modify { get; set; }
    }


    public class RecetasResponse
    {
        public Recetas? recetas { get; set; }
        public string? msgRespuesta { get; set; }
        public int codError { get; set; }



    }

    public class RecetasResponse2
    {
        public string? messages { get; set; }
        public string? success { get; set; }



    }



    public class RecetasRequest
    {
        public Data? data { get; set; }

    }


    public class Data
    {
        public Recetas[]? recetas { get; set; }

    }





    public class RecetasRequest2
    {
        public Recetas? recetas { get; set; }

    }


}
