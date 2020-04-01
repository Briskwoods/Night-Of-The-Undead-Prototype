using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    float maxhealth = 100f;
    public static float playerHealth;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        playerHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth/maxhealth;
        
    }
}
