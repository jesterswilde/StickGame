using UnityEngine;
using System.Collections;

public class ControllerAddon : MonoBehaviour {

    CharacterController _char;
    GameObject _currentGround;
    [SerializeField]
    LayerMask groundMask;
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController _controller; 

	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
        _controller = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        GetGround(); 
	}

    void GetGround()
    {
        if (_char.isGrounded)
        {
            Ray _ray = new Ray(transform.position, Vector3.down);
            RaycastHit _hit;
            if(Physics.Raycast(_ray, out _hit, 100, groundMask))
            {
                GameObject _go = _hit.collider.gameObject;
                WhackSound _whack = _go.GetComponent<WhackSound>(); 
                if(_whack != null)
                {
                    AudioClip[] _audioArray = new AudioClip[] { _whack.stepSound };
                    _controller.SetFootsteps(_audioArray); 
                }
            }
        }
    }
}
