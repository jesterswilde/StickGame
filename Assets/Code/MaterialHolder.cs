using UnityEngine;
using System.Collections;

public class MaterialHolder : MonoBehaviour {

    Material _startMaterial;
    Renderer _renderer; 

    public void SetToOriginal()
    {
        if(_renderer != null)
        {
            _renderer.material = _startMaterial; 
        }
    }

    public void SetToBlack()
    {
        if(_renderer != null)
        {
            _renderer.material = GameManager.blackMaterial; 
        }
    }

	// Use this for initialization
	void Start () {
        _startMaterial = gameObject.GetComponent<Renderer>().material;
        _renderer = GetComponent<Renderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
