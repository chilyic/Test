using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private FirstPersonMove _player;
    [SerializeField] private FPSCamera _camera;

    private bool _isPause;

    void Start()
    {
        _panel.SetActive(false);
        _isPause = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void Continue()
    {
        _isPause = !_isPause;
        _panel.SetActive(_isPause);
        _player.enabled = !_isPause;
        _camera.enabled = !_isPause;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
