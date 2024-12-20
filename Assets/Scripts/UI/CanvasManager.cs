using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public GameObject returnImage;
    public Text timerText;
    public Text playerName;
    private int minutes;
    private int seconds;
    private bool checkWin;
    private bool activeMusic = false;
    public float elapsedTime;
    [SerializeField] GameObject gameWin;
    [SerializeField] private GameObject gamePause;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image turnOffMusic;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        checkWin = false;
        playerName.text = DataManager.LoadString(PlayerPrefKeys.PlayerName);
        elapsedTime = DataManager.GetInt(PlayerPrefKeys.CurrentTime);
        Debug.Log(elapsedTime);
        Debug.Log(playerName.text);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnApplicationQuit()
    {
        if (checkWin)
        {
            SetAchievementData();
        }
        else
        {
            // Thực hiện các hành động trước khi game tắt, ví dụ như lưu dữ liệu.
            Debug.Log("Game đang được đóng.");
            DataManager.SetInt(PlayerPrefKeys.CurrentTime, Mathf.FloorToInt(elapsedTime));
            DataManager.SetInt(PlayerPrefKeys.CurrentLevel, SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameWin()
    {
        gameWin.SetActive(true);
        checkWin = true;
    }

    public void SetAchievementData()
    {
        DataManager.SetInt(PlayerPrefKeys.CurrentLevel, 0);
        string achievementsString = DataManager.LoadString(PlayerPrefKeys.Achievements);
        string newAchievement = $"{DateTime.Now.ToString()}|{Mathf.FloorToInt(elapsedTime).ToString()}|{playerName.text}|{DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID)}";
        if (!string.IsNullOrEmpty(achievementsString))
        {
            achievementsString += ";";
        }
        achievementsString += newAchievement;
        DataManager.SaveString(PlayerPrefKeys.Achievements, achievementsString);
    }

    // Button Event
    public void TurnOffMusic()
    {
        activeMusic = !activeMusic;
        turnOffMusic.gameObject.SetActive(activeMusic);
        if (!activeMusic)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

    public void Option()
    {
        gamePause.GetComponent<GamePause>().SetData();
        gamePause.SetActive(true);
        Time.timeScale = 0;
    }
}
