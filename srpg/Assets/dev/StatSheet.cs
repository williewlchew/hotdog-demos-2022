using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatSheet 
{
    Dictionary<string, float> sheet;
    
    public StatSheet(){
        sheet = new Dictionary<string, StatEntry>();
    }
}
