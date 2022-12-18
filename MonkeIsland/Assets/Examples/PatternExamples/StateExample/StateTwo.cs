using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern {
    public class StateTwo : IState
    {
        public void alert() 
        {
            Debug.Log("alert two");
        }
    }
}