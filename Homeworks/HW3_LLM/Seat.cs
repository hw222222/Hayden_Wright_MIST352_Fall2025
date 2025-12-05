using System;

namespace HW3_LLM
{
    /// <summary>
    /// Represents a single seat within the workshop layout grid.
    /// Each seat may optionally reference a participant when booked.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Logical row number where this seat resides.
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// Logical seat index inside the row.
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        /// Section label for the seat, for example Premium or Standard.
        /// </summary>
        public string SectionType { get; set; }

        /// <summary>
        /// Indicates whether the seat is currently booked.
        /// </summary>
        public bool IsBooked { get; set; }

        /// <summary>
        /// The participant that has been assigned to this seat, if any.
        /// </summary>
        public Participant AssignedParticipant { get; set; }

        /// <summary>
        /// Time stamp of when the reservation was made.
        /// </summary>
        public DateTime ReservationTime { get; set; }

        /// <summary>
        /// Initializes a seat with the specified structural parameters.
        /// </summary>
        public Seat(int rowNumber, int seatNumber, string sectionType)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            SectionType = sectionType;
            IsBooked = false;
            AssignedParticipant = null;
            ReservationTime = DateTime.MinValue;
        }

        /// <summary>
        /// Attempts to assign a participant to the seat if it is not already booked.
        /// </summary>
        public void AssignParticipant(Participant p)
        {
            if (!IsBooked && p != null)
            {
                AssignedParticipant = p;
                IsBooked = true;
                ReservationTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Builds a descriptive text line expressing the current state of this seat.
        /// </summary>
        public string GetSeatStatus()
        {
            if (!IsBooked)
            {
                return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) -> FREE";
            }
            else
            {
                return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) -> TAKEN by {AssignedParticipant.Name} (ID {AssignedParticipant.Id}) at {ReservationTime}";
            }
        }
    }
}
