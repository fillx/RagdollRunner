using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterContoller : MonoBehaviour
{
    public float currentSpeed = 1000f;
    public Rigidbody mybody;
    public Animator myAnimator;
    
    public bool isMoving = false;
    public bool canJump = true;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        mybody.AddForce(Vector3.right * currentSpeed*Time.fixedDeltaTime);

        Debug.Log(mybody.velocity.magnitude);
        Debug.Log(mybody.velocity);
        if(mybody.velocity.magnitude >= 1f){
            isMoving = true;
            myAnimator.SetBool("moving", true);

        }
        else{
            isMoving = false;
            myAnimator.SetBool("moving", false);     
        }
        
        if(isMoving){

        }
        if(transform.position.y <= -10f){

        }
    }
    
    
    void OnTriggerEnter(Collider other){
        if(other.tag != "Ground"){
            return;
        }
        else{
            myAnimator.SetBool("falling",false);
            canJump = true;
            
        }
    }

    void OnTriggerStay(Collider other){
        if(other.tag != "Ground"){
            return;
        }
        else{
            myAnimator.SetBool("falling",false);
            canJump = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag != "Ground"){
            return;
        }
        else{
            myAnimator.SetBool("falling",true);
            canJump = false;    
        }
    }
}
