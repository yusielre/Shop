namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetail : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return this.Price * (decimal)this.Quantity; } }
    }

}
