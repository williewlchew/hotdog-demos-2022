//https://docs.unity3d.com/2022.1/Documentation/Manual/Navigation.html
using UnityEngine;
    
public class MoveDestination : MonoBehaviour {
       
    public Transform goal;
    
    void Start () {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //tell an agent to start calculating a path
        agent.destination = goal.position; 
    }
}