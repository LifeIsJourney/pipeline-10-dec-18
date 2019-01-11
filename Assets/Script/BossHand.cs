using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// responsible for disabling and enabling the collider placed on monster rig
public class BossHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnTriggerEnter(Collider col)
    {
        
        if (col.GetComponent<CharachterMovement>())
        {
           
            {
                col.GetComponent<CharachterHealth>().health--;
                Debug.Log("player Health reduse " + col.GetComponent<CharachterHealth>().health--);
              
            }

        }
    }
}
