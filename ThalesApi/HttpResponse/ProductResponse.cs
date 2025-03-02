namespace ThalesApi.HttpResponse
{
    public class ProductResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public decimal tax { get; set; }
        public string description { get; set; }
        public List<string> images { get; set; }
    }
}
