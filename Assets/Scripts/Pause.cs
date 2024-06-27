using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Movement _player;
    [SerializeField] private CameraController _camera;

    private bool _isPause;
    private Animator _animator;

    private void Start()
    {
        _panel.SetActive(false);
        _isPause = false;
        _animator = _player.GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseResume();
    }

    public void PauseResume()
    {
        _isPause = !_isPause;
        _panel.SetActive(_isPause);
        _player.enabled = !_isPause;
        _animator.enabled = !_isPause;
        _camera.enabled = !_isPause;

        Cursor.visible = _isPause;
        Cursor.lockState = _isPause ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    public void MainMenu(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
