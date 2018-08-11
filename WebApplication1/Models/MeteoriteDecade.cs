namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MeteoriteDecade
    {
        public int MeteoriteDecadeID { get; set; }
               
        public string Decade { get; set; }
               
        public int NumberMeteorites { get; set; }

    }
}
