using System.ComponentModel.DataAnnotations;

namespace Domain 

{
    public class Product
    {
        public string Name { get; set; }
        public string Matricule { get; set; }
        [Key]
        public Guid Slug { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Edit { get; set; }
    }
}


