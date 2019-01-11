using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// collider will follow the eye
public class FollowEye : MonoBehaviour {
    Transform eyeTransform;Vector2 pos;
	// Use this for initialization
	void Start () {
        eyeTransform = GameObject.FindGameObjectWithTag("eyeTransform").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!eyeTransform)
            return;
        resetPosition();
	}
    void resetPosition()
    {
        pos =new Vector2(eyeTransform.position.x,eyeTransform.position.y);
        transform.position = pos;
    }
}
