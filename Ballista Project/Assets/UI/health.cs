using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public HealthBar healthbar;
    int maxhealth;
    int currenthealth;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 20;
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            currenthealth -= 1;
            healthbar.SetHealth(currenthealth);
        }
    }
}
