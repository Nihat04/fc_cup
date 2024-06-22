using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class CompareStatistic<T>: Statistic<T>
    {
        public T SecondTarget { get; set; }
        [NotMapped]
        public Object SecondScore { get; set; }
    }
}
