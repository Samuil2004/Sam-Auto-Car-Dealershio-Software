using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    public class Motorcycle : Vehicle
    {
        private int cubicCapacity;
        private bool hasWindShield;
        private bool hasABox;

        public Motorcycle(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
                  int cubicCapacity, int mileage, bool hasWindShield, bool hasABox, DateTime publicationDate, int averageRating, string imageUrl, Engine engine,string bodyType)
                  : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.cubicCapacity = cubicCapacity;
            this.hasWindShield = hasWindShield;
            this.hasABox = hasABox;
        }

        public Motorcycle(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
                  int cubicCapacity, int mileage, bool hasWindShield, bool hasABox, DateTime publicationDate, int averageRating, string imageUrl, Engine engine,string bodyType)
                  : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.cubicCapacity = cubicCapacity;
            this.hasWindShield = hasWindShield;
            this.hasABox = hasABox;
        }

        public override double LowestPriceVehicleCanGo()
        {
            if (GetBodyType.Equals("Off_Road") || GetBodyType.Equals("Scooter") || GetBodyType.Equals("Sport"))
            {
                if (GetMileage < 10000 && GetMileage > 2000)
                {
                    return GetPrice * 0.95;
                }
                if (GetMileage < 15000 && GetMileage >= 10000)
                {
                    return GetPrice * 0.9;
                }
                if (GetMileage >= 15000)
                {
                    return GetPrice * 0.85;
                }
            }
            else
            {
                if (GetMileage < 15000 && GetMileage > 500)
                {
                    return GetPrice * 0.95;
                }
                if (GetMileage < 25000 && GetMileage >= 15000)
                {
                    return GetPrice * 0.9;
                }
                if (GetMileage >= 25000)
                {
                    return GetPrice * 0.85;
                }
            }
            return GetPrice;
        }

        public int GetCubicCapacity
        {
            get { return cubicCapacity; }
        }

        public bool GetHasWindShield
        {
            get { return hasWindShield; }
        }
        public bool GetHasABox
        {
            get { return hasABox; }
        }
    }
}
