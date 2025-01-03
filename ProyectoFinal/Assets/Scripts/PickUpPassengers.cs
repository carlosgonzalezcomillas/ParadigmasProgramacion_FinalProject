using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPassengers : MonoBehaviour
{
    public GameObject passengerSeat;
    private GameObject pickedObject = null;
    private Taxi taxiScript; 

    void Start()
    {
        taxiScript = GetComponentInParent<Taxi>(); 
    }

    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                Renderer[] renderers = pickedObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in renderers)
                {
                    rend.enabled = true;
                }

                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;

                if (taxiScript != null)
                    taxiScript.StopRide();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                Renderer[] renderers = other.GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in renderers)
                {
                    rend.enabled = false;
                }


                other.transform.position = passengerSeat.transform.position;
                other.gameObject.transform.SetParent(passengerSeat.gameObject.transform);
                pickedObject = other.gameObject;

                if (taxiScript != null)
                    taxiScript.StartRide();
            }
        }
    }
}
