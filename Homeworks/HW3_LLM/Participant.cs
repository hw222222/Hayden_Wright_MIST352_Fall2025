using System;

namespace HW3_LLM
{
    /// <summary>
    /// Represents a participant entity within the workshop ecosystem.
    /// Encapsulates minimal identifying information used for seat assignment.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Numeric identifier for the participant instance.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Human readable name for the participant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact email address that is associated with the participant.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Constructs a new participant with the specified attributes.
        /// </summary>
        public Participant(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Provides a formatted summary string for external display routines.
        /// </summary>
        public string Describe()
        {
            return $"Participant => ID: {Id}, Name: {Name}, Email: {Email}";
        }
    }
}
