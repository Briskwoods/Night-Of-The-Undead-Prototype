using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Animator enemyAnimator; 
    private Rigidbody2D enemyrb;
    Color C;
    Renderer rend;
    public GameObject Player;
    

    void Start(){
        enemyrb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        C = rend.material.color;
    }
    // Start is called before the first frame update
    public void TakeDamage(int dmg){
        health -= dmg;
        if (transform.position.x < Player.transform.position.x ){
            enemyrb.AddForce(transform.up*100+transform.right*-100);
        }
        else if (transform.position.x > Player.transform.position.x ){
            enemyrb.AddForce(transform.up*100+transform.right*100);
        }
        StartCoroutine("Damaged");

        if (health <= 0){
            GameObject.Find("EnemyCnt").GetComponent<EnemyCountLimit>().count++;
            Die();
        }
    }

    void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemyAnimator.SetBool("IsDead",true);
        Destroy(gameObject, 0.3f);
    }

    IEnumerator Damaged(){
        C.r = 2.0f;
        rend.material.color = C;
        yield return new WaitForSeconds(0.5f);
        C.r = 1.0f;
        rend.material.color = C;
    }
}
