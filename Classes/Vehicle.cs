using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Logic_layer;
using Logic_layer.Enumerations;

namespace Classes
{
    /// <summary>
    /// Represents a generic Vehicle, which can be specialized into different vehicle types such as cars, trucks, or motorcycles.
    /// Contains common properties such as ID, price, engine, transmission, and other characteristics shared across all vehicles.
    /// </summary>
    public abstract class Vehicle
    {
        private int vehicleID;
        private Engine engine;
        private int price;
        private TransmissionType transmissionType;
        private string color;
        private DateTime yearOfProduction;
        private string brand;
        private string model;
        private Condition condition;
        private bool isBought;
        private bool isReserved;
        private int mileage;
        private DateTime publicationDate;
        private int averageRating;
        private string imageUrl;
        private string bodyType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class with a unique vehicle ID.
        /// </summary>
        public Vehicle(int vehicleID, int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
        {
            this.vehicleID = vehicleID;
            this.brand = brand;
            this.model = model;
            this.price = price;
            this.transmissionType = transmissionType;
            this.color = color;
            this.yearOfProduction = yearOfProduction;
            this.condition = condition;
            this.isBought = isBought;
            this.isReserved = isReserved;
            this.mileage = mileage;
            this.publicationDate = publicationDate;
            this.averageRating = averageRating;
            this.imageUrl = imageUrl;
            this.engine = engine;
            this.bodyType = bodyType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class without a vehicle ID.
        /// </summary>
        public Vehicle(int price, TransmissionType transmissionType, string color, DateTime yearOfProduction, string brand, string model, Condition condition, bool isBought, bool isReserved, int mileage, DateTime publicationDate, int averageRating, string imageUrl, Engine engine, string bodyType)
        {
            this.brand = brand;
            this.model = model;
            this.price = price;
            this.transmissionType = transmissionType;
            this.color = color;
            this.yearOfProduction = yearOfProduction;
            this.condition = condition;
            this.isBought = isBought;
            this.isReserved = isReserved;
            this.mileage = mileage;
            this.publicationDate = publicationDate;
            this.averageRating = averageRating;
            this.imageUrl = imageUrl;
            this.engine = engine;
            this.bodyType = bodyType;
        }

        /// <summary>
        /// Gets the average rating of the vehicle.
        /// </summary>
        public int GetAverageRating
        {
            get { return averageRating;}
        }

        /// <summary>
        /// Gets the image URL of the vehicle.
        /// </summary>
        public string GetImage
        {
            get { return imageUrl; }
        }

        /// <summary>
        /// Gets the price of the vehicle.
        /// </summary>
        public int GetPrice
        {
            get { return price; }
        }

        /// <summary>
        /// In case the customer negotiates the price, the seller has to know, the lowest
        /// price the chosen vehicle can be sold at. This abstract method to calculate the lowest price the vehicle can be sold for.
        /// </summary>
        /// <returns>The lowest possible price for the vehicle.</returns>
        public abstract double LowestPriceVehicleCanGo();

        /// <summary>
        /// Gets the body type of the vehicle (e.g., sedan, SUV, etc.).
        /// </summary>
        public string GetBodyType
        {
            get { return bodyType;}
        }

        /// <summary>
        /// Gets a string combining the vehicle ID, brand, and model.
        /// </summary>
        public string GetIDBrandAndModel
        {
            get{ return $"{vehicleID} - {brand} {model}"; }
        }

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public int GetVehicleId
        {
            get { return vehicleID; }
        }

        /// <summary>
        /// Gets the year the vehicle was produced.
        /// </summary>
        public DateTime GetYearOfProduction
        {
            get { return yearOfProduction; }
        }

        /// <summary>
        /// Gets the engine details of the vehicle.
        /// </summary>
        public Engine GetEngine
        {
            get { return engine; }
        }

        /// <summary>
        /// Gets the mileage of the vehicle.
        /// </summary>
        public int GetMileage
        {
            get { return mileage; }
        }

        /// <summary>
        /// Gets the color of the vehicle.
        /// </summary>
        public string GetColor
        { 
            get { return color; } 
        }

        /// <summary>
        /// Gets the transmission type of the vehicle (manual, automatic, etc.).
        /// </summary>
        public TransmissionType GetTransmissionType
        {
            get { return  transmissionType; }
        }

        /// <summary>
        /// Gets the condition of the vehicle (new, used, etc.).
        /// </summary>
        public Condition GetCondition
        {
            get { return condition; }
        }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string GetBrand
        {
            get { return brand; }
        }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string GetModel
        {
            get { return model; }
        }

        /// <summary>
        /// Gets whether the vehicle is reserved.
        /// </summary>
        public bool GetIsReserved
        {
            get { return isReserved; }
        }

        /// <summary>
        /// Gets the publication date of the vehicle listing.
        /// </summary>
        public DateTime GetPublicationDate 
        { 
            get { return publicationDate; } 
        }

        /// <summary>
        /// Gets whether the vehicle has been bought.
        /// </summary>
        public bool GetIsBought
        {
            get { return isBought; }
        }
    }
}
