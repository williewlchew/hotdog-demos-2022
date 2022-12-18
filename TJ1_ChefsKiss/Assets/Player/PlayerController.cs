using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public GameObject playerObject;
    public GameObject proj;
    public GameObject projTip;

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
        ShootInput();
    }
    
    private void MoveWithInput()
    {
        // https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float speed = 6.9f;
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            Input.GetAxis("Vertical") * speed * Time.deltaTime,
            0);
    }

    private void AimWithInput()
    {
        // https://forum.unity.com/threads/2d-mouse-aiming-js-to-c.371551/
        objectPos = transform.position;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosDif = new Vector3();
        
        targetPosDif.x = target.x - objectPos.x;
        targetPosDif.y = target.y - objectPos.y;

        angle = Mathf.Atan2(targetPosDif.y, targetPosDif.x) * Mathf.Rad2Deg;
        playerObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(proj, projTip.transform.position, projTip.transform.rotation);
            animator.ResetTrigger("Shoot");
            animator.SetTrigger("Shoot");
        }
    }
}
