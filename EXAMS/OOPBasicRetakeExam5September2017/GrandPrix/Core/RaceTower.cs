using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{
    private int lapsNumber;
    private int trackLength;
    private List<Driver> drivers;
    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;
    private int currentLap;
    private Stack<Driver> crashedDrivers;
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.crashedDrivers = new Stack<Driver>();

    }
    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string typeDriver = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);
            double grip = 0;
            if (commandArgs.Count > 6)
            {
                grip = double.Parse(commandArgs[6]);
            }

            Tyre tyre = this.tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
            Car car = new Car(hp, fuelAmount, tyre);
            Driver driver = this.driverFactory.CreateDriver(typeDriver, name, car);

            this.drivers.Add(driver);
        }
        catch
        {
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];
   
        if(this.drivers.Any(d=>d.Name==driverName))
        {
            Driver driver = this.drivers.FirstOrDefault(d => d.Name == driverName);
            if(reasonToBox=="Refuel")
            {
                double fuelamount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelamount);
                
            }
            else if(reasonToBox== "ChangeTyres")
            {
                string tyreType = commandArgs[2];
                double hardness = double.Parse(commandArgs[3]);
                double grid = 0;
                if(tyreType=="Ultrasoft")
                {
                    grid = double.Parse(commandArgs[4]);
                }

                Tyre tyre = this.tyreFactory.CreateTyre(tyreType, hardness, grid);
                driver.Car.ChageTyre(tyre);
            }
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int laps = int.Parse(commandArgs[0]);

        try
        {
            if (laps > this.lapsNumber - this.currentLap)
            {
                throw new ArgumentException($"There is no time! On lap {this.lapsNumber - this.currentLap}.");
            }
        }
        catch (Exception em)
        {

            return em.Message;
        }

        for (int i = 0; i < laps; i++)
        {

            for (int j = 0; j < this.drivers.Count; j++)
            {
                Driver driver = this.drivers[j];
                try
                {
                    driver.TotalTimeIncreaser(this.trackLength);
                    driver.Car.FuelReducer(this.trackLength, driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (Exception em)
                {
                    this.Failed(driver, em.Message);
                    j--;
                }
            }



            this.currentLap++;
        }


    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");

        List<Driver> racingDrivers = this.drivers.OrderBy(d => d.TotalTime).ToList();

        for (int i = 0; i < racingDrivers.Count; i++)
        {
            Driver currentDriver = racingDrivers[i];
            sb.AppendLine($"{i + 1} {currentDriver.Name} {currentDriver.Status}");
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    private void Failed(Driver driver, string failureReason)
    {
        this.drivers.Remove(driver);
        driver.FailureReason = failureReason;
        driver.IsRacing = false;
        this.crashedDrivers.Push(driver);
    }

}

