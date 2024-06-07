using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System;

public class Login : MonoBehaviour 
{

	public static int loginID;
	public InputField usernameField;
    public InputField passwordField;
    public Button submitButton;
    private string connectionStr;
    public GameObject noUser;
    public GameObject passwordFailed;

    //Сделать кнопку отправки интерактивной
    public void buttonInteract()
	{
    	submitButton.interactable = (usernameField.text.Length >= 4 && usernameField.text.Length <= 20 && passwordField.text.Length >= 5 && passwordField.text.Length <= 20);
        usernameField.text = usernameField.text.Replace(" ", string.Empty);
        passwordField.text = passwordField.text.Replace(" ", string.Empty);
    }

    //Проверить, существует ли имя пользователя
    public bool usernameExists(string username)
    {
        noUser.SetActive(false);
        IDbCommand dbcmd;
        IDataReader reader;
        IDbConnection dbcon = new SqliteConnection(connectionStr);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string q_selectFromTable = "SELECT name FROM Test_players WHERE name='" + username + "';";
        dbcmd.CommandText = q_selectFromTable;
        reader = dbcmd.ExecuteReader();

        if (reader.Read() == true) // Имя пользователя существует в БД
        {
            dbcon.Close();
            return true;
        }
        dbcon.Close();
        return false;
    }


    public void getLoginInfo()
    {
        string hash;
        string saltString;
        string username = usernameField.text;
        string password = passwordField.text;

        if (usernameExists(username))
        {
            IDbCommand dbcmd;
            IDataReader reader;
            IDbConnection dbcon = new SqliteConnection(connectionStr);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            string insertToPlayers = "SELECT * FROM Test_players WHERE name='" + username + "';";
            dbcmd.CommandText = insertToPlayers;
            reader = dbcmd.ExecuteReader();
            reader.Read();
            hash = reader["password"].ToString(); // Получить хэш из БД
            saltString = ""; // Соль не используется в этой версии кода
            dbcon.Close();

            if (password != hash)
            {
                passwordFailed.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            noUser.SetActive(true);
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

    void Update()
	{
    	buttonInteract();  //Проверьте, выполняются ли условия ввода в каждом кадре, а затем сделайте кнопку интерактивной
    }

}
