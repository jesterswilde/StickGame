using UnityEngine;
using System.Collections;

public class MaterialHolder : MonoBehaviour {

    Material _startMaterial;
    Renderer _renderer; 

    public void SetToOriginal()
    {
        _renderer.material = _startMaterial; 
    }

    public void SetToBlack()
    {
        _renderer.material = GameManager.blackMaterial; 
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
