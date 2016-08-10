namespace FindingAMasterThatHasDetail
{
    public class Comment
    {

        public int Id { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public BlogPost BlogPost { get; set; }
    }
}
