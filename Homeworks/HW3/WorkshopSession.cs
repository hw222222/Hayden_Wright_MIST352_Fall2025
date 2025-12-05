using System;

namespace HW3
{
    public class WorkshopSession
    {
        private Seat[] _seats;

        public Seat[] Seats
        {
            get { return _seats; }
        }

        public WorkshopSession()
        {
            _seats = new Seat[20];

            int index = 0;
            for (int row = 1; row <= 10; row++)
            {
                string section = (row >= 1 && row <= 5) ? "Premium" : "Standard";

                for (int seatNum = 1; seatNum <= 2; seatNum++)
                {
                    _seats[index] = new Seat(row, seatNum, section);
                    index++;
                }
            }
        }

        public bool AssignPremiumSeat(Participant p)
        {
            int index = FindFirstAvailableSeat(1, 5);
            if (index == -1)
            {
                return false;
            }

            _seats[index].AssignParticipant(p);
            Console.WriteLine("Premium seat assigned.");
            return true;
        }

        public bool AssignStandardSeat(Participant p)
        {
            int index = FindFirstAvailableSeat(6, 10);
            if (index == -1)
            {
                return false;
            }

            _seats[index].AssignParticipant(p);
            Console.WriteLine("Standard seat assigned.");
            return true;
        }

        public bool IsPremiumFull()
        {
            return FindFirstAvailableSeat(1, 5) == -1;
        }

        public bool IsStandardFull()
        {
            return FindFirstAvailableSeat(6, 10) == -1;
        }

        public bool IsWorkshopFull()
        {
            foreach (Seat s in _seats)
            {
                if (!s.IsBooked)
                {
                    return false;
                }
            }
            return true;
        }

        public void DisplayAllSeats()
        {
            Console.WriteLine();
            Console.WriteLine("Workshop: MIST352 Workshop");
            Console.WriteLine("------------------------------------------------------------");

            foreach (Seat s in _seats)
            {
                Console.WriteLine(s.GetSeatStatus());
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }

        private int FindFirstAvailableSeat(int startRow, int endRow)
        {
            for (int i = 0; i < _seats.Length; i++)
            {
                if (_seats[i].RowNumber >= startRow &&
                    _seats[i].RowNumber <= endRow &&
                    !_seats[i].IsBooked)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
