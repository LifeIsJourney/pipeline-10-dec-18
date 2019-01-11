using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// when hit by projectile reduces health
public class Eyetrigger : MonoBehaviour {

    BossController BossController;
    public int health = 4;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        BossController = FindObjectOfType<BossController>();
        animator = BossController.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "projectile" && health > 0)
        {
            animator.SetTrigger("isHit");
            
            health--;
            BossController.attacking = true;
        }
    }
}
