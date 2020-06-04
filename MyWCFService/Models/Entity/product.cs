namespace MyWCFService.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            comments = new HashSet<comment>();
            images = new HashSet<image>();
            order_detail = new HashSet<order_detail>();
            posts = new HashSet<post>();
            reviews = new HashSet<review>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string sku { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string price { get; set; }

        [StringLength(255)]
        public string Ghz { get; set; }

        [StringLength(255)]
        public string color { get; set; }

        [StringLength(255)]
        public string sensor { get; set; }

        [StringLength(255)]
        public string cpu { get; set; }

        [StringLength(255)]
        public string ram { get; set; }

        [StringLength(255)]
        public string storage { get; set; }

        [StringLength(255)]
        public string camera_front { get; set; }

        [StringLength(255)]
        public string camera_rear { get; set; }

        [StringLength(255)]
        public string battery { get; set; }

        [StringLength(255)]
        public string display { get; set; }

        [StringLength(255)]
        public string sim { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public int? activate { get; set; }

        public int? product_cate_id { get; set; }

        public int? discount_id { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? follow { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        public virtual discount discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<image> images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_detail> order_detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews { get; set; }
    }
}
