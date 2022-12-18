using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour {
    
    public Camera camera;
    
    private NavMeshAgent agent;
    
    void Start() {
        // GetComponent function is fairly slow to execute, the script stores its result in a variable during the Start function
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
            }
        }
    }
}