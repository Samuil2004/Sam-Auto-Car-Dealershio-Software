using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    /// <summary>
    /// Represents a Car, which is a type of Vehicle.
    /// Contains properties specific to cars such as horse power, steering wheel type, and number of doors.
    /// Inherits from the abstract <see cref="Vehicle"/> class.
    /// </summary>
    public class Car : Vehicle
    {
        private int horsePower;
        private SteeringWheelType steeringWheel;
        private int numberOfDoors;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with all properties, including vehicle ID.
        /// </summary>
        public Car(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
           int horsePower, SteeringWheelType steeringWheel, int numberOfDoors, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
            : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.steeringWheel = steeringWheel;
            this.numberOfDoors = numberOfDoors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class without specifying a vehicle ID.
        /// </summary>
        public Car(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
        int horsePower, SteeringWheelType steeringWheel, int numberOfDoors, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
          : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.steeringWheel = steeringWheel;
            this.numberOfDoors = numberOfDoors;
        }

        /// <summary>
        /// In case the customer negotiates the price, the seller has to know, the lowest
        /// price the chosen vehicle can be sold at. This method calculates the lowest price 
        /// the car can be sold for, based on its mileage.
        /// </summary>
        /// <returns>The lowest possible price for the car.</returns>
        public override double LowestPriceVehicleCanGo()
        {
            if (GetMileage < 30000 && GetMileage > 10000)
            {
                return GetPrice * 0.95;
            }
            if (GetMileage < 100000 && GetMileage >= 30000)
            {
                return GetPrice * 0.9;
            }
            if (GetMileage >= 100000)
            {
                return GetPrice * 0.85;
            }
            return GetPrice;
        }

        /// <summary>
        /// Gets the horsepower of the car.
        /// </summary>
        public int GetHorsePower
        {
            get { return horsePower; }
        }

        /// <summary>
        /// Gets the steering wheel type of the car.
        /// </summary>
        public SteeringWheelType GetSteeringWheel 
        { 
            get { return steeringWheel; } 
        }

        /// <summary>
        /// Gets the number of doors on the car.
        /// </summary>
        public int GetNumberOfDoors
        {
            get { return numberOfDoors; }
        }
    }
}
