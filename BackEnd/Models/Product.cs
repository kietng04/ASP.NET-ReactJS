using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }
    
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string Image { get; set; }
    
    public double AvbRating { get; set; }
    
    public int Status { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}