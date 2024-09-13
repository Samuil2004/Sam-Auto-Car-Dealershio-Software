using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer.Enumerations;

namespace Classes
{
    /// <summary>
    /// Represents a motorcycle, a type of vehicle with properties such as cubic capacity, windshield, and storage box availability.
    /// Inherits from the abstract <see cref="Vehicle"/> class.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        private int cubicCapacity;
        private bool hasWindShield;
        private bool hasABox;

        /// <summary>
        /// Initializes a new instance of the <see cref="Motorcycle"/> class with a unique vehicle ID.
        /// </summary>
        public Motorcycle(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
                  int cubicCapacity, int mileage, bool hasWindShield, bool hasABox, DateTime publicationDate, int averageRating, string imageUrl, Engine engine,string bodyType)
                  : base(vehicleID, price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.cubicCapacity = cubicCapacity;
            this.hasWindShield = hasWindShield;
            this.hasABox = hasABox;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Motorcycle"/> class without a vehicle ID.
        /// </summary>
        public Motorcycle(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved,
                  int cubicCapacity, int mileage, bool hasWindShield, bool hasABox, DateTime publicationDate, int averageRating, string imageUrl, Engine engine,string bodyType)
                  : base(price, transmissionType, color, yearOfProduction, brand, model, condition, isBought, isReserved, mileage, publicationDate, averageRating, imageUrl, engine, bodyType)
        {
            this.cubicCapacity = cubicCapacity;
            this.hasWindShield = hasWindShield;
            this.hasABox = hasABox;
        }

        /// <summary>
        /// In case the customer negotiates the price, the seller has to know, the lowest
        /// price the chosen vehicle can be sold at. This method Calculates the lowest price
        /// the motorcycle can be sold for, based on its mileage and body type.
        /// </summary>
        /// <returns>The lowest possible price for the motorcycle.</returns>
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

        /// <summary>
        /// Gets the cubic capacity (engine displacement) of the motorcycle.
        /// </summary>
        public int GetCubicCapacity
        {
            get { return cubicCapacity; }
        }

        /// <summary>
        /// Indicates if the motorcycle has a windshield.
        /// </summary>
        public bool GetHasWindShield
        {
            get { return hasWindShield; }
        }

        /// <summary>
        /// Indicates if the motorcycle has a storage box.
        /// </summary>
        public bool GetHasABox
        {
            get { return hasABox; }
        }
    }
}
