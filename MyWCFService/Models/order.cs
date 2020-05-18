namespace MyWCFService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? users_id { get; set; }

        [StringLength(50)]
        public string total_money { get; set; }

        public DateTime? date_create { get; set; }

        [StringLength(255)]
        public string method { get; set; }

        public int? status { get; set; }
    }
}
