using System;

namespace HW3_LLM
{
    /// <summary>
    /// Central entry point that manages user interaction flows
    /// and delegates seat assignment operations to the workshop session.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Workshop Reservation Console Interface Initialized.");
            WorkshopSession activeSession = new WorkshopSession();

            bool keepRunning = true;

            while (keepRunning)
            {
                ShowMenu();
                Console.Write("Enter selected menu option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Participant p = CreateParticipantFromInput();
                    bool assigned = activeSession.AssignPremiumSeat(p);

                    if (!assigned)
                    {
                        Console.WriteLine("No available premium seats. Assignment not completed.");
                    }
                }
                else if (choice == "2")
                {
                    Participant p = CreateParticipantFromInput();
                    bool assigned = activeSession.AssignStandardSeat(p);

                    if (!assigned)
                    {
                        Console.WriteLine("No available standard seats. Assignment not completed.");
                    }
                }
                else if (choice == "3")
                {
                    activeSession.DisplayAllSeats();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Session termination sequence requested.");
                    keepRunning = false;
                }
                else if (choice == "9")
                {
                    DebugFillAllSeats(activeSession);
                }
                else
                {
                    Console.WriteLine("Unrecognized selection value. Please try again.");
                }
            }

            Console.WriteLine("Program has completed execution.");
        }

        /// <summary>
        /// Renders the primary command menu to the console surface.
        /// </summary>
        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU OPTIONS =====");
            Console.WriteLine("1) Assign Premium seat");
            Console.WriteLine("2) Assign Standard seat");
            Console.WriteLine("3) Display all seats");
            Console.WriteLine("4) Exit program");
            Console.WriteLine("9) Debug - auto fill all seats");
        }

        /// <summary>
        /// Collects participant data from user input and constructs a new Participant object.
        /// Minimal validation is applied for demonstration purposes.
        /// </summary>
        static Participant CreateParticipantFromInput()
        {
            Console.Write("Enter participant ID (numeric): ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid integer value. Re enter participant ID: ");
            }

            Console.Write("Enter participant name: ");
            string name = Console.ReadLine();

            Console.Write("Enter participant email: ");
            string email = Console.ReadLine();

            Participant tempParticipant = new Participant(id, name, email);
            return tempParticipant;
        }

        /// <summary>
        /// DEBUG METHOD – Automatically fills all seats in the workshop.
        /// --------------------------------------------------------------
        /// This method is used ONLY for testing and grading. It allows you
        /// to instantly fill all Premium and Standard seats without typing
        /// 20 participants manually.
        ///
        /// HOW IT WORKS:
        /// 1. Starts with ID = 9000 and increments for each debug participant.
        /// 2. While the workshop still has empty seats:
        ///    • If Premium section still has free seats → try Premium first.
        ///    • Otherwise → fill Standard section.
        /// 3. Creates a Participant object with:
        ///       ID    = nextId
        ///       Name  = "Premium_Debug_ID" or "Standard_Debug_ID"
        ///       Email = "premiumID@test.com" or "standardID@test.com"
        /// 4. Attempts to assign the participant to the preferred section:
        ///    - If assignment succeeds → continue.
        ///    - If assignment fails (section just filled):
        ///         • If Premium failed  → try Standard (if not full)
        ///         • If Standard failed → try Premium (if not full)
        /// 5. This logic guarantees:
        ///    - Every seat gets filled.
        ///    - No seat is overwritten.
        ///    - No infinite loops or invalid assignments.
        /// 6. When complete, prints: "DEBUG: All seats auto-filled."
        ///
        /// WHY THIS EXISTS:
        /// • Makes grading MUCH faster (fills full workshop in < 1 second)
        /// • You can test DisplayAllSeats() instantly.
        /// • Allows you to spot layout errors, timestamp issues,
        ///   and booking logic problems immediately.
        ///
        /// PARAMETERS:
        ///   <param name="session">
        ///     The WorkshopSession object the method will operate on.
        ///     Must already be created in Main(). This object contains:
        ///       - The 20 Seat objects
        ///       - All section/row information
        ///       - Seat-booking methods used internally
        ///   </param>
        ///
        /// RETURNS:
        ///   <returns>
        ///     This method does not return a value (void). It updates the state
        ///     of the WorkshopSession object by filling every empty seat with
        ///     auto-generated Participant objects.
        ///   </returns>
        ///
        /// NOTE:
        ///   • Do NOT modify this method.
        ///   • You must enable this by pressing option 9 (or similar) from the menu.
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
