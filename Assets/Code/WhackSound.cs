using UnityEngine;
using System.Collections;

public class WhackSound : MonoBehaviour {

    [SerializeField]
    AudioClip _whackSound;
    [SerializeField]
    AudioClip _stepSound;
    public AudioClip stepSound { get { return _stepSound; } }

    public GameObject Whacked()
    {
        return Whacked(transform.position); 
    }

    public GameObject Whacked(Vector3 _pos)
    {
        GameObject _go = new GameObject("Whacked");
        AudioSource _as = _go.AddComponent<AudioSource>();
        _go.AddComponent<DestroyAfterAudio>(); 
        _as.clip = _whackSound;
        _as.spatialBlend = 1; 
        _as.Play();
        _go.transform.position = _pos;
        return _go; 
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
