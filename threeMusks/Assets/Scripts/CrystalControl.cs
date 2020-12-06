using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalControl : MonoBehaviour
{

    public int health = 20;
    public Material shiny;
    public Material cracked;

    public static int MaxHealth;
    public Image crystalHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crystalHealth.fillAmount = health / MaxHealth;

        if (health <= 10)
        {
            transform.gameObject.GetComponent<MeshRenderer>().material = cracked;
        }
    }
}
