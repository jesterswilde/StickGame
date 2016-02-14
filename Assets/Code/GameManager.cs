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
    [SerializeField]
    Material _daySkybox;
    [SerializeField]
    Material _nightSkybox; 
    bool _hasGivenUp; 
    public static GameObject home; 
    public static GameManager gm;
    public static Transform playerTrans;


    public void GiveUp()
    {
        Objective _objective = _objectives[_currentObjective];
        if (!_objective.UsesLights())
        {
            TurnOnTheLights(); 
            UIStuff.t.AddMessage("I give up, I'm just going to freeze here until morning."); 
            _hasGivenUp = true;
            _objective.Deactivate();
            UIStuff.t.StartFadeFromBlack(); 
            while (!_objectives[_currentObjective].UsesLights())
            {
                _currentObjective--; 
            }
        }
    }

    public void HomeAfterGivingUp()
    {
        if (_hasGivenUp)
        {
            UIStuff.t.AddMessage("Well, that was a miserable night. So good to be home."); 
            _hasGivenUp = false;
            _objectives[_currentObjective].StartObjective(); 
        }
    }

    void CheckForGivingUp()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GiveUp(); 
        }
    }

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
        //Camera.main.clearFlags = CameraClearFlags.SolidColor; 
        RenderSettings.skybox = _nightSkybox; 
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
        //Camera.main.clearFlags = CameraClearFlags.Skybox; 
        RenderSettings.skybox = _daySkybox; 
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
        if(_objectives.Length > 0)
        {
            _objectives[0].StartObjective();
        }
        playerTrans = FindObjectOfType<CharacterController>().gameObject.transform;
        home = _home; 
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleLights(); 
        }
        CheckForGivingUp();
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
