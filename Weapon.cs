using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform StandingFirepoint;
    public Transform CrouchingFirepoint;
    public GameObject bulletPrefab;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)&&Input.GetButtonDown("Fire1")){
            CrouchShoot();
        }
        else if(Input.GetKey(KeyCode.S)&&Input.GetButtonDown("Fire1")){
            CrouchShoot();
        }
        
        else if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, StandingFirepoint.position,StandingFirepoint.rotation);
    }

    void CrouchShoot(){
        Instantiate(bulletPrefab, CrouchingFirepoint.position,CrouchingFirepoint.rotation);
    }
}
