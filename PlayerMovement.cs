using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float HorizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false; 
    public Animator animator;
    private bool invincible = false;
    private Rigidbody2D player;
    private float fallSpeed;
    Renderer rend;
    Color C;
    public float damageValue = 10.0f;   
    public float health = 100.0f; 
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        C = rend.material.color;
        Invoke("ResetInvulnerability", 2);
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        fallSpeed = player.velocity.y;
        animator.SetFloat("Fall", fallSpeed);
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("IsJumping", true);
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
        //Shooting Animations
        if(Input.GetKey(KeyCode.DownArrow)&&Input.GetButtonDown("Fire1")){
            animator.SetBool("CrouchShoot", true);
            animator.SetTrigger("CrouchShootTrigger");
        }
        else if(Input.GetKey(KeyCode.S)&&Input.GetButtonDown("Fire1")){
            animator.SetBool("CrouchShoot", true);
            animator.SetTrigger("CrouchShootTrigger");
        }
        
        else if(Input.GetButtonDown("Fire1")){
            animator.SetBool("StandShoot", true);
            animator.SetTrigger("StandShootTest");
        }
        else if(Input.GetKey(KeyCode.S)&&Input.GetButtonUp("Fire1")||Input.GetKey(KeyCode.DownArrow)&&Input.GetButtonUp("Fire1")){
            animator.SetBool("CrouchShoot", false);
        }
        else if(Input.GetButtonUp("Fire1")){
            animator.SetBool("StandShoot", false);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //Move Character
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

void OnCollisionEnter2D(Collision2D collision)
{ 
    if (!invincible)
   {
     if (collision.transform.tag == ("Enemy"))
     {

        HealthBarScript.playerHealth -= damageValue;
        StartCoroutine("GetInvunerable");
        animator.SetTrigger("IsHurt");
        invincible = true;
        if (collision.transform.position.x > player.transform.position.x ){
            player.AddForce(transform.up*100+transform.right*-200);
        }
        else if (collision.transform.position.x < player.transform.position.x ){
            player.AddForce(transform.up*100+transform.right*200);
        }
        Invoke("resetInvulnerability", 2);
        if(HealthBarScript.playerHealth  <= 0){
            gameManager.Die();
        }        
      }
   }
   else{
       invincible = false;
   }
}
 void resetInvulnerability()
 {
    invincible = false;
    Physics2D.IgnoreLayerCollision(9, 8, false);
 }

 IEnumerator GetInvunerable(){
        Physics2D.IgnoreLayerCollision(9, 8, true);
        C.a = 0.5f;
        rend.material.color = C;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(9, 8, false);
        C.a = 1.0f;
        rend.material.color = C;


    }
}
