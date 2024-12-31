using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    [SerializeField] private string typeOfVehicle;
    [SerializeField] private string plate;
    [SerializeField] private float speed;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float groundCheckDistance = 1.0f; 
    [SerializeField] protected LayerMask groundLayer; 

    public string TypeOfVehicle => typeOfVehicle;
    public string Plate => plate ?? string.Empty;
    public float Speed => speed;

    //Override ToString() method with class information
    public override string ToString()
    {
        return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
    }

    public string GetTypeOfVehicle()
    {
        return typeOfVehicle;
    }

    public string GetPlate()
    {
        return plate != null ? plate : "";
    }


    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetTypeOfVehicle(string type)
    {
        typeOfVehicle = type;
    }

    public void SetPlate(string plate)
    {
        this.plate = plate;
    }

    //Implment interface with Vechicle message structure
    public virtual string WriteMessage(string message)
    {
        return $"{this}: {message}";
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance, groundLayer);
    }
}
