using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Menu7 : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;
    public GameObject welcomePanel;
    public TMP_InputField usernameInput; // �������� �� TMP_InputField
    public Button confirmButton;

    public bool nameChanged = false;
    public string playerNameFilePath; // ���� � ����� � ������ ������

    public const string playerNameFileName = "PlayerName.txt"; // ��� ����� � ������ ������

    public void Awake()
    {
        playerNameFilePath = Path.Combine(Application.persistentDataPath, playerNameFileName); // ������������ ���� � �����
        CheckPlayerName();
    }

    public void CheckPlayerName()
    {
        if (!File.Exists(playerNameFilePath)) // ���� ���� � ������ ������ �� ����������
        {
            welcomePanel.SetActive(true);
        }
        else
        {
            string playerName = File.ReadAllText(playerNameFilePath); // ������ ��� ������ �� �����
            SetWelcomeText(playerName);
            nameChanged = true;
            welcomePanel.SetActive(false);
        }
    }

    public void SetWelcomeText(string playerName)
    {
        welcomeText.text = "����� ����������, " + playerName + "!";
    }

    public void OnSubmitUsername()
    {
        string username = usernameInput.text.Trim();
        if (!string.IsNullOrEmpty(username))
        {
            File.WriteAllText(playerNameFilePath, username); // ���������� ��� ������ � ����
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
        if (File.Exists(playerNameFilePath)) // ���� ���� ����������
        {
            File.Delete(playerNameFilePath); // ������� ���� � ������ ������
            nameChanged = false;
            Debug.Log("Player name has been cleared.");
        }
    }
}
