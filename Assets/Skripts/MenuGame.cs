using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGame : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenuUI;
    [SerializeField] private static bool _gameIsPause;

    #region UnityMethods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    #endregion


    #region Methods

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
        _gameIsPause = false;
    }

    public void Resume()
    {
        _panelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPause = false;
    }

    public void Pause()
    {
        _panelMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPause = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion
}