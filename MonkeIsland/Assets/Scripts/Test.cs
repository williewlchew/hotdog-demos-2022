using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var v = new { Amount = 108, Message = "Hello" };

        // Rest the mouse pointer over v.Amount and v.Message in the following
        // statement to verify that their inferred types are int and string.
         Debug.Log(v.Amount + v.Message);
    }
}
