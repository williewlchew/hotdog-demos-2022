using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern {
    public class StateExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StateContext stateContext = new StateContext();
            stateContext.alert();
            stateContext.alert();
            stateContext.setState(new StateTwo());
            stateContext.alert();
            stateContext.alert();
            stateContext.alert();        
        }
    }
}