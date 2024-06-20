namespace FcCupApi.Models
{
    public class Statistic<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T Target { get; set; }
        public Object Score { get; set; }
    }
}
