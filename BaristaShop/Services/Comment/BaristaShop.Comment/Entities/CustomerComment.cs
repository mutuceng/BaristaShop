namespace BaristaShop.Comment.Entities
{
    public class CustomerComment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
