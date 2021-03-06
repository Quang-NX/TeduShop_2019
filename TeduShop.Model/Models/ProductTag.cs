﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(Order =1)]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Key]
        [Column(Order =2)]
        [MaxLength(50)]
        public string TagId { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}