using System;

namespace HW3
{
    public class Seat
    {
        private int _rowNumber;
        private int _seatNumber;
        private string _sectionType;
        private bool _isBooked;
        private Participant _assignedParticipant;
        private DateTime _reservationTime;

        public int RowNumber
        {
            get { return _rowNumber; }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    _rowNumber = value;
                }
                else
                {
                    Console.WriteLine("Row number must be between 1 and 10. Row not changed.");
                }
            }
        }

        public int SeatNumber
        {
            get { return _seatNumber; }
            set
            {
                if (value == 1 || value == 2)
                {
                    _seatNumber = value;
                }
                else
                {
                    Console.WriteLine("Seat number must be 1 or 2. Seat number not changed.");
                }
            }
        }

        public string SectionType
        {
            get { return _sectionType; }
            set
            {
                if (value == "Premium" || value == "Standard")
                {
                    _sectionType = value;
                }
                else
                {
                    Console.WriteLine("Section type must be 'Premium' or 'Standard'. Section not changed.");
                }
            }
        }

        public bool IsBooked
        {
            get { return _isBooked; }
            set { _isBooked = value; }
        }

        public Participant AssignedParticipant
        {
            get { return _assignedParticipant; }
            set { _assignedParticipant = value; }
        }

        public DateTime ReservationTime
        {
            get { return _reservationTime; }
            set { _reservationTime = value; }
        }

        public Seat(int rowNumber, int seatNumber, string sectionType)
        {
            // basic setup with simple checks
            if (rowNumber >= 1 && rowNumber <= 10)
                _rowNumber = rowNumber;
            else
            {
                Console.WriteLine("Invalid row number. Using row 1.");
                _rowNumber = 1;
            }

            if (seatNumber == 1 || seatNumber == 2)
                _seatNumber = seatNumber;
            else
            {
                Console.WriteLine("Invalid seat number. Using seat 1.");
                _seatNumber = 1;
            }

            if (sectionType == "Premium" || sectionType == "Standard")
                _sectionType = sectionType;
            else
            {
                Console.WriteLine("Invalid section type. Using 'Standard'.");
                _sectionType = "Standard";
            }

            _isBooked = false;
            _assignedParticipant = null;
            _reservationTime = DateTime.MinValue;
        }

        public void AssignParticipant(Participant p)
        {
            if (!_isBooked && p != null)
            {
                _assignedParticipant = p;
                _isBooked = true;
                _reservationTime = DateTime.Now;
            }
        }

        public string GetSeatStatus()
        {
            if (!_isBooked)
            {
                return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) - FREE";
            }
            else
            {
                return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) - " +
                       $"TAKEN by {AssignedParticipant.Name} (ID {AssignedParticipant.Id}) at {ReservationTime}";
            }
        }
    }
}
