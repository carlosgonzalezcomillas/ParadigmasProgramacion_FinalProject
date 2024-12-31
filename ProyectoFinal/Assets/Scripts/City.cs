using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class City : MonoBehaviour
{
    private PoliceStation policeStation;
    private List<Taxi> taxisRegistered;


    public void RegisterTaxiLicense(Taxi taxi)
    {
        taxisRegistered.Add(taxi);
        Console.WriteLine($"Taxi {taxi.GetPlate()}: has been registered");
    }

    public void RemoveTaxiLicense(string plate)
    {
        taxisRegistered.RemoveAll(taxi => taxi.GetPlate() == plate);
        Console.WriteLine($"Taxi {plate}: has been removed");
    }

    public void ShowRegisteredTaxis()
    {
        Console.WriteLine("Registered taxis in the city: ");
        foreach (var taxi in taxisRegistered)
        {
            Console.WriteLine($"{taxi.GetPlate()}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        policeStation = new PoliceStation();
        taxisRegistered = new List<Taxi>();
    }

}

