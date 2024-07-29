namespace FcCupApi.Entities
{
    public interface IBaseEntity
    {
        public long Id { get; set; }
        public DateTime RegistrationDateTime { get; set; }
    }
}
