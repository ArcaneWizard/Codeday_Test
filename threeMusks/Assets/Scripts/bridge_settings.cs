using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge_settings : MonoBehaviour
{
    public float planckSpacing = 2f;
    public Transform PlancksAvailable;
    private List<GameObject> planckboards = new List<GameObject>();

    void Awake()
    {
        //space all the bridge's plank edge pivots equally apart
        for (int n = 0; n < transform.childCount; n++) {
            transform.GetChild(n).transform.position = new Vector3(-15f + planckSpacing * n, 40, 15.85f);
        }

        //add planks to a list
        foreach (Transform child in PlancksAvailable)
            planckboards.Add(child.gameObject);
    }

    void Update() {
        //make planckboards align their edges with the edge pivot anchors
        for (int n = 0; n < transform.childCount - 2; n++) {
            Vector3 center = (transform.GetChild(n).transform.position + transform.GetChild(n+1).transform.position) / 2f;
            planckboards[n].transform.position = center;

            Vector3 posDiff = transform.GetChild(n+1).transform.position - transform.GetChild(n).transform.position;
            float angle = Mathf.Atan2(posDiff.y, posDiff.x) * 180 / Mathf.PI;
            planckboards[n].transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
