using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//if player hit he will die
public class DeathCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
       
        if (col.GetComponent<CharachterHealth>())
        {
            col.GetComponent<CharachterHealth>().health = 0;
        }
    }
}
