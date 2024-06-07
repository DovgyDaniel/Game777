using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Menu7 : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;
    public GameObject welcomePanel;
    public TMP_InputField usernameInput; // Изменено на TMP_InputField
    public Button confirmButton;

    public bool nameChanged = false;
    public string playerNameFilePath; // Путь к файлу с именем игрока

    public const string playerNameFileName = "PlayerName.txt"; // Имя файла с именем игрока

    public void Awake()
    {
        playerNameFilePath = Path.Combine(Application.persistentDataPath, playerNameFileName); // Формирование пути к файлу
        CheckPlayerName();
    }

    public void CheckPlayerName()
    {
        if (!File.Exists(playerNameFilePath)) // Если файл с именем игрока не существует
        {
            welcomePanel.SetActive(true);
        }
        else
        {
            string playerName = File.ReadAllText(playerNameFilePath); // Читаем имя игрока из файла
            SetWelcomeText(playerName);
            nameChanged = true;
            welcomePanel.SetActive(false);
        }
    }

    public void SetWelcomeText(string playerName)
    {
        welcomeText.text = "Добро пожаловать, " + playerName + "!";
    }

    public void OnSubmitUsername()
    {
        string username = usernameInput.text.Trim();
        if (!string.IsNullOrEmpty(username))
        {
            File.WriteAllText(playerNameFilePath, username); // Записываем имя игрока в файл
            nameChanged = true;

            SetWelcomeText(username);
            welcomePanel.SetActive(false);
        }
    }

    public void OnConfirmButtonClick()
    {
        if (nameChanged)
        {
            welcomePanel.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ClearPlayerName()
    {
        if (File.Exists(playerNameFilePath)) // Если файл существует
        {
            File.Delete(playerNameFilePath); // Удаляем файл с именем игрока
            nameChanged = false;
            Debug.Log("Player name has been cleared.");
        }
    }
}
