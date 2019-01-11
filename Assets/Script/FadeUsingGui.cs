using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fade using the a value of an image
public class FadeUsingGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<GUITexture>().pixelInset = new Rect(0, 0, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
