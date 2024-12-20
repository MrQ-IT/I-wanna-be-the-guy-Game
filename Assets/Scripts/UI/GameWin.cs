using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    [SerializeField] private Text dateTime;
    [SerializeField] private Text playTime;
    [SerializeField] private Text playerName;
    [SerializeField] private Image player;
    [SerializeField] private Sprite[] playerImage;

    private void Start()
    {
        int minutes = Mathf.FloorToInt(CanvasManager.instance.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(CanvasManager.instance.elapsedTime % 60);
        dateTime.text = "Date: " + DateTime.Now.ToString();
        playerName.text = "Player Name: " + DataManager.LoadString(PlayerPrefKeys.PlayerName);
        playTime.text = "PLay Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        int x = DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID);
        for (int i = 0; i < playerImage.Length; i++)
        {
            if (i == x - 1) player.sprite = playerImage[i];
        }
    }

    // Button Event
    public void Home()
    {
        CanvasManager.instance.SetAchievementData();
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
        Destroy(CanvasManager.instance.gameObject);
    }

    public void Retry()
    {
        CanvasManager.instance.SetAchievementData();
        SceneManager.LoadScene("Select Player");
        Time.timeScale = 1.0f;
        Destroy(CanvasManager.instance.gameObject);
    }
}
