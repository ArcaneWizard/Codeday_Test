using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform player;
    private float distance = 0.2f;

    private Rigidbody rig;

    void Awake() {
        rig = transform.GetComponent<Rigidbody>();

        RaycastHit hit;
        if (rig.velocity.magnitude < 25) {
            if (Physics.Raycast(transform.position, rig.velocity, out hit, 0.5f)) {    
                player.position = transform.position -  (transform.GetComponent<Rigidbody>().velocity.normalized);
                Destroy(transform.gameObject);
            } 
        }
        else {
            if (Physics.Raycast(transform.position, rig.velocity, out hit, 1.1f)) {    
                player.position = transform.position - (transform.GetComponent<Rigidbody>().velocity.normalized);
                Destroy(transform.gameObject);
            } 
        }
    }

    void FixedUpdate() {

        RaycastHit hit;

        if (rig.velocity.magnitude < 25) {
            if (Physics.Raycast(transform.position, rig.velocity, out hit, 0.5f)) {    
                player.position = transform.position -  (transform.GetComponent<Rigidbody>().velocity.normalized);
                Destroy(transform.gameObject);
            } 
        }
        else {
            if (Physics.Raycast(transform.position, rig.velocity, out hit, 1.1f)) {    
                player.position = transform.position - (transform.GetComponent<Rigidbody>().velocity.normalized);
                Destroy(transform.gameObject);
            } 
        }
    }

    /*void OnCollisionEnter(Collision col){
        player.position = transform.position - (transform.GetComponent<Rigidbody>().velocity.normalized);
        Destroy(transform.gameObject);
    }*/

}
