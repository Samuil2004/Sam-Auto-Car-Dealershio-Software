using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Logic_layer;
using Logic_layer.Enumerations;

namespace Classes
{
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

        public int GetAverageRating
        {
            get { return averageRating;}
        }

        public string GetImage
        {
            get { return imageUrl; }
        }

        public int GetPrice
        {
            get { return price; }
        }

        public abstract double LowestPriceVehicleCanGo();


        public string GetBodyType
        {
            get { return bodyType;}
        }

        public string GetIDBrandAndModel
        {
            get{ return $"{vehicleID} - {brand} {model}"; }
        }
        public int GetVehicleId
        {
            get { return vehicleID; }
        }
        public DateTime GetYearOfProduction
        {
            get { return yearOfProduction; }
        }
        public Engine GetEngine
        {
            get { return engine; }
        }
        public int GetMileage
        {
            get { return mileage; }
        }
        public string GetColor
        { 
            get { return color; } 
        }
        public TransmissionType GetTransmissionType
        {
            get { return  transmissionType; }
        }
        public Condition GetCondition
        {
            get { return condition; }
        }
        public string GetBrand
        {
            get { return brand; }
        }
        public string GetModel
        {
            get { return model; }
        }
        public bool GetIsReserved
        {
            get { return isReserved; }
        }
        public DateTime GetPublicationDate 
        { 
            get { return publicationDate; } 
        }
        public bool GetIsBought
        {
            get { return isBought; }
        }
    }
}
