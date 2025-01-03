using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRadar : MonoBehaviour
{
    public float legalSpeed = 20.0f;
    public PoliceCar policeCar;  
    private List<float> speedHistory = new List<float>();
    private IMessageWritter messageWritter = new MessageLogger();

    private void OnTriggerEnter(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle != null && vehicle.GetTypeOfVehicle() == "Taxi")
        {
            Taxi taxi = vehicle as Taxi;
            if (taxi != null)
            {
                float speed = taxi.GetSpeed();
                speedHistory.Add(speed);

                messageWritter.WriteMessage($"Vehicle {taxi.Plate} detected at {taxi.GetSpeed()} km/h. Speed history recorded.");

                if (speed > legalSpeed)
                {
                    messageWritter.WriteMessage($"Speeding detected: Vehicle {taxi.Plate} is over the legal limit of {legalSpeed} km/h.");
                    if (policeCar != null)
                    {
                        policeCar.StartPersecution(taxi.transform);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not found");
        }
    }

    public void ShowSpeedHistory()
    {
        foreach (float recordedSpeed in speedHistory)
        {
            messageWritter.WriteMessage($"Recorded Speed: {recordedSpeed} km/h");
        }
    }
}
