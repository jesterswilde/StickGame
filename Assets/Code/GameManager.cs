using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    bool _lightsOn = true;
    [SerializeField]
    Material _blackMaterial;
    static Material sBlackMaterial; 
    public static Material blackMaterial { get { return sBlackMaterial; } }

    public void AddHolders()
    {
        Renderer[] _meshes = FindObjectsOfType<Renderer>();
        foreach (Renderer _mesh in _meshes)
        {
            if (_mesh.CompareTag("env"))
            {
                _mesh.gameObject.AddComponent<MaterialHolder>();
            }
        }
    }

    public void TurnOutTheLights()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor; 
        Renderer[] _meshes = FindObjectsOfType<Renderer>();
        foreach (Renderer _mesh in _meshes)
        {
            if (_mesh.CompareTag("env"))
            {
                _mesh.GetComponent<MaterialHolder>().SetToBlack();
            }
        }
    }

    public void TurnOnTheLights()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox; 
        Renderer[] _meshes = FindObjectsOfType<Renderer>();
        foreach (Renderer _mesh in _meshes)
        {
            if (_mesh.CompareTag("env"))
            {
                _mesh.GetComponent<MaterialHolder>().SetToOriginal(); 
            }
        }
    }

	// Use this for initialization
	void Start () {
        sBlackMaterial = _blackMaterial;
        AddHolders(); 
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleLights(); 
        }
	}

    void ToggleLights()
    {
        if (_lightsOn)
        {
            TurnOutTheLights();
        }
        else
        {
            TurnOnTheLights();
        }
        _lightsOn = !_lightsOn; 
    }
}
