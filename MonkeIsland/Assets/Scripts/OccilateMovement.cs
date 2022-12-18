using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccilateMovement : MonoBehaviour
{
    int direction = 1;

    void Update()
    { 
        if(transform.position.x > 5){
            direction = -1;
        }
        if(transform.position.x < -5){
            direction = 1;
        }
        
        transform.Translate(direction * Time.deltaTime, 0, 0);
    }
}
