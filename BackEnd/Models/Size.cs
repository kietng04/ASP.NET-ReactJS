using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Size
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string size_Name { get; set; }

    public int Status { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}