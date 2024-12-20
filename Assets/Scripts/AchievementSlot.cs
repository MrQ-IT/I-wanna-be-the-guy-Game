using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    public Text dateTime;
    public Text playTime;
    public Text playerName;
    public Text top;
    public Image player;
    public Sprite[] playerImage;

    public void GetDataIntoSlot(string dateTime, int playTime, string playerName, int indexImage, int top)
    {
        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);
        this.dateTime.text = dateTime;
        this.playTime.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        this.playerName.text = playerName;
        this.player.sprite = playerImage[indexImage - 1];
        this.top.text = "Top " + top;
    }
}
