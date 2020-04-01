﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject HealEffect;
    public float health = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthBarScript.playerHealth += health;
             Instantiate(HealEffect,transform.position, transform.rotation);
             Destroy(gameObject);
        }

     
    }
        
    
}
