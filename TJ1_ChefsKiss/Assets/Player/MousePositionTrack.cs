using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionTrack : MonoBehaviour
{
    private Vector3 target;
    private Vector3 worldPosition;
    private Vector3 mousePos;
    private Vector3 mousePosRel;
    private Vector3 objectPos;
    private float angle;
    
    void Update()
    {
        // https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        Move();
        Aim();
    }
    
    private void Move()
    {
        // https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float speed = 6.9f;
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            Input.GetAxis("Vertical") * speed * Time.deltaTime,
            0);
    }

    /*
    void MouseMove()
    {
        objectPos = mousePos;
        mousePosRel.x = mousePos.x - objectPos.x;
        mousePosRel.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePosRel.y, mousePosRel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    */
    
    void Aim()
    {
        // https://forum.unity.com/threads/2d-mouse-aiming-js-to-c.371551/
        objectPos = transform.position;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        mousePosRel.x = target.x - objectPos.x;
        mousePosRel.y = target.y - objectPos.y;

        angle = Mathf.Atan2(mousePosRel.y, mousePosRel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
