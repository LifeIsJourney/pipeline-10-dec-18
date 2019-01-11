using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockParticle : MonoBehaviour {
    public Vector2 waitTime;
    float counter;
    ParticleSystem ps;
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(counter > Random.Range(waitTime.x, waitTime.y))
        {
            ps.Play();
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }
	}
}
