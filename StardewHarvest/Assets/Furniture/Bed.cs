using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameData gameData;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            gameData.NewDay();
        }
    }
}
