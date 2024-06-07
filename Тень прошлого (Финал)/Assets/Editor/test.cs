using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class test
{
    [Test]
    public void OnConfirmButtonClick_HidesWelcomePanel_WhenNameChanged()
    {
        // Arrange
        var menu = new GameObject().AddComponent<Menu7>();
        menu.welcomePanel = new GameObject();
        menu.nameChanged = true;

        // Act
        menu.OnConfirmButtonClick();

        // Assert
        Assert.IsFalse(menu.welcomePanel.activeSelf);
    }
    


    [Test]
    public void ClearPlayerName_DeletesPlayerNameFile()
    {
        // Arrange
        var menu = new GameObject().AddComponent<Menu7>();
        string playerNameFilePath = Path.Combine(Application.persistentDataPath, "PlayerName.txt");
        File.WriteAllText(playerNameFilePath, "TestPlayerName");

        // Act
        menu.ClearPlayerName();

    }

 
    [Test]
    public void CheckPlayerName_ShowsWelcomeText_WhenPlayerNameFileExists()
    {
        // Arrange
        var menu = new GameObject().AddComponent<Menu7>();
        string playerNameFilePath = Path.Combine(Application.persistentDataPath, "PlayerName.txt");
        File.WriteAllText(playerNameFilePath, "TestPlayerName");
        menu.welcomeText = new GameObject().AddComponent<TextMeshProUGUI>(); // Создаем новый GameObject для welcomeText

    }


    [Test]
    public void OnSubmitUsername_WritesUsernameToFile()
    {
        // Arrange
        var menu = new GameObject().AddComponent<Menu7>();
        string playerNameFilePath = Path.Combine(Application.persistentDataPath, "PlayerName.txt");
        File.WriteAllText(playerNameFilePath, "TestPlayerName");
        menu.welcomeText = new GameObject().AddComponent<TextMeshProUGUI>(); // Создаем новый GameObject для welcomeTex

    }
    public void CheckPlayerName_ShowsWelcomePanel_WhenPlayerNameFileNotExists()
    {
        // Arrange
        var menu = new GameObject().AddComponent<Menu7>();
        string playerNameFilePath = Path.Combine(Application.persistentDataPath, "PlayerName.txt");
        if (File.Exists(playerNameFilePath))
        {
            File.Delete(playerNameFilePath);
        }
        menu.welcomePanel = new GameObject(); // Создаем новый GameObject для welcomePanel

        // Act
        menu.Awake();

        // Assert
        Assert.IsTrue(menu.welcomePanel.activeSelf);
    }

}
