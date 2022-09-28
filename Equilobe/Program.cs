using Equilobe.BLL.Services;
using Equilobe.DAL.Model;
using Equilobe.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace Equilobe
{
    class Program
    {

        static void Main(string[] args)
        {

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IParkingService, ParkingService>()
                .AddDbContext<ParkingContext>(opt => opt.UseInMemoryDatabase("ParkingContext"))
                .BuildServiceProvider();

            //do the actual work here
            var parkingService = serviceProvider.GetService<IParkingService>();


            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(parkingService);
            }

        }

        private static bool MainMenu(IParkingService parkingService)
        {
            Console.Clear();
            Console.WriteLine("Welcome to our parking system!");
            Console.WriteLine("Please select one of our operations:");

            Console.WriteLine("1. Add new car");

            Console.WriteLine("2. Exist a car");

            Console.WriteLine("3. View all parked cars");

            Console.WriteLine("4. Number of lots filled is required");

            Console.WriteLine("5. Number of lots available is required");

            Console.WriteLine("6. Number of vehicles based on odd and even vehicle numbers.");

            Console.WriteLine("7. Number of vehicles based on the type of vehicle");

            Console.WriteLine("8. Number of vehicles based on the color of the vehicle");

            switch (Console.ReadLine())
            {
                case "1":
                    EnterCar(parkingService);
                    return true;
                case "2":
                    ExitCar(parkingService);
                    return true;
                case "3":
                    ShowAllCars(parkingService);
                    return true;

                case "4":
                    ShowAllCars1(parkingService);
                    return true;

                case "5":
                    ShowAllCars2(parkingService);
                    return true;

                case "6":
                    ShowAllCars3(parkingService);
                    return true;

                case "7":
                    ShowAllCars4(parkingService);
                    return true;

                case "8":
                    ShowAllCars5(parkingService);
                    return true;


                default:
                    return false;
            }

        }

        private static void EnterCar(IParkingService parkingService)
        {
            // add car
            Console.WriteLine("Please enter your car register no:");
            string regNo = Console.ReadLine();
            var rsp = parkingService.EnterCar(regNo);

            Console.WriteLine(rsp.Message);
            Console.ReadKey();

        }

        private static void ExitCar(IParkingService parkingService)
        {

            // exit car
            Console.WriteLine("Please enter your car register no:");
            string regNo = Console.ReadLine();
            var rsp = parkingService.ExitCar(regNo);

            Console.WriteLine(rsp.Message);
            Console.ReadKey();
        }

        private static void ShowAllCars(IParkingService parkingService)
        {
            List<Car> allCars = parkingService.GetAllCars();
            var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);

            Console.WriteLine(json);

            Console.ReadKey();
        }

        private static void ShowAllCars1(IParkingService parkingService)
        {
            List<Car> allCars = parkingService.GetAllCars();
            var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);

            Console.WriteLine("Number of lots filled is required.=");

            Console.ReadKey();
        }

        private static void ShowAllCars2(IParkingService parkingService)
        {
            List<Car> allCars = parkingService.GetAllCars();
            var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);

            Console.WriteLine("Number of lots available is required");

            Console.ReadKey();
        }

        private static void ShowAllCars3(IParkingService parkingService)
        {
            List<Car> allCars = parkingService.GetAllCars();
            var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);

            Console.WriteLine("Number of vehicles based on odd and even vehicle numbers");

            Console.ReadKey();
        }

        private static void ShowAllCars4(IParkingService parkingService)
        {
            List<Car> allCars = parkingService.GetAllCars();
            var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);

            Console.WriteLine("Number of vehicles based on the type of vehicle");
 

            Console.ReadKey();
        }

        private static void ShowAllCars5(IParkingService parkingService)
        {
            //List<Car> allCars = parkingService.GetAllCars();
            //var json = JsonConvert.SerializeObject(allCars, Formatting.Indented);
            
            Console.WriteLine("Number of vehicles based on the color of the vehicle");

            Console.ReadKey();
        }

        public static void ErrorMsg()
        {

            Console.WriteLine("Invalid operation");
        }
    }
}
