namespace ApiControllers.Models
{
    public interface IRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int id] { get; }
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }

    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Reservation> items;
        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation> 
            {
                new Reservation { ClientName = "Alice", Location = "Board Room" },
                new Reservation { ClientName = "Bob", Location = "Lecture Hall" },
                new Reservation { ClientName = "Joe", Location = "Meeting Room 1" }
            }.ForEach(r => AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;
        public IEnumerable<Reservation> Reservations => items.Values;
        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Reservationld == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reservation.Reservationld = key;
            }
            items[reservation.Reservationld] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);
        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
