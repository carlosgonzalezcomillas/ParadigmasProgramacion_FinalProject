using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Taxi : Vehicle
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private bool isCarryingPassengers;
    [SerializeField] private float health = 100;  
    [SerializeField] private Slider visualHealth;

    private void Awake()
    {
        base.Start();
        SetSpeed(12.5f);
        visualHealth.maxValue = 100;
        visualHealth.value = health;

    }

    public void StartRide()
    {
        if (!isCarryingPassengers)
        {
            isCarryingPassengers = true;
            SetSpeed(25.0f);  
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
            SetSpeed(12.5f);  
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
            visualHealth.value = health;
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
