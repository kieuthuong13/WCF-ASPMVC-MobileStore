namespace MyWCFService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        [StringLength(255)]
        public string pwd { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? activated { get; set; }
    }
}
