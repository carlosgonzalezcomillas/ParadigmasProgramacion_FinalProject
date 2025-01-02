using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taxi : Vehicle
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private bool isCarryingPassengers;
    [SerializeField] private int health = 1000;  // Vida inicial del taxi

    private void Awake()
    {
        base.Start();
        SetSpeed(20f);  // Configuración de la velocidad predeterminada específica para Taxi
    }

    public void StartRide()
    {
        if (!isCarryingPassengers)
        {
            isCarryingPassengers = true;
            SetSpeed(100.0f);  // Aumentar la velocidad cuando lleva pasajeros
            Console.WriteLine(WriteMessage("starts a ride."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is already in a ride."));
        }
    }

    public void StopRide()
    {
        if (isCarryingPassengers)
        {
            isCarryingPassengers = false;
            SetSpeed(45.0f);  // Reducir la velocidad cuando no lleva pasajeros
            Console.WriteLine(WriteMessage("finishes ride."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is not on a ride."));
        }
    }

    void Update()
    {
        if (IsGrounded())
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Calcular movimiento y rotación
            Vector3 movement = transform.forward * moveVertical * Speed;
            Quaternion rotation = Quaternion.Euler(0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0f);

            // Aplicar movimiento al Rigidbody
            rb.MovePosition(rb.position + movement * Time.deltaTime);

            if (Math.Abs(moveVertical) > 0.01f)  
            {
                rb.MoveRotation(rb.rotation * rotation);
            }
        }
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health -= 10;  
            Console.WriteLine(WriteMessage($"Health decreased: {health} remaining."));
            CheckGameOver();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            EndGame();
        }
    }

    private void CheckGameOver()
    {
        if (health <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
