using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Animator _anim; 

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
        CheckClicks(); 
	}

    void CheckClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetBool("verticalSwing", true); 
        }
        if (Input.GetMouseButtonUp(0))
        {
            _anim.SetBool("verticalSwing", false); 
        }
    }
}
