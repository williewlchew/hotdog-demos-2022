using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    public PlantController plantController;

    private Plant currentPlant = null;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tile"){
            currentPlant = other.gameObject.GetComponent<Plant>();
            Debug.Log("Pointer.Plant state: " + currentPlant.state + " Pointer.Plant watered: " + currentPlant.watered);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Tile"){
            currentPlant = null;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(currentPlant){
                if(currentPlant.state > 0)
                {
                    plantController.Water(currentPlant);
                }
                else
                {
                    plantController.Tend(currentPlant);
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if(currentPlant){
                plantController.Unplant(currentPlant);
            }
        }
    }
}
