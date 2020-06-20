using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankdillo : MonoBehaviour
{
    public UnitProfile profile;
    public int maxhealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = profile.maxvitality;
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
