using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 

public class UIStuff : MonoBehaviour {

    [SerializeField]
    GameObject _panel;
    [SerializeField]
    Text _text;
    [SerializeField]
    float _timeDelay = 3f; 
    Queue<string> _textQueue = new Queue<string>();
    float _timer = 0;
    bool _active = false;
    public static UIStuff t; 

    public void AddMessage(string _message)
    {
        _textQueue.Enqueue(_message);
        if (!_active)
        {
            ShowMessage();
            _active = true; 
        }
    }

    void ShowMessage()
    {
        if(_textQueue.Count > 0)
        {
            _active = true; 
            _panel.SetActive(true);
            _text.text = _textQueue.Dequeue(); 
        }
    }

    void HideMessage()
    {
        _panel.SetActive(false);
    }

    void Counter()
    {
        if (_active)
        {
            _timer += Time.deltaTime; 
            if(_timer > _timeDelay)
            {
                _timer = 0; 
                if(_textQueue.Count > 0)
                {
                    ShowMessage();
                }
                else
                {
                    HideMessage(); 
                    _active = false; 
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        HideMessage(); 
	}

    void Awake()
    {
        t = this; 
    }
	
	// Update is called once per frame
	void Update () {
        Counter(); 
	}
}
