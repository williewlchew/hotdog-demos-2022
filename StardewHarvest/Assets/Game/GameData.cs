using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int day = 0;
    public int points = 0;

    public delegate void ChangeValue();
    public static event ChangeValue ChangeDay;
    
    public void NewDay(){
        day += 1;
        ChangeDay();
        Debug.Log("New Day! Current day: " + day);
    }

    public void AddPoint(){
        points += 1;
    }
}
