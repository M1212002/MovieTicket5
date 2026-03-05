using MovieTicketHelper5;
using System;
using System.Buffers;

namespace MovieTicketHelper5
{
    class Program
    {
        static void Main(string[] args)
        {

            Cinema cinema = new Cinema("Galaxy Cinema");
            cinema.OpenCinema();

            StandardTicket standard = new StandardTicket("Inception", 80m, "A5");
            VIPTicket vip = new VIPTicket("Avengers", 150m, "B1", true);
            IMAXTicket imax = new IMAXTicket("Dune", 100m, "C3", true);

            standard.Book();
            vip.Book();
            imax.Book();

            cinema.AddTicket(standard);
            cinema.AddTicket(vip);
            cinema.AddTicket(imax);

            Console.WriteLine();
            Console.WriteLine("--- All Tickets ---");
            cinema.PrintAllTickets();
            Console.WriteLine();

            Console.WriteLine("--- Clone Test ---");

            VIPTicket vipClone = (VIPTicket)vip.Clone();
            vipClone.MovieName = "Interstellar";

            Console.WriteLine("Original :");
            vip.Print();

            Console.WriteLine("Clone    :");
            vipClone.Print();
            Console.WriteLine();

            Console.WriteLine("--- After Cancellation ---");

            standard.Cancel();
            standard.Print();
            Console.WriteLine();

            Console.WriteLine("--- BookingHelper.PrintAll ---");

            IPrintable[] arr = { standard, vip, imax };
            BookingHelper.PrintAll(arr);

            cinema.CloseCinema();
        }
    }
}
