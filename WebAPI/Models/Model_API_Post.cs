namespace WebAPI.Models
{
    public class Model_API_Post
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public bool Status { get; set; }
    }
}
