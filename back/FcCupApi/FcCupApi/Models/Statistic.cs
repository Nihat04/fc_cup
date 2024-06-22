using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class Statistic<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T Target { get; set; }
        [NotMapped]
        public Object Score { get; set; }
    }
}
