using System.Threading;

namespace AsatabarberProject.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string Time { get; set; }

        public Barbers Barber { get; set; }  // Связь с мастером
    }
}
