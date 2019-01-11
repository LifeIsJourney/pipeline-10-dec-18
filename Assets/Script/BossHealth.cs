using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//responsible for health of monster and place on eye trigger
// player sword hit eye and reduse health of monster
public class BossHealth : MonoBehaviour {

    BossController BossController;
    public int health = 4;
    Animator animator;
    bool bossDead = false;

    public Material eyeHurt;
    private GameObject eyeModel;
    // Use this for initialization
    void Start()
    {
        BossController = GetComponentInParent<BossController>();
        animator = BossController.GetComponentInChildren<Animator>();
        eyeModel = GameObject.FindGameObjectWithTag("eyeModel");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 2)
        {   if (!eyeModel)
                Debug.LogError("unable to find model");

            eyeModel.GetComponent<Renderer>().material = eyeHurt;
            
        }
        if (health <= 0)
        {
            if (!bossDead)
            {
                BossDying();
            }
            else
            {
                BossDead();
                LevelReset();
              
            }
            
        }
    }
    void BossDying()
    {
        bossDead = true;
        animator.SetBool("isDead", bossDead);
    }
    void BossDead()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Boss_Death"))
        {
            Debug.Log("clip completed " + animator.GetCurrentAnimatorStateInfo(0).IsName("Boss_Death"));
            bossDead = false;
            animator.SetBool("isDead", bossDead);
        }
    }
    void LevelReset()
    {
        //reset the levl
        Debug.Log("reset the level");
        Debug.Log("reset the level");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "projectile" && health > 0)
        {   if(health !=1)
            animator.SetTrigger("isHit");

            health--;
            BossController.attacking = true;
        }
    }
}

                                                                                
