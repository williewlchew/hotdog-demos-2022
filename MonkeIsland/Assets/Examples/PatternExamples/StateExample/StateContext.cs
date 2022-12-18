using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern {
    public class StateContext 
    {
        private IState currentState;

        public StateContext() 
        {
            currentState = new StateOne();
        }

        public void setState(IState state) 
        {
            currentState = state;
        }
    
        public void alert() 
        {
            currentState.alert();
        }

    }
}