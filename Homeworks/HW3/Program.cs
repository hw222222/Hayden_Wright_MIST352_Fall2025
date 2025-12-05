using System;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkshopSession session = new WorkshopSession();

            int choice = 0;
            do
            {
                ShowMenu();
                choice = ReadInt("Your choice: ");

                switch (choice)
                {
                    case 1:
                        HandlePremiumReservation(session);
                        break;

                    case 2:
                        HandleStandardReservation(session);
                        break;

                    case 3:
                        session.DisplayAllSeats();
                        break;

                    case 4:
                        // Exit
                        break;

                    case 9:
                        DebugFillAllSeats(session);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 4);

            Console.WriteLine("Thank you for using the system.");
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) Assign Premium seat");
            Console.WriteLine("2) Assign Standard seat");
            Console.WriteLine("3) Display all seats");
            Console.WriteLine("4) Exit");
            Console.WriteLine("9) DEBUG: Auto-fill seats");
        }

        static void HandlePremiumReservation(WorkshopSession session)
        {
            if (session.IsWorkshopFull())
            {
                Console.WriteLine("Workshop is full.\n");
                return;
            }

            Participant p = CreateParticipantFromInput();

            bool assigned = session.AssignPremiumSeat(p);
            if (!assigned)
            {
                if (session.IsPremiumFull())
                {
                    bool swap = AskYesNo("Premium is full. Assign Standard instead? (Y/N): ");
                    if (swap)
                    {
                        bool assignedStandard = session.AssignStandardSeat(p);
                        if (!assignedStandard)
                        {
                            if (session.IsWorkshopFull())
                            {
                                Console.WriteLine("Workshop is full.\n");
                            }
                            else
                            {
                                Console.WriteLine("Next workshop starts in 3 hours.\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Next workshop starts in 3 hours.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Could not assign Premium seat.\n");
                }
            }
        }

        static void HandleStandardReservation(WorkshopSession session)
        {
            if (session.IsWorkshopFull())
            {
                Console.WriteLine("Workshop is full.\n");
                return;
            }

            Participant p = CreateParticipantFromInput();

            bool assigned = session.AssignStandardSeat(p);
            if (!assigned)
            {
                if (session.IsStandardFull())
                {
                    bool swap = AskYesNo("Standard is full. Assign Premium instead? (Y/N): ");
                    if (swap)
                    {
                        bool assignedPremium = session.AssignPremiumSeat(p);
                        if (!assignedPremium)
                        {
                            if (session.IsWorkshopFull())
                            {
                                Console.WriteLine("Workshop is full.\n");
                            }
                            else
                            {
                                Console.WriteLine("Next workshop starts in 3 hours.\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Next workshop starts in 3 hours.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Could not assign Standard seat.\n");
                }
            }
        }

        static Participant CreateParticipantFromInput()
        {
            int id = 0;
            string name = "";
            string email = "";

            // Basic, student-level validation loops

            // ID
            bool validId = false;
            while (!validId)
            {
                id = ReadInt("Enter participant ID: ");
                if (id > 0)
                {
                    validId = true;
                }
                else
                {
                    Console.WriteLine("ID must be positive. Try again.\n");
                }
            }

            // Name
            bool validName = false;
            while (!validName)
            {
                Console.Write("Enter participant name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    validName = true;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty. Try again.\n");
                }
            }

            // Email
            bool validEmail = false;
            while (!validEmail)
            {
                Console.Write("Enter participant email: ");
                email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
                {
                    validEmail = true;
                }
                else
                {
                    Console.WriteLine("Email must contain '@'. Try again.\n");
                }
            }

            Participant p = new Participant(id, name, email);
            return p;
        }

        static int ReadInt(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid number. Try again.");
                Console.Write(message);
            }
            return value;
        }

        static bool AskYesNo(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter Y or N.");
                }
            }
        }

        /// <summary>
        /// DEBUG METHOD - Automatically fills all seats in the workshop.
        /// This method is used ONLY for testing and grading.
        /// DO NOT EDIT.
        /// </summary>
        static void DebugFillAllSeats(WorkshopSession session)
        {
            int nextId = 9000;

            while (!session.IsWorkshopFull())
            {
                bool preferPremium = !session.IsPremiumFull();

                string section = preferPremium ? "Premium" : "Standard";
                Participant p = new Participant(
                    nextId,
                    $"{section}_Debug_{nextId}",
                    $"{section.ToLower()}{nextId}@test.com"
                );

                bool assigned = preferPremium
                    ? session.AssignPremiumSeat(p)
                    : session.AssignStandardSeat(p);

                if (!assigned)
                {
                    if (preferPremium && !session.IsStandardFull())
                        session.AssignStandardSeat(p);
                    else if (!preferPremium && !session.IsPremiumFull())
                        session.AssignPremiumSeat(p);
                }

                nextId++;
            }

            Console.WriteLine("DEBUG: All seats auto-filled.\n");
        }
    }
}
