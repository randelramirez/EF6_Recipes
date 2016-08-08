namespace SplittingATableAmongMultipleEntitiesFluentAPI
{
    public class PhotoFullImage
    {

        public int Id { get; set; }

        public byte[] HighResolution { get; set; }

        public virtual PhotoThumbnail PhotoThumbnail { get; set; }
    }
}

