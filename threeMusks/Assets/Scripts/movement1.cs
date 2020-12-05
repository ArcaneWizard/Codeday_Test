using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement1 : MonoBehaviour {

    private Rigidbody rig;
    public float speed = 2.0f;
    public Camera camera;

    void Awake()
    {
        rig = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement();
        turnTowardsMouse();
    }

    //Looking at the mouse
    private void turnTowardsMouse() {

        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseWorldPosition);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    //WASD controls for movement
    private void movement() {
        
        if (Input.GetKey(KeyCode.W)) {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, speed);
        }   

        else if (Input.GetKey(KeyCode.S)) {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, -speed);
        } 

        else {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, 0);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            rig.velocity = new Vector3(-speed, rig.velocity.y, rig.velocity.z);
        }   

        else if (Input.GetKey(KeyCode.D)) {
            rig.velocity = new Vector3(speed, rig.velocity.y, rig.velocity.z);
        } 

        else {
            rig.velocity = new Vector3(0, rig.velocity.y, rig.velocity.z);
        }
    }
}