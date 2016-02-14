using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    bool _lightsOn = true;
    [SerializeField]
    Material _blackMaterial;
    static Material sBlackMaterial; 
    public static Material blackMaterial { get { return sBlackMaterial; } }
    [SerializeField]
    Objective[] _objectives;
    [SerializeField]
    int _currentObjective = 0;
    [SerializeField]
    GameObject _home;
    public static GameObject home; 
    public static GameManager gm;
    public static Transform playerTrans;

    public void Respawn(bool rollback)
    {
        if(rollback)
        {
            _objectives[_currentObjective].Deactivate();
            _currentObjective--; 
        }
        _objectives[_currentObjective].Respawn(); 
    }

    public void CompleteObjective()
    {
        _currentObjective++; 
        if(_currentObjective < _objectives.Length)
        {
            _objectives[_currentObjective].StartObjective(); 
        }
    }

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
        gm = this;
        _objectives[0].StartObjective();
        playerTrans = FindObjectOfType<CharacterController>().gameObject.transform;
        home = _home; 
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleLights(); 
        }
	}

    void CheckRespawn()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Respawn(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Respawn(true); 
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
