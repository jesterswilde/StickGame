using UnityEngine;
using System.Collections;

public class DestroyAfterAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float _duration = GetComponent<AudioSource>().clip.length;
        Destroy(gameObject, _duration);
    }           
}
