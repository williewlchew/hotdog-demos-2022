using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int state;
    public bool watered;
    public SpriteRenderer sprite;

    void OnEnable()
    {
        GameData.ChangeDay += NewDay;
    }
    void OnDisable()
    {
        GameData.ChangeDay -= NewDay;
    }

    // should this be moved?
    private void NewDay()
    {
        if(watered)
        {
            state += 1;
        }
        else
        {
            state = 0;
        }
    }
}
