using UnityEngine;
using System.Collections;

public class SoundApparatus : MonoBehaviour {

    [SerializeField]
    Transform _player; 

	void Update () {
        transform.position = _player.position; 
	}
}
