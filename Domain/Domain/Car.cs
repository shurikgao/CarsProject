﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Domain.Decorator;
using Domain.Domain.Observer;
using Domain.Domain.Proxy;
using Domain.Domain.TemplateMethod;

namespace Domain.Domain
{
    public class Car : Entity, ITuning, IStartAirConditioner
    {
        private readonly IList<Driver> _drivers = new List<Driver>();
        private readonly IList<Service> _services = new List<Service>();
        private readonly IList<Tuning> _tunings = new List<Tuning>();
        protected IRdsSubscriber _receiver;
        protected bool Lights;

        public Car(string brand, string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name is required.");
            if (engineVol <= 0)
                throw new ArgumentException("engineVol must be > 0.");
            if (tankVol <= 0)
                throw new ArgumentException("TankVol must be > 0.");
            if (!bodyType.Any())
                throw new ArgumentException("Assign bodyType to a car.");
            if (!countryOfOrigin.Any())
                throw new ArgumentException("Assign countryOfOrigin to a car.");

            Brand = brand;
            Name = name;
            EngineVol = engineVol;
            TankVol = tankVol;
            BodyType = bodyType;
            CountryOfOrigin = countryOfOrigin;
            _receiver = new RdsReceiver(name);
        }

        [Obsolete]
        protected Car()
        {
        }

        public virtual IRdsSubscriber Receiver
        {
            get { return _receiver; }
        }

        public virtual RegistrationPlate Plate { get; set; }

        public virtual IList<Service> Services
        {
            get { return _services; }
        }

        public virtual IList<Tuning> Tunings
        {
            get { return _tunings; }
        }

        public virtual IList<Driver> Drivers
        {
            get { return _drivers; }
        }

        public virtual bool CheckStstem
        {
            get { return SystemOk; }
            set { SystemOk = value; }
        }

        public virtual bool lights // property encapsulated
        {
            get { return Lights; } // _lights = field
            set { Lights = value; }
        }

        public virtual bool EngineIsStarted // readonly
        { get; protected set;
            //set { _make = value; }
        }

        public virtual void StartAirConditioner()
        {
            CheckAllSystem();
            StartEngine();
            CloseWindows();
            Console.WriteLine("AirConditioner is working. t=20°");
        }

        public virtual void AddTuning()
        {
            Console.WriteLine(new string('+', 10));
            Console.WriteLine("Car " + Brand + " " + Name + " ready for tune");
        }

        public virtual bool GetSystemStatus()
        {
            return SystemOk;
        }

        public virtual bool GetBattStatus()
        {
            return true;
        }

        public virtual void SetBattStatus(bool value)
        {
            BattOk = value;
        }

        public virtual void CheckAllSystem()
        {
            if (GetBattStatus() /* && tirePressure>2*/)
                SystemOk = true;
            else
                SystemOk = false;
        }

        public virtual void StartEngine()
        {
            if (SystemOk)
            {
                EngineIsStarted = true;
            }
            else
            {
                EngineIsStarted = false;
                Console.WriteLine("You have problems. Need service");
            }
        }

        public override string ToString()
        {
            return "Car:" + Brand + " " + Name + " " + BodyType + " / engine: " + EngineIsStarted + " / lights:" +
                   lights;
        }

        protected virtual void CloseWindows()
        {
            Console.WriteLine(Brand + " " + Name + "  All Windows are closed");
        }

        public virtual void Drive()
        {
            Console.WriteLine("{0,-20} Let`s Go - o - o -o -o.", DriverProxy.Name);
        }

        #region Fields

        public virtual bool SystemOk { get; set; }
        public virtual bool BattOk { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Name { get; protected set; }
        public virtual int EngineVol { get; protected set; }
        public virtual int TankVol { get; protected set; }
        public virtual string BodyType { get; protected set; }
        public virtual string CountryOfOrigin { get; protected set; }

        #endregion
    }
}