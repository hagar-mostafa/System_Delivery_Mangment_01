using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
#nullable disable
internal class Program
{
   #region  DeliveryAddress struct
    public struct DeliveryAddress
    {

        private string City;
        private string Street;
        private int BuildingNumber;
        public DeliveryAddress(string City, string Street, int BuildingNumber)
        {
            this.City = City;
            this.Street = Street;
            this.BuildingNumber = BuildingNumber;
        }
        public string GetFullAddress()
        {
            return $"The address {City}, {Street}, {BuildingNumber}";
        }
    }
    #endregion


    #region  Shipment struct
    struct Shipment
    {
        private string _TrackingCode;
        public string TrackingCode
        {
            get
            { return _TrackingCode; }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _Description = value;
            }
        }
        private double _Weight;
        public double Weight
        {
            get { return _Weight; }
            set
            {
                if (value > 0)
                    _Weight = value;
            }
        }
        private double _DeliveryFee;
        public double DeliveryFee
        {
            get { return _DeliveryFee; }
            private set
            {
                if (value > 0)
                    _DeliveryFee = value;
            }

        }
        private DeliveryAddress _Destination;
        public DeliveryAddress Destination
        {
            get
            { return _Destination; }

            set
            { _Destination = value; }

        }
        // computed property
        public double EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }


        public Shipment(string trackingCode)
        {
            if (!string.IsNullOrWhiteSpace(trackingCode))
                _TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
        }
        //------constructor overloading-----
        public Shipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination)
        {
            if (!string.IsNullOrWhiteSpace(trackingCode))
                _TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }
        public void UpdateDeliveryFee(double newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }
        public void PrintShipment()
        {
            Console.WriteLine("This Shipment struct include the Following : ");
            Console.WriteLine($"Tracking Code is => {_TrackingCode}");
            Console.WriteLine($"The Description is => {Description}");
            Console.WriteLine($"The Weight is = {Weight}");
            Console.WriteLine($"The DeliveryFee is => {DeliveryFee}");
            Console.WriteLine($"The Destination is => {Destination.GetFullAddress()}");
            Console.WriteLine($"The EstimateCost is => {EstimatedCost}");
        }
    }
    #endregion

    #region DeliveryCenter struct
    // Sorry I can't Do , in my group we didn't take indexers 
    #endregion

    static void Main(string[] args)
    {
       #region Part 01 : Theoretical Questions

        //-------------------------Question 1------------------------------
        //A. The original variable not changed because struct is a value type => sperate copy 
        //B. The original variable will be changed because class is reference type => they refer to the same object

        //-------------------------Question 2------------------------------
        //A. 1) User can set invalid or unsafe values
        //   2) Implementation details are exposed
        //   3) Difficult to change in the future
        //   4) leads to bugs and data corruption

        //B. 1)Private fields hide the internal data from direct access by users
        //   2)Easier to maintain and modify
        //   3)Public properties provide controlled access to the fields.
        // And that is the benefit of Encapsulation
        #endregion

       #region DeliveryAddress struct 
        DeliveryAddress add1 = new DeliveryAddress("Nasr City", "Abas Elaqad", 4);
        DeliveryAddress copyadd1;
        copyadd1 = add1;
        Console.WriteLine($"The original address is : {add1.GetFullAddress()}");
        Console.WriteLine($"The Copy address is : {copyadd1.GetFullAddress()}");
        copyadd1 = new DeliveryAddress("El Obour", "3rd street", 5);
        Console.WriteLine($"The original address again is : {add1.GetFullAddress()}");
        Console.WriteLine($"The Copy address is again : {copyadd1.GetFullAddress()}");
        #endregion


    }

}





