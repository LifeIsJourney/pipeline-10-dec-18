using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    public bool BossAwake = false;
    public bool attacking = false;
    public bool inbattle = false;
    public float idleTimer = 0.0f;
    public float timerReset = 10;
    public float attackTimer = 0;
    public float attackWaitTime = 2;
    public int attackCount = 0;
    Animator animator;
    BoxCollider leftHand_Collider;
    BoxCollider RightHand_Collider;
    BossHealth bossHealth;
    CharachterHealth charachterHealth;
    public float blinkTimer=0, blinkWaitTime=2;
    SphereCollider eyeCollider;
    // Use this for initialization
    void Awake () {
        animator = GetComponentInChildren<Animator>();
        leftHand_Collider =  GameObject.FindGameObjectWithTag("HandLeft").GetComponent<BoxCollider>();
        RightHand_Collider = GameObject.FindGameObjectWithTag("HandRight").GetComponent<BoxCollider>();
        bossHealth = FindObjectOfType<BossHealth>();
        charachterHealth = FindObjectOfType<CharachterHealth>();
        animator.SetInteger("AttackCount", attackCount);
        eyeCollider = GameObject.FindGameObjectWithTag("eyeTrigger")
            .GetComponent<SphereCollider>();
    }
	public void UpdateAttackCount()
    {
        Debug.Log("removing attack count using event");
        attackCount--;
     }
	// Update is called once per frame
	void Update () {
        if (BossAwake)
        {
            animator.SetBool("Awake", true);
            blinkTimer += Time.deltaTime;
            if(blinkTimer >= blinkWaitTime)
            {
                BlinkEye();
                blinkTimer = 0;
            }

            animator.SetInteger("AttackCount", attackCount);
            if (inbattle)
            {
                if (!attacking)
                {
                    idleTimer += Time.deltaTime;
                    
                }
                else
                {
                    idleTimer = 0;
                    attackTimer += Time.deltaTime;
                    animator.SetBool("AttackReady", true);


                    if (attackTimer > attackWaitTime)
                    {
                        Debug.Log("SMASH");
                       
                        animator.SetTrigger("BossAttack");
                        attacking = false;
                        attackTimer = 0;
                        animator.SetBool("AttackReady", false);
                        leftHand_Collider.enabled = true;
                        RightHand_Collider.enabled = true;
                    }
                }
                if (idleTimer >= timerReset)
                {   //start Attack
                    attacking = true;
                    idleTimer = 0.0f;
                }
            }
        
        }
        else
        {
            idleTimer = 0;
        }
        

        if(bossHealth.health>0 && charachterHealth.health > 0)
        {
            if (attackCount == 0)
            {
                if(bossHealth.health == 4)
                {
                    attackCount = 1;
                    Debug.Log("Attack count 1 set");
                    attackWaitTime = 3;
                }if(bossHealth.health == 3)
                {
                    attackCount = 2;
                    attackWaitTime = 2;
                }if(bossHealth.health == 2)
                {
                    attackCount = 3;
                    attackWaitTime = 2;
                }if(bossHealth.health == 1)
                {
                    attackCount = 4;
                    attackWaitTime = 1;
                }
            }
        }
    }
    void BlinkEye()
    {
        animator.SetTrigger("blink");
    }
    public void EyeColliderEnable()
    {
        eyeCollider.enabled = true;
    }
    public void EyeColliderDisable()
    {
        eyeCollider.enabled = false;
    }
}
