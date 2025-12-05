using System;

namespace HW3_LLM
{
    /// <summary>
    /// Coordinates the construction and management of all workshop seats.
    /// Provides methods for premium and standard seat allocation routines.
    /// </summary>
    public class WorkshopSession
    {
        /// <summary>
        /// Internal array that stores all seat entities for this workshop instance.
        /// </summary>
        private Seat[] _seats;

        /// <summary>
        /// Exposes the raw seat array for read only scenarios if needed.
        /// </summary>
        public Seat[] Seats
        {
            get { return _seats; }
        }

        /// <summary>
        /// Constructs the workshop session and generates the full seating topology.
        /// Rows 1 to 5 are flagged as Premium and rows 6 to 10 as Standard.
        /// </summary>
        public WorkshopSession()
        {
            _seats = new Seat[20];
            int index = 0;

            for (int row = 1; row <= 10; row++)
            {
                string sectionLabel = row <= 5 ? "Premium" : "Standard";

                for (int seatNum = 1; seatNum <= 2; seatNum++)
                {
                    _seats[index] = new Seat(row, seatNum, sectionLabel);
                    index++;
                }
            }
        }

        /// <summary>
        /// Attempts to assign a participant to the first available premium seat.
        /// </summary>
        public bool AssignPremiumSeat(Participant p)
        {
            int locationIndex = FindFirstAvailableSeat(1, 5);
            if (locationIndex == -1)
            {
                return false;
            }

            _seats[locationIndex].AssignParticipant(p);
            Console.WriteLine("Premium seat assignment completed.");
            return true;
        }

        /// <summary>
        /// Attempts to assign a participant to the first available standard seat.
        /// </summary>
        public bool AssignStandardSeat(Participant p)
        {
            int locationIndex = FindFirstAvailableSeat(6, 10);
            if (locationIndex == -1)
            {
                return false;
            }

            _seats[locationIndex].AssignParticipant(p);
            Console.WriteLine("Standard seat assignment completed.");
            return true;
        }

        /// <summary>
        /// Determines whether all premium seats have been filled.
        /// </summary>
        public bool IsPremiumFull()
        {
            return FindFirstAvailableSeat(1, 5) == -1;
        }

        /// <summary>
        /// Determines whether all standard seats have been filled.
        /// </summary>
        public bool IsStandardFull()
        {
            return FindFirstAvailableSeat(6, 10) == -1;
        }

        /// <summary>
        /// Evaluates whether the workshop has any remaining free seats.
        /// </summary>
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

        /// <summary>
        /// Prints a multi line textual representation of each seat to the console stream.
        /// </summary>
        public void DisplayAllSeats()
        {
            Console.WriteLine();
            Console.WriteLine("Workshop: MIST 352 Session Seating Overview");
            Console.WriteLine("------------------------------------------------------------");

            foreach (Seat s in _seats)
            {
                Console.WriteLine(s.GetSeatStatus());
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Locates the index of the first available seat in the inclusive row range.
        /// Returns -1 if no available match can be found.
        /// </summary>
        private int FindFirstAvailableSeat(int startingRow, int endingRow)
        {
            for (int i = 0; i < _seats.Length; i++)
            {
                if (_seats[i].RowNumber >= startingRow &&
                    _seats[i].RowNumber <= endingRow &&
                    !_seats[i].IsBooked)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
