using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern {
    public class StateOne : IState
    {
        public void alert() 
        {
            Debug.Log("alert one");
        }
    }
}