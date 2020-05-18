namespace MyWCFService.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public admin()
        {
            tokens = new HashSet<token>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string pwd { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public int? level { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<token> tokens { get; set; }
    }
}
