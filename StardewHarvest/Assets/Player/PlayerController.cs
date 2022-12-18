using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject playerObject;
    public GameObject projTip;

    public float speed;
    private Vector3 normalizedInputs; 
    private float verticalInputProcessed; 

    // aiming, move elsewhere?
    private Vector3 worldPosition;
    private Vector3 mousePos;
    private Vector3 mousePosRel;
    private Vector3 objectPos;
    private Vector3 target;
    private float angle;
    
    public void Update()
    {
        MoveWithInput();
        AimWithInput();
    }

    // diagnols are broken
    private void MoveWithInput()
    {
        normalizedInputs = (transform.right * Input.GetAxis("Horizontal")) +
            (transform.forward * Input.GetAxis("Vertical"));
        normalizedInputs = Vector3.Normalize(normalizedInputs);
        rigidbody.velocity = normalizedInputs * speed;
    }

    private void AimWithInput()
    {
        // https://forum.unity.com/threads/2d-mouse-aiming-js-to-c.371551/
        objectPos = transform.position;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosDif = new Vector3();
        
        targetPosDif.x = target.x - objectPos.x;
        targetPosDif.z = target.z - objectPos.z;

        angle = Mathf.Atan2(targetPosDif.x, targetPosDif.z) * Mathf.Rad2Deg;
        playerObject.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}