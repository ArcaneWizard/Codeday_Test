using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody rig;
    public float speed = 2.0f;
    public float accelerationTime = 0.3f;
    public Camera camera;
    public GameObject body;

    public float sensitivity = 150f;
    private float xRotation = 0;
    private Transform orientation;

    private bool canJump = true;
    private bool onGround = false;
    public Vector3 jumpForce;
    public float jumpReload;
    private float jumpTimer;

    private float[] Timers = {1, 1, 1, 1};
    Vector3[] diffDirs = new Vector3[4];

    void Awake()
    {
        rig = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        TurnTowardsMouse();

        //Hit space to jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump && onGround) {
            Jump();
            canJump = false;
        }

        //Jump reload
        if (jumpTimer > 0) {
            jumpTimer -= Time.deltaTime;
        }
        else 
            canJump = true;
    }

    //Looking at the mouse
    private void TurnTowardsMouse() {

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * 2;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * 2;

        Vector3 rot = camera.transform.localEulerAngles;
        float desiredX = rot.y + mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        body.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }

    //WASD controls for movement
    private void Movement() {
        
       setKey(KeyCode.W, 0);
       setKey(KeyCode.S, 2);
       setKey(KeyCode.A, 3);
       setKey(KeyCode.D, 1);
        
        Vector3 finalDir = (diffDirs[0] + diffDirs[1] + diffDirs[2] + diffDirs[3]) * speed;
        rig.velocity = new Vector3(finalDir.x, rig.velocity.y, finalDir.z);
    }

    //check if a key is being pressed
    private void setKey(KeyCode key, int type) {
        if (Input.GetKey(key)) {
            setIndividualDir(type);
        }   
        else {
            diffDirs[type] = new Vector3(0, 0, 0);
            Timers[type] = accelerationTime;
        }
    }

    //return direction corresponding to a key
    private Vector3 dir(int type) {
        float angle = type * 90 + body.transform.localEulerAngles.y;
        Vector2 newDir = new Vector2(Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f));
        return new Vector3(newDir.y, 0, newDir.x);  
    }

    //add acceleration for traveling in a direction
    private void setIndividualDir(int type) {
        diffDirs[type] = dir(type);
        if (Timers[type] > 0) {
            //Mimics acceleration
            //when Timer starts counting down, the speed multiplier is 0.3. As the value of Timer approaches 0, the speed multiplier approaches 1
            diffDirs[type] *= 1f - (0.7f/accelerationTime) * Timers[type];
            Timers[type] -= Time.deltaTime;
        }
    }

    //Jumping
    private void Jump() {
        jumpTimer = jumpReload;
        rig.AddForce(jumpForce);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") {
            onGround = true;
        }
    }

    void OnCollisionStay(Collision col) {
        if (col.gameObject.tag == "Ground") {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Ground") {
            onGround = false;
        }
    }
}