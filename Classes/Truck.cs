using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    /// <summary>
    /// Represents a truck, a specialized type of vehicle with additional properties such as horsepower, number of axles, payload capacity, and steering wheel type.
    /// Inherits from the abstract <see cref="Vehicle"/> class.
    /// </summary>
    public class Truck : Vehicle
    {
        private int horsePower;
        private int numOfAxles;
        private int playloadCapacity;
        private SteeringWheelType steeringWheel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Truck"/> class with a unique vehicle ID.
        /// </summary>
        public Truck(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
            int horsePower, int numOfAxles, int payloadCapacity, SteeringWheelType steeringWheel, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
           : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.numOfAxles = numOfAxles;
            this.playloadCapacity = payloadCapacity;
            this.steeringWheel = steeringWheel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Truck"/> class without a vehicle ID.
        /// </summary>
        public Truck(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
            int horsePower, int numOfAxles, int payloadCapacity, SteeringWheelType steeringWheel, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
           : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.numOfAxles = numOfAxles;
            this.playloadCapacity = payloadCapacity;
            this.steeringWheel = steeringWheel;
        }

        /// <summary>
        /// In case the customer negotiates the price, the seller has to know, the lowest
        /// price the chosen vehicle can be sold at. This method calculates the lowest price 
        /// the truck can be sold for, based on its mileage and body type.
        /// </summary>
        /// <returns>The lowest possible price for the truck.</returns>
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

        /// <summary>
        /// Gets the payload capacity of the truck.
        /// </summary>
        public int GetPlayLoadCapacity
        {
            get { return playloadCapacity; }
        }

        /// <summary>
        /// Gets the number of axles on the truck.
        /// </summary>
        public int GetNumberOfAxles
        {
            get { return numOfAxles; }
        }

        /// <summary>
        /// Gets the horsepower of the truck.
        /// </summary>
        public int GetHorsePower
        {
            get { return horsePower; }
        }

        /// <summary>
        /// Gets the steering wheel type of the truck (left-hand or right-hand drive).
        /// </summary>
        public SteeringWheelType GetSteeeringWheelType
        {
            get { return steeringWheel; }
        }
    }
}


