using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    LayerMask dayLightsMask; 

    public void TurnOutTheLights()
    {
        //Mesh[] _meshes = FindObjectsOfType<Mesh>();  
        Light[] _lights = FindObjectsOfType<Light>();
        for(int i = 0; i < _lights.Length; i++)
        {
            Light _light = _lights[i];
            if ((dayLightsMask.value & 1 << _light.gameObject.layer) != 0)
            {
                _lights[i].enabled = false;
            }
        }
    }

    public void TurnOnTheLights()
    {
        Light[] _lights = FindObjectsOfType<Light>(); 
        for(int i = 0; i < _lights.Length; i++)
        {
            Light _light = _lights[i]; 
            if((dayLightsMask.value & 1<<_light.gameObject.layer) != 0)
            {
                Debug.Log(_light.name); 
                _light.enabled = true;
            }
        }
    }

	// Use this for initialization
	void Start () {
        
	}

	// Update is called once per frame
	void Update () {
	
	}
}
