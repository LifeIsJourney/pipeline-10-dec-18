using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffTrigger : MonoBehaviour {
    Animator anim;
    public bool playerRight;
	// Use this for initialization
	void Start () {
      
        anim = GameObject.Find("Boss_Rig").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider Col)
    {
        if (Col.GetComponent<CharachterMovement>())
        {
           
            anim.SetBool("playerRight", playerRight);
        }
        
    }
   
}
