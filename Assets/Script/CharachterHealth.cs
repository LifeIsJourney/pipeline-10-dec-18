using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// health of the character and color changes as the health decreases
public class CharachterHealth : MonoBehaviour {
    
    public int health=3;
     ParticleSystemRenderer aura;
    //wait time so that we can play dead animation and then reload level
    public float  waitTime = 3;
    float timer;
    CharachterMovement charachterMovement;
    private Color AuraColor;
    bool playerDead;
    Animator animator;
    Renderer[] rendererMaterial;
    private void Awake()
    {
        playerDead = false;
        charachterMovement = GetComponent<CharachterMovement>();
        aura = GetComponent<ParticleSystemRenderer>();
        animator = GetComponentInChildren<Animator>();
        rendererMaterial = GetComponentsInChildren<Renderer>();
        Debug.Log("renderer rlenght"+rendererMaterial.Length);
    }
    // Use this for initialization
    void Start () {
        AuraColor = Color.yellow;   
     
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 3)
        {
            AuraColor = Color.cyan;
            AuraColor.a = 0.04f;
            aura.material.SetColor ("_TintColor",AuraColor);
            foreach (Renderer rend in rendererMaterial)
            {

                rend.material.SetColor("_OutlineColor", AuraColor);
            }
           
        }
        if (health == 2)
        {
            AuraColor = Color.red;
            AuraColor.a = 0.04f;
            aura.material.SetColor("_TintColor", AuraColor);
            foreach (Renderer rend in rendererMaterial)
            {
                Debug.Log("changing aura color");
                rend.material.SetColor("_OutlineColor", AuraColor);
            }
        }  if (health == 1)
        {
            AuraColor = Color.magenta;
            AuraColor.a = 0.04f;
            aura.material.SetColor("_TintColor", AuraColor);
            foreach (Renderer rend in rendererMaterial)
            {
                Debug.Log("changing aura color");
                rend.material.SetColor("_OutlineColor", AuraColor);
            }
        }
        if (health < 0)
        {
            if (!playerDead)
            {
                PlayerDying();
                    }
            else
            {
                PlayerDead();
                ReloadTimerStart();
               

            }


        }
        
    }
    void PlayerDying()
    {
        playerDead = true;
        animator.SetBool("isDead", playerDead);
       
    }
    void PlayerDead()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Knight_Death_01_F"))
        {
            playerDead = false;
            animator.SetBool("isDead", playerDead);
        }
        charachterMovement.enabled = false;
        animator.SetFloat("Speed", 0);
    }
    void ReloadTimerStart()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            //reload level
            Debug.Log("reloading level");
        }
    }
    
}
