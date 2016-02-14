using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    bool _active = false;
    [SerializeField]
    bool _requireButtonPush = false; 
    bool _playerIsInArea = false;
    [SerializeField]
    string _comment;
    Objective _objective; 

    public void Begin(Objective objective)
    {
        _active = true;
        _objective = objective; 
    }

    public void End()
    {
        _active = false; 
    }

    public void CompleteTarget()
    {
        if(_comment != null)
        {
            UIStuff.t.AddMessage(_comment); 
        }
        Debug.Log("completed target"); 
        _objective.CompleteTarget();
        _active = false; 
    }

    void OnTriggerExit(Collider _coll)
    {
        if (_active)
        {
            if (_requireButtonPush)
            {
                if(_coll.gameObject.layer == 9)
                {
                    _playerIsInArea = false; 
                }
            }
        }
    }

    void OnTriggerEnter(Collider _coll)
    {
        if (_active)
        {
            if (_requireButtonPush)
            {
                if(_coll.gameObject.layer == 9)
                    {
                        _playerIsInArea = true; 
                    }
            }
            else
            {   if(_coll.gameObject.layer == 9)
                {
                    CompleteTarget();
                }
            }
        }
    }

    void CheckForClick()
    {
        if(_active && _requireButtonPush && _playerIsInArea)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                CompleteTarget(); 
            }
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckForClick(); 
	}
}
