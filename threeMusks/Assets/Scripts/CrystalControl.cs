using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalControl : MonoBehaviour
{

    public int health = 20;
    public Material shiny;
    public Material cracked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 10)
        {
            transform.gameObject.GetComponent<MeshRenderer>().material = cracked;
        }
    }
}
