namespace FcCupApi.Models
{
    public class StatisticGroup<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Statistic<T>> Stats { get; set; }
    }
}
