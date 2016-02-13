using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<WhackSound>().Whacked(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
