using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    public class Car : Vehicle
    {
        private int horsePower;
        private SteeringWheelType steeringWheel;
        private int numberOfDoors;

        public Car(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
           int horsePower, SteeringWheelType steeringWheel, int numberOfDoors, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
            : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.steeringWheel = steeringWheel;
            this.numberOfDoors = numberOfDoors;
        }

        public Car(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
        int horsePower, SteeringWheelType steeringWheel, int numberOfDoors, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
          : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.horsePower = horsePower;
            this.steeringWheel = steeringWheel;
            this.numberOfDoors = numberOfDoors;
        }

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

        public int GetHorsePower
        {
            get { return horsePower; }
        }
        
        public SteeringWheelType GetSteeringWheel 
        { 
            get { return steeringWheel; } 
        }

        public int GetNumberOfDoors
        {
            get { return numberOfDoors; }
        }
    }
}
