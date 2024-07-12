using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BlogUNAH.API.Database.Entities
{
    [Table("post_tags", Schema = "dbo")]
    public class PostTagEntity : BaseEntity
    {
        [Column("post_id")]
        
        public Guid PostId{ get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual PostEntity Post { get; set; }

        [Column ("tag_id")]
        public Guid TagId{ get; set; }

        [ForeignKey(nameof(TagId))]
        public virtual TagEntity Tag { get; set; }
    }
}
