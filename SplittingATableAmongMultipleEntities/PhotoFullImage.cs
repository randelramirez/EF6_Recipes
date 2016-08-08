using SplittingAnEntityAmongMultipleTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplittingATableAmongMultipleEntities
{
    [Table("Photograph")]
    public class PhotoFullImage
    {
        // using Data annotation without Fluent API
        [Key] // This attribute would be required if the Id/primary key does not follow the convention, eg: PhotoId or FooId => does not follow convention, Id & PhotoFullImageId => follows the convention
        [ForeignKey("PhotoThumbnail")]
        public int Id { get; set; }

        public byte[] HighResolution { get; set; }

        // using Data annotation without Fluent API
        //[ForeignKey("Id")]  //[ForeignKey("Id")] // not working using this style, check why?
        public virtual PhotoThumbnail PhotoThumbnail { get; set; }
    }
}

