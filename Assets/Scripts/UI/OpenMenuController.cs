using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

    public class OpenMenuController : MonoBehaviour
    {
        public GameObject MenuPanel;
        public GameObject MenuCanvas;
        public PlayerInputs _inputs;
        private FirstPersonController Controller;
        private float _currentPressCooldown = 0f;
    public static OpenMenuController Instance;
        [Inject]
        public void Construct(PlayerInputs inputs)
        {
            _inputs = inputs;
        
        }
        // Start is called before the first frame update
        void Start()
        {
            Controller = _inputs?.GetComponent<FirstPersonController>();
        if (Instance == null) 
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(this.gameObject);
        }
        MenuCanvas = this.gameObject;
        }
        public void OpenCloseMenu()
        {
            if (!MenuPanel.activeSelf && Time.timeScale!=0f)
            {
                EnterOpenMenuState();
                MenuPanel.SetActive(true);
            MenuCanvas.transform.SetAsLastSibling();

                
            }
            else
            {
            MenuCanvas.transform.SetAsFirstSibling();
                MenuPanel.SetActive(false);
                ExitOpenMenuState();

            }
            _inputs.openMenu = false;
        }
        public void EnterOpenMenuState() 
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        if (Controller)
        {
            Controller.enabled = false;
        }
    }
        public void ExitOpenMenuState()
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        if (Controller)
        {
            Controller.enabled = true;
        }
    }
        // Update is called once per frame
        void Update()
        {
            if (_inputs.openMenu)
            {
                if (_currentPressCooldown > 1f)
                {
                    _currentPressCooldown = 0f;
                    OpenCloseMenu();
                    
                }
            }
            if (_inputs.shoot)
            {
                if (Time.timeScale != 0f)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            _currentPressCooldown += Time.unscaledTime;
            if (_currentPressCooldown > 5f) 
            {
                _currentPressCooldown = 2f;
            }
        }
    }
