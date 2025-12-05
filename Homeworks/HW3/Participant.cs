using System;

namespace HW3
{
    public class Participant
    {
        private int _id;
        private string _name;
        private string _email;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    Console.WriteLine("ID must be a positive number. ID not changed.");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty. Name not changed.");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Contains("@"))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine("Email should contain '@'. Email not changed.");
                }
            }
        }

        // id + name
        public Participant(int id, string name)
        {
            if (id > 0)
                _id = id;
            else
            {
                Console.WriteLine("ID must be positive. Using default ID 1.");
                _id = 1;
            }

            if (!string.IsNullOrWhiteSpace(name))
                _name = name;
            else
            {
                Console.WriteLine("Name cannot be empty. Using 'Unknown'.");
                _name = "Unknown";
            }

            _email = "";
        }

        // id + name + email
        public Participant(int id, string name, string email)
        {
            if (id > 0)
                _id = id;
            else
            {
                Console.WriteLine("ID must be positive. Using default ID 1.");
                _id = 1;
            }

            if (!string.IsNullOrWhiteSpace(name))
                _name = name;
            else
            {
                Console.WriteLine("Name cannot be empty. Using 'Unknown'.");
                _name = "Unknown";
            }

            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
                _email = email;
            else
            {
                Console.WriteLine("Email is not valid. Using 'unknown@test.com'.");
                _email = "unknown@test.com";
            }
        }
    }
}
