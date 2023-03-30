namespace HouseEmma.Models
{
    public class HouseDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int RoomCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
