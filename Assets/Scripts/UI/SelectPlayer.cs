using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField] private InputField inputText;
    [SerializeField] private GameObject notification;

    // Button Event
    public void Player_1()
    {
        if (inputText.text == "")
        {
            notification.SetActive(true);
            return;
        }
        else
        {
            notification.SetActive(false);
            SetData();
            DataManager.SetInt(PlayerPrefKeys.SelectedPlayerID, 1);
        }
    }

    public void Player_2()
    {
        if (inputText.text == "")
        {
            notification.SetActive(true);
            return;
        }
        else
        {
            notification.SetActive(false);
            SetData();
            DataManager.SetInt(PlayerPrefKeys.SelectedPlayerID, 2);
        }
    }

    public void Player_3()
    {
        if (inputText.text == "")
        {
            notification.SetActive(true);
            return;
        }
        else
        {
            notification.SetActive(false);
            SetData();
            DataManager.SetInt(PlayerPrefKeys.SelectedPlayerID, 3);
        }
    }

    public void SetData()
    {
        DataManager.SaveString(PlayerPrefKeys.PlayerName, inputText.text);
        DataManager.SetInt(PlayerPrefKeys.CurrentLevel, 2);
        DataManager.SetInt(PlayerPrefKeys.CurrentTime, 0);
        SceneManager.LoadScene("Level 1");
    }

    // button event
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
