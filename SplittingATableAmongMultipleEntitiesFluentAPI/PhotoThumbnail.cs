using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplittingATableAmongMultipleEntitiesFluentAPI
{
    public class PhotoThumbnail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] ThumbnailImage { get; set; }

        public virtual PhotoFullImage PhotoFullImage { get; set; }
    }
}