using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDemo
{
    public interface IVehicle
    {
        void Drive();
    }
    public class Car : IVehicle
    {
        public void Drive() => Console.WriteLine("Driving a car");
    }

    public class Bike : IVehicle
    {
        public void Drive() => Console.WriteLine("Riding a bike");
    }
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
        public void StartJourney()
        {
            var vehicle = CreateVehicle();
            vehicle.Drive();
        }
    }
    public class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }
    public class BikeFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Bike();
        }
    }
}
