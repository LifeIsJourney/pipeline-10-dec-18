using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// animation will call these function placed on rigs
public class EventHandler : MonoBehaviour {
    CharachterMovement charachter;
  
    // Use this for initialization
    void Start () {
        charachter = FindObjectOfType<CharachterMovement>();
      }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EnableBossBattle()
    {
        charachter.enabled = true;
        GetComponentInParent<BossController>().inbattle = true;
    }
    public void CallFireProjectile()
    {
        charachter.Fire();
    }
    public void CallFallApart()
    {
        charachter.FallApart();
    } 
    public void UpdateBossAttack()
    {
        GetComponentInParent<BossController>().UpdateAttackCount();
    }
    public void CallEnableEye()
    {
        GetComponentInParent<BossController>().EyeColliderEnable();
    }
    public void CallDisableEye()
    {
        GetComponentInParent<BossController>().EyeColliderDisable();
    }
}
