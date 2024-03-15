using System.ComponentModel.DataAnnotations;

namespace Domain 

{
    public class Product
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Matricule { get; set; }
        [Key]
        public Guid Slug { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Edit { get; set; }
    }
}


