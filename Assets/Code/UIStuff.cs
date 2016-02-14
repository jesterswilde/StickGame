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
    float _messageDelay = 3f; 
    Queue<string> _textQueue = new Queue<string>();
    float _messageTimer = 0;
    bool _active = false;
    public static UIStuff t;
    [SerializeField]
    Image _blackoutPanel;
    [SerializeField]
    float _fadeDuration;
    float _fadeTimer = 0;
    int _isFading = 0; 


    public void StartFadeToBlack()
    {
        _isFading = 1;
        _blackoutPanel.color = new Color(0, 0, 0, 0); 
    }

    public void StartFadeFromBlack()
    {
        _isFading = 2;
        _blackoutPanel.color = new Color(0, 0, 0, 1); 
    }

    void FadeToBlack()
    {
        if(_isFading == 1) //fadin to black
        {
            float _amount = Time.deltaTime / _fadeDuration;
            float _newAlpha =_blackoutPanel.color.a + _amount;
            _blackoutPanel.color = new Color(0, 0, 0, _newAlpha); 
            if(_newAlpha >= 1)
            {
                GameManager.gm.TurnOutTheLights();
                _isFading = 2; 
            }
        }
        if(_isFading == 2) //fadin back in 
        {
            float _amount = Time.deltaTime / _fadeDuration;
            float _newAlpha = _blackoutPanel.color.a - _amount;
            _blackoutPanel.color = new Color(0, 0, 0, _newAlpha);
            if (_newAlpha >= 1)
            {
                _isFading = 0;
            }
        }
    }

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
            _messageTimer += Time.deltaTime; 
            if(_messageTimer > _messageDelay)
            {
                _messageTimer = 0; 
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
        FadeToBlack(); 
	}
}
