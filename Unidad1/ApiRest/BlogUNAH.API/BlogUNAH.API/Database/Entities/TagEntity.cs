using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BlogUNAH.API.Database.Entities
{
    [Table("tags", Schema = "dbo")]
    public class TagEntity : BaseEntity
    {
        // Anotaciones
        // Las entidades no seran visibles al clinte se agrega en el dto
        [StringLength(50)]
        [Required]
        [Column("name")]
        public string Name { get; set; }


        [StringLength(250)]
        [Column("description")]
        public string Description { get; set; }
        public IEnumerable<PostTagEntity> Posts { get; set; }
    }
}
