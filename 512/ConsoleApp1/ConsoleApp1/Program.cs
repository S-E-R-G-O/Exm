using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Passenger> busPas = new List<Passenger>();
            for (int i = 0; i < 412; i++)
                busPas.Add(new Passenger(new FactoryBusPassenger()));

            //double tempBus = busPas.Count / Bus.amountOfBusPassengers;
           // Math.Round(tempBus);

            List<Passenger> taxiPas = new List<Passenger>();
            for (int i = 0; i < 40; i++)
                taxiPas.Add(new Passenger(new FactoryTaxiPassenger()));


            List<Passenger> pizza = new List<Passenger>();
            for (int i = 0; i < 42; i++)
                pizza.Add(new Passenger(new FactoryPizza()));



            new Bus(new FactoryBus(), busPas);
            new Taxi(new FactoryTaxi(), taxiPas);
            new PizzaDelivery(new FactoryPizzaDelivery(), pizza);
            
            //Bus.onBoard(busPas);
            //Taxi.onBoard(taxiPas);


            Console.WriteLine("Amount of taxis:" + Taxi.countTaxi + "      "      + "Amount of buses:" + Bus.countBus + "       " + "Amount of delivery:" + PizzaDelivery.countPizzaDelivery);
        }
    }



    
    enum DriverLicenseType
    {
        B, C, A
    }
    class Driver
    {
       public DriverLicenseType driverLicenseType;
       public Driver(FactoryDriver factory)
       {
            driverLicenseType = factory.diverLicenseType();
       }
    }
    abstract class FactoryDriver
    {
        public abstract DriverLicenseType diverLicenseType();
    }

    class FactoryBusDriver : FactoryDriver
    {
        public override DriverLicenseType diverLicenseType()
        {
            return DriverLicenseType.C;
        }

    }
    class FactoryTaxiDriver : FactoryDriver
    {
        public override DriverLicenseType diverLicenseType()
        {
            return DriverLicenseType.B;
        }

    }

    class FactoryPizzaDriver : FactoryDriver
    {
        public override DriverLicenseType diverLicenseType()
        {
            return DriverLicenseType.A;
        }

    }

    //class BusDriver : Driver
    //{
    //   public BusDriver()
    //    {
    //        driverLicenseType = DriverLicenseType.C;
    //    }
    //}

    //class TaxiDriver : Driver
    //{
    //    public TaxiDriver()
    //    {
    //        driverLicenseType = DriverLicenseType.B;
    //    }
    //}



    enum PreferTransport
    {
        taxi, bus, pizzaDev
    }
     class Passenger
    {
        public PreferTransport preferTransport;

        public Passenger(FactoryPassenger factory)
        {
            preferTransport = factory.preferTransport();
        }


    }

    abstract class FactoryPassenger
    {
        public abstract PreferTransport preferTransport();
    }

    class FactoryBusPassenger : FactoryPassenger
    {
        public override PreferTransport preferTransport()
        {
            return PreferTransport.bus;
        }

    }
    class FactoryTaxiPassenger : FactoryPassenger
    {
        public override PreferTransport preferTransport()
        {
            return PreferTransport.taxi;
        }

    }
    class FactoryPizza : FactoryPassenger
    {
        public override PreferTransport preferTransport()
        {
            return PreferTransport.pizzaDev;
        }

    }
    //class BusPassenger: Passenger
    //{
    //    public BusPassenger()
    //    {
    //        preferTransport = PreferTransport.bus;
    //    }
    //}

    //class TaxiPassenger : Passenger
    //{
    //    public TaxiPassenger()
    //    {
    //        preferTransport = PreferTransport.taxi;
    //    }
    //}



    abstract class Car 
    {
        Driver driver;
        public List<Passenger> passengers = new List<Passenger>();

        public abstract void setDriver();
        public  abstract void onBoard(List<Passenger> passenger);
    }

     abstract class FactoryCar
    {
        public abstract Car createCar();
        
    }

    class Bus : Car
    {
        static List<Passenger> passengers = new List<Passenger>();
        public const int amountOfBusPassengers = 10;
        Driver busDriver;
        public static int countBus = 0;

        public Bus(FactoryBus factory , List<Passenger> passenger)
        {
            onBoard(passenger);
        }

        public Bus()
        {

        }
          override public void onBoard(List<Passenger> passenger)
        {
            int temp = passenger.Count();
            if (temp > amountOfBusPassengers)
            {
                for (int i = 0; i < amountOfBusPassengers; i++)
                {
                    passengers.Add(passenger[i]);
                }
                passenger.RemoveRange(0, amountOfBusPassengers);
                countBus++;
                onBoard(passenger);
            }
            else
            {
                for (int i = 0; i < passenger.Count; i++)
                    passengers.Add(passenger[i]);

                countBus++;
            }
        }

        public override void setDriver()
        {
            busDriver = new Driver(new FactoryBusDriver());
        }
    }

    class Taxi : Car
    {
        public const int amountOfTaxiPassengers = 4;
        static List<Passenger> passengers = new List<Passenger>();
        Driver taxiDriver;
        public static int countTaxi = 0;

        public override void setDriver()
        {
            taxiDriver = new Driver(new FactoryTaxiDriver());
        }

        public Taxi(FactoryTaxi factory, List<Passenger> passenger)
        {
            onBoard(passenger);
        }

        public Taxi() { }
        override public  void onBoard(List<Passenger> passenger)
        {
            int temp = passenger.Count();
            if (temp > amountOfTaxiPassengers)
            {
                for (int i = 0; i < amountOfTaxiPassengers; i++)
                {
                    passengers.Add(passenger[i]);
                    
                }
                passenger.RemoveRange(0, amountOfTaxiPassengers);
                countTaxi++;
                onBoard(passenger);
            }
            else
            {
                for (int i = 0; i < passenger.Count; i++)
                    passengers.Add(passenger[i]);

                countTaxi++;
            }
        }
    }


    class PizzaDelivery : Car
    {
        public const int amountOfPizza = 7;
        static List<Passenger> pizza = new List<Passenger>();
        Driver driver;
        public static int countPizzaDelivery = 0;

        public PizzaDelivery(FactoryPizzaDelivery factory, List<Passenger> passenger)
        {
            onBoard(passenger);
        }
        public override void setDriver()
        {
            driver = new Driver(new FactoryPizzaDriver());
        }
        public PizzaDelivery() { }
        override public void onBoard(List<Passenger> passenger)
        {
            int temp = passenger.Count();
            if (temp > amountOfPizza)
            {
                for (int i = 0; i < amountOfPizza; i++)
                {
                    pizza.Add(passenger[i]);

                }
                passenger.RemoveRange(0, amountOfPizza);
                countPizzaDelivery++;
                onBoard(passenger);
            }
            else
            {
                for (int i = 0; i < passenger.Count; i++)
                    pizza.Add(passenger[i]);

                countPizzaDelivery++;
            }
        }
    }
    class FactoryBus : FactoryCar
    {
        public override Car createCar()
        {
            return new Bus();
        }

    }

    class FactoryTaxi : FactoryCar
    {
        public override Car createCar()
        {
            return new Taxi();
        }

    }

    class FactoryPizzaDelivery : FactoryCar
    {
        public override Car createCar()
        {
            return new PizzaDelivery();
        }

    }
}
