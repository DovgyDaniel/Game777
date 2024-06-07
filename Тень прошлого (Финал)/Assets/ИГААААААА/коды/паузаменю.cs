using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class паузаменю : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        pauseGameMenu.transform.SetAsLastSibling(); // Перемещаем панель на передний план
        foreach (Transform child in pauseGameMenu.transform)
        {
            child.SetAsLastSibling(); // Перемещаем все дочерние элементы (например, кнопки) на передний план
        }
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LostMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        var musicManager = FungusManager.Instance.MusicManager;
        if (musicManager != null)
        {
            musicManager.StopMusic();
        }
    }
}
