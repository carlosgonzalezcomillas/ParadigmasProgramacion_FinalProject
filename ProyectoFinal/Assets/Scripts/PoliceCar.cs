using System;

public class PoliceCar : Vehicle
{
    //constant string as TypeOfVehicle wont change allong PoliceCar instances 
    private bool isPatrolling;
    private bool isPersecuting;
    private SpeedRadar? speedRadar;

    public void AssignRadar(SpeedRadar radar)
    {
        speedRadar = radar;
        Console.WriteLine(WriteMessage("Radar assigned."));
    }

    public void UseRadar(Vehicle vehicle)
    {
        if (isPatrolling)
        {
            if (speedRadar != null)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                float speed = speedRadar.GetLastSpeed();

                string taxiPlate = speedRadar.PersecuteTaxi();
                if (taxiPlate != "")
                {
                    StartPersecution(taxiPlate);
                }
            }
            else 
            {
                Console.WriteLine(WriteMessage("has no radar assigned."));
            }
        }
        else
        {
            Console.WriteLine(WriteMessage("has no active radar, is not patrolling."));
        }
    }

    public bool IsPatrolling()
    {
        return isPatrolling;
    }

    public bool IsPersecuting()
    {
        return isPersecuting;
    }

    public void StartPatrolling()
    {
        if (!isPatrolling)
        {
            isPatrolling = true;
            Console.WriteLine(WriteMessage("started patrolling."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is already patrolling."));
        }
    }

    public void EndPatrolling()
    {
        if (isPatrolling)
        {
            isPatrolling = false;
            Console.WriteLine(WriteMessage("stopped patrolling."));
        }
        else
        {
            Console.WriteLine(WriteMessage("was not patrolling."));
        }
    }

    public void StartPersecution(string crimePlate)
    {
        if (!isPersecuting)
        {
            isPersecuting = true;
            Console.WriteLine(WriteMessage($"is persecuting taxi {crimePlate}"));
        }
        else if (isPersecuting)
        {
            Console.WriteLine(WriteMessage($"was already in a persecution"));
        }
    }

    public void PrintRadarHistory()
    {
        if (speedRadar != null)
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
        else
        {
            Console.WriteLine(WriteMessage("has no radar to report from."));
        }
    }

    protected override void Start()
    {
        SetTypeOfVehicle("Police Car");
        SetPlate("CNP 001"); 
        SetSpeed(50.0f);
        base.Start();
    }
}
