using SplittingATableAmongMultipleEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplittingAnEntityAmongMultipleTables
{
    [Table("Photograph")]
    public class PhotoThumbnail
    {
        [Key] // This attribute would be required if the Id/primary key does not follow the convention, eg: PhotoId or FooId => does not follow convention, Id & PhotoThumbnailId => follows the convention
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("PhotoFullImage")]
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] ThumbnailImage { get; set; }

        //[ForeignKey("Id")] // not working using this style, check why?
        public virtual PhotoFullImage PhotoFullImage { get; set; }
    }
}