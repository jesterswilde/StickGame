using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Animator _anim;
    bool _canPlaySound = false;
    bool _holdingLeft = false;
    float _normalizedTime = 0; 

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
        CheckClicks();
        CheckForAnimationEnd(); 
	}

    void StartSwing()
    {
        if (!isActive())
        {
            _normalizedTime = 0; 
            _canPlaySound = true;
            _anim.SetBool("verticalSwing", true);
        }
    }

    void EndSwing()
    {
        _anim.SetBool("verticalSwing", false); 
    }

    void Whacked(Collision _coll)
    {
        GameObject _go = _coll.gameObject;
        WhackSound _whack = _go.GetComponent<WhackSound>();
        if (_whack != null && _canPlaySound)
        {
            _normalizedTime = Mathf.Ceil(_anim.GetCurrentAnimatorStateInfo(0).normalizedTime); 
            _canPlaySound = false; 
            _whack.Whacked(_coll.contacts[0].point);
            _anim.Play(_anim.GetCurrentAnimatorClipInfo(0)[0].clip.name); 
        } 
    }

    void CheckClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSwing(); 
 
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndSwing(); 
        }
    }

    void CheckForAnimationEnd()
    {
        if(!_canPlaySound)
        {
            float _currentTime = _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if(_currentTime > _normalizedTime)
            {
                _canPlaySound = true; 
            }
        }
    }

    void OnCollisionEnter(Collision _coll)
    {
        if (isActive())
        {
            Whacked(_coll); 
        }
    }
    bool isActive()
    {
        return _anim.GetCurrentAnimatorStateInfo(0).IsTag("active"); 
    }
}
