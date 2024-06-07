using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenuManager : MonoBehaviour
{
    public GameObject saveMenu;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu" || scene.name == "Конец(титры)")
        {
            saveMenu.SetActive(false);
        }
        else
        {
            saveMenu.SetActive(true);
        }
    }
}

