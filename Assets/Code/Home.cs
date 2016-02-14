using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    void OnTriggerEnter(Collider _coll)
    {
        if(_coll.gameObject.layer == 9)
        {
            GameManager.gm.HomeAfterGivingUp();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
