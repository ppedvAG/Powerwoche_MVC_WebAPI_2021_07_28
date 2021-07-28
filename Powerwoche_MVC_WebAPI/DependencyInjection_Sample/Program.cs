using System;

namespace DependencyInjection_Sample
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ICar car = new Car();
    //        ICarService service = new CarService();
    //        service.Repair(car);
    //    }
    //}

    #region alter Stil 
    public class BadCar //5 Tage
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public DateTime BauDatum { get; set; }
    }

    public class BadCarService // 3 Tage 
    {
        public void Repair (BadCar car)
        {
            //Mach was
        }
    }
    #endregion

    #region
    public interface ICar // Mit C# 8.0 Interface - Features 
    {
        public string Marke { get; set; }
        string Modell { get; set; }
        DateTime BauDatum { get; set; }

        void Hallo1();
        abstract void Hallo();

        public void Hello2()
        {

        }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }


    public class Car : ICar // 5Tage 
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public DateTime BauDatum { get; set; }

        public void Hallo()
        {
            throw new NotImplementedException();
        }

        public void Hallo1()
        {
            throw new NotImplementedException();
        }
    }


    public class CarService : ICarService // 3Tage 
    {
        public void Repair(ICar car) //NAch  3 Tagen ein Funktionstest bitte
        {
            //Mach was 
        }
    }

    public class MockCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "POLO";
        public DateTime BauDatum { get; set; } = DateTime.Now;

        public void Hallo()
        {
            throw new NotImplementedException();
        }

        public void Hallo1()
        {
            throw new NotImplementedException();
        }
    }

    #endregion


}
