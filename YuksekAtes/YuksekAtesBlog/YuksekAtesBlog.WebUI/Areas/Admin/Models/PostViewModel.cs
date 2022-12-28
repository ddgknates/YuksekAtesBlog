namespace YuksekAtesBlog.WebUI.Areas.Admin.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
