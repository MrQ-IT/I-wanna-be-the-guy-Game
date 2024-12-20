using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField] private Text dateTime;
    [SerializeField] private Text playTime;
    [SerializeField] private Text playerName;
    [SerializeField] private Image player;
    [SerializeField] private Sprite[] playerImage;
   
    public void SetData()
    {
        dateTime.text = "Date: " + DateTime.Now.ToString();
        playerName.text = "Player Name: " + DataManager.LoadString(PlayerPrefKeys.PlayerName);
        playTime.text = "PLay Time: " + Mathf.FloorToInt(CanvasManager.instance.elapsedTime).ToString();
        int x = DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID);
        for (int i = 0; i < playerImage.Length; i++)
        {
            if (i == x - 1) player.sprite = playerImage[i];
        }
    }

    // Button Event
    public void Home()
    {
        DataManager.SetInt(PlayerPrefKeys.CurrentTime, Mathf.FloorToInt(CanvasManager.instance.elapsedTime));
        DataManager.SetInt(PlayerPrefKeys.CurrentLevel, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
        Destroy(CanvasManager.instance.gameObject);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Select Player");
        Time.timeScale = 1.0f;
        Destroy(CanvasManager.instance.gameObject);
    }
    
    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
