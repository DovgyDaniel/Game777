using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public Button submitButton;
    private string connectionStr;
    public Text userExists;

    public void verifyInputLengths()
    {
        submitButton.interactable = (usernameField.text.Length >= 4 && usernameField.text.Length <= 20 && passwordField.text.Length >= 5 && passwordField.text.Length <= 20);
        usernameField.text = usernameField.text.Replace(" ", string.Empty);
        passwordField.text = passwordField.text.Replace(" ", string.Empty);
    }

    // Проверить, существует ли имя пользователя
    public bool usernameNotExists()
    {
        userExists.gameObject.SetActive(false); // Отключить пользовательский интерфейс перед повторной проверкой, существует ли пользователь
        IDbCommand dbcmd;
        IDataReader reader;
        IDbConnection dbcon = new SqliteConnection(connectionStr);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string q_selectFromTable = "SELECT name FROM Test_players WHERE name='" + usernameField.text + "';";

        dbcmd.CommandText = q_selectFromTable;
        reader = dbcmd.ExecuteReader();

        if (reader.Read() == false) // Имя пользователя прошло проверку
        {
            return true;
        }

        return false;
    }

    public void insertUser()
    {
        if (usernameNotExists())
        {
            IDbCommand dbcmd;
            IDbConnection dbcon = new SqliteConnection(connectionStr);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            string insertToPlayers = "INSERT INTO Test_players (name, password) VALUES ('" + usernameField.text + "','" + passwordField.text + "');";
            dbcmd.CommandText = insertToPlayers;
            dbcmd.ExecuteNonQuery(); // Добавление аккаунта
            dbcon.Close(); // Закрытое соединение с базой данных
            SceneManager.LoadScene("loginMenu"); // Если пользователь был создан, войдите в систему перед игрой
        }
        else
        {
            userExists.gameObject.SetActive(true); // Включить пользовательский интерфейс, который предупреждает, что имя пользователя занято
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu77");
    }

    void Start()
    {
        connectionStr = "URI=file:" + Application.dataPath + "/StreamingAssets/DataUsers.db";
    }
}
