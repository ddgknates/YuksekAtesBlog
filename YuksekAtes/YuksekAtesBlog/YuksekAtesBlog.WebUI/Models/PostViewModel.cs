namespace YuksekAtesBlog.WebUI.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
