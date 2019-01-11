using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// collider which use to transition between player and the monster war
public class CheckPoint : MonoBehaviour {
    BossController bossController;
    CharachterMovement charachter;
    FollowCamera followCamera;
    // Use this for initialization
    void Start () {
        bossController = FindObjectOfType<BossController>();
        charachter = FindObjectOfType<CharachterMovement>();
        followCamera = FindObjectOfType<FollowCamera>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
     public void OnTriggerEnter(Collider col)
    {
       
        if (col.GetComponent<CharachterMovement>())
        {
           
            bossController.BossAwake = true;
            charachter.PlayerIsInBattel();
            followCamera.battleStarted = true;
                GetComponent<BoxCollider>().isTrigger = false;
                   
        }
    }
    
}
