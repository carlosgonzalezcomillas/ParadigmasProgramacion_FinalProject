using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PoliceStation : MonoBehaviour 
{
    private List<PoliceCar> policeCars;
    private string? lastAlert;

    public void RegisterPolice(PoliceCar policeCar)
    {
        policeCars.Add(policeCar);
        Console.WriteLine($"Police car {policeCar.GetPlate()}: has been registered");
    }

    public void TriggerAlert(string crimePlate)
    {
        lastAlert = crimePlate;
        Console.WriteLine($"Active alert for persecution of taxi: {crimePlate}");

        foreach (var policeCar in policeCars)
        {
            if (policeCar.IsPatrolling())
            {
                if (!policeCar.IsPersecuting())
                {
                    policeCar.StartPersecution(crimePlate);
                }
                 
            }
        }
    }

    public void ShowRegisteredPolice()
    {
        Console.WriteLine("Registered police cars: ");
        foreach (var police in policeCars)
        {
            Console.WriteLine(police.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        policeCars = new List<PoliceCar>();
        lastAlert = "";
    }

}
