using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

    [SerializeField]
    Target[] _targets;
    [SerializeField]
    int _needed = 0;
    int _completed = 0; 
    [SerializeField]
    string _startText;
    [SerializeField]
    string _completeText;
    [SerializeField]
    bool _lightsOn = true;
    GameObject _startingPos; 

    public void StartObjective()
    {
        if(_startText != null)
        {
            UIStuff.t.AddMessage(_startText); 
        }
        _completed = 0;
        if (_lightsOn)
        {
            GameManager.gm.TurnOnTheLights();
        }
        else
        {
            if(_startingPos == null)
            {
                _startingPos = new GameObject();
                _startingPos.transform.position = GameManager.playerTrans.position;
                _startingPos.transform.rotation = GameManager.playerTrans.rotation;
            }
            GameManager.gm.TurnOutTheLights(); 
        }
        foreach(Target _target in _targets)
        {
            _target.Begin(this); 
        }
    }

    public void Respawn()
    {
        if (_lightsOn)
        {
            Player.SetPosition(GameManager.home.transform);
        }
        else
        {
            Player.SetPosition(_startingPos.transform); 
        }
        StartObjective();
    }

    public void Deactivate()
    {
        TurnOffTargets();
        if(_startingPos != null)
        {
            Destroy(_startingPos); 
        }
    }

    void CompleteObjective()
    {
        if(_completeText != null)
        {
            UIStuff.t.AddMessage(_completeText); 
        }
        GameManager.gm.CompleteObjective();
        if(_startingPos != null)
        {
            Destroy(_startingPos); 
        }
    }

    void TurnOffTargets()
    {
       foreach(Target _target in _targets)
        {
            _target.End(); 
        }
    }

    public void CompleteTarget()
    {
        _completed++; 
        if(_completed >= _needed)
        {
            TurnOffTargets(); 
            Debug.Log("completed objective"); 
            CompleteObjective();
        }
    }

	// Use this for initialization
	void Start () {
	    if(_needed == 0)
        {
            _needed = _targets.Length; 
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
