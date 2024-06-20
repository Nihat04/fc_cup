namespace FcCupApi.Models
{
    public class CompareStatistic<T>: Statistic<T>
    {
        public T SecondTarget { get; set; }
        public Object SecondScore { get; set; }
    }
}
