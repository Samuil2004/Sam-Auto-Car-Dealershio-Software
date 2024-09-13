using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    public class Truck : Vehicle
    {
        private int horsePower;
        private int numOfAxles;
        private int playloadCapacity;
        private SteeringWheelType steeringWheel;

        public Truck(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
            int horsePower, int numOfAxles, int payloadCapacity, SteeringWheelType steeringWheel, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
           : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.numOfAxles = numOfAxles;
            this.playloadCapacity = payloadCapacity;
            this.steeringWheel = steeringWheel;
        }

        public Truck(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
            int horsePower, int numOfAxles, int payloadCapacity, SteeringWheelType steeringWheel, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
           : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.numOfAxles = numOfAxles;
            this.playloadCapacity = payloadCapacity;
            this.steeringWheel = steeringWheel;
        }

        public override double LowestPriceVehicleCanGo()
        {
            if (GetBodyType.Equals("Crane") || GetBodyType.Equals("Concrete") || GetBodyType.Equals("Box") || GetBodyType.Equals("Fire") || GetBodyType.Equals("Garbage") || GetBodyType.Equals("Pickup"))
            {
                if (GetMileage < 100000 && GetMileage > 10000)
                {
                    return GetPrice * 0.95;
                }
                if (GetMileage < 150000 && GetMileage >= 100000)
                {
                    return GetPrice * 0.9;
                }
                if (GetMileage >= 150000)
                {
                    return GetPrice * 0.85;
                }
            }
            else
            {
                if (GetMileage < 500000 && GetMileage > 100000)
                {
                    return GetPrice * 0.95;
                }
                if (GetMileage < 1000000 && GetMileage >= 500000)
                {
                    return GetPrice * 0.9;
                }
                if (GetMileage >= 1000000)
                {
                    return GetPrice * 0.85;
                }
            }
            return GetPrice;
        }

        public int GetPlayLoadCapacity
        {
            get { return playloadCapacity; }
        }
        public int GetNumberOfAxles
        {
            get { return numOfAxles; }
        }
        public int GetHorsePower
        {
            get { return horsePower; }
        }
        public SteeringWheelType GetSteeeringWheelType
        {
            get { return steeringWheel; }
        }
    }
}


