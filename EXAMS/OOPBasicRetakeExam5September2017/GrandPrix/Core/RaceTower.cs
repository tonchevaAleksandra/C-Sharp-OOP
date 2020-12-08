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
    private Weather weather;
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.crashedDrivers = new Stack<Driver>();
        this.weather = Weather.Sunny;

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

        if (this.drivers.Any(d => d.Name == driverName))
        {
            Driver driver = this.drivers.FirstOrDefault(d => d.Name == driverName);
            driver.AddBoxTimeToTotal();
            if (reasonToBox == "Refuel")
            {
                double fuelamount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelamount);

            }
            else if (reasonToBox == "ChangeTyres")
            {
                string tyreType = commandArgs[2];
                double hardness = double.Parse(commandArgs[3]);
                double grid = 0;
                if (tyreType == "Ultrasoft")
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
        StringBuilder sb = new StringBuilder();
        try
        {
            if (laps > this.lapsNumber - this.currentLap)
            {
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
            }
        }
        catch (Exception em)
        {

            return em.Message;
        }

        for (int i = 0; i < laps; i++)
        {
            if(this.IsRaceOver())
            {
                break;
            }
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
            string  output = this.Overtaking();
            sb.AppendLine(output);

        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");

        List<Driver> racingDrivers = this.drivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.crashedDrivers)
            .ToList();

        for (int i = 0; i < racingDrivers.Count; i++)
        {
            Driver currentDriver = racingDrivers[i];
            sb.AppendLine($"{i + 1} {currentDriver.Name} {currentDriver.Status}");
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherString = commandArgs[0];
        Enum.TryParse(weatherString, out Weather currentWeather);
        this.weather = currentWeather;
    }

    public string GetWinner()
    {
        Driver winner = this.drivers
            .OrderBy(x => x.TotalTime)
            .First();

        return $"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.";
    }

    public bool IsRaceOver()
    {
        return this.currentLap == this.lapsNumber;
    }
    private void Failed(Driver driver, string failureReason)
    {
        this.drivers.Remove(driver);
        driver.FailureReason = failureReason;
        driver.IsRacing = false;
        this.crashedDrivers.Push(driver);
    }

    private string Overtaking()
    {
        StringBuilder sb = new StringBuilder();
        List<Driver> sortedDrivers = this.drivers
            .OrderByDescending(d => d.TotalTime)
            .ToList();

        double overtakingInterval = 2;

        for (int i = 0; i < sortedDrivers.Count-1; i++)
        {
            Driver currentDriver = sortedDrivers[i];
            Driver nextDriver = sortedDrivers[i + 1];
            bool isOvertakeSucceed = false;

            double diffTime = currentDriver.TotalTime - nextDriver.TotalTime;

            bool isArgessiveDriver, isEnduranceDriver, willCrash;

            CheckForPossibleCrash(currentDriver, out isArgessiveDriver, out isEnduranceDriver, out willCrash);

            if ((isArgessiveDriver || isEnduranceDriver) && diffTime <= 3)
            {
                if (willCrash)
                {
                    this.Failed(currentDriver, "Crashed");
                    currentDriver.IsRacing = false;
                    continue;
                }

                isOvertakeSucceed = true;
                overtakingInterval = 3;

            }
            else if (diffTime <= 2)
            {
                isOvertakeSucceed = true;
            }

            if (isOvertakeSucceed)
            {
                currentDriver.TotalTime -= overtakingInterval;
                nextDriver.TotalTime += overtakingInterval;
                sb.AppendLine($"{currentDriver.Name} has overtaken {nextDriver.Name} on lap {this.currentLap}.");
                i++;
            }
        }

        return sb.ToString().Trim();
    }

    private void CheckForPossibleCrash(Driver currentDriver, out bool isArgessiveDriver, out bool isEnduranceDriver, out bool willCrash)
    {
        isArgessiveDriver = currentDriver is AggressiveDriver && currentDriver.Car.Tyre is UltrasoftTyre;
        isEnduranceDriver = currentDriver is EnduranceDriver && currentDriver.Car.Tyre is HardTyre;
        willCrash = (isArgessiveDriver && this.weather == Weather.Foggy) || (isEnduranceDriver && this.weather == Weather.Rainy);
    }

}

