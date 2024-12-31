using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRadar : MonoBehaviour, IMessageWritter
{
    //Radar doesn't know about Vechicles, just speed and plates
    public string plate = "";
    public float lastSpeed = 0f;
    public float legalSpeed = 50.0f;
    public List<float> SpeedHistory { get; private set; }

    public void TriggerRadar(Vehicle vehicle)
    {
        plate = vehicle.GetPlate();
        lastSpeed = vehicle.GetSpeed();
        SpeedHistory.Add(lastSpeed);
    }
        
    public string GetLastReading()
    {
        if (lastSpeed > legalSpeed)
        {
            return WriteMessage("Catched above legal speed.");
        }
        else
        {
            return WriteMessage("Driving legally.");
        }
    }

    public string PersecuteTaxi()
    {
        if (lastSpeed > legalSpeed)
        {
            return plate;
        }

        else
        {
            return "";
        }
    }

    public float GetLastSpeed()
    {
        return lastSpeed;
    }

    public virtual string WriteMessage(string radarReading)
    {
        return $"Vehicle with plate {plate} at {lastSpeed.ToString()} km/h. {radarReading}";
    }
}
