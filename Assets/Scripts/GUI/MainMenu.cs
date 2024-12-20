using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image turnOffMusic;
    private bool activeMusic = false;
    private AudioSource audioSource;
    [SerializeField] private AudioSource button;
    [SerializeField] private GameObject notification;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        button.Play();
        notification.SetActive(false);
        Invoke("LoadSelectPlayer", button.clip.length - 0.5f);
    }

    public void LoadSelectPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        button.Play();
        Invoke("LoadCurrentScene", button.clip.length - 0.5f);
    }

    public void LoadCurrentScene()
    {
        if (DataManager.GetInt(PlayerPrefKeys.CurrentLevel) == 0)
        {
            notification.SetActive(true);
            return;
        }
        else
            SceneManager.LoadScene(DataManager.GetInt(PlayerPrefKeys.CurrentLevel));
    }

    public void Achievement()
    {
        button.Play();
        Invoke("LoadAchievementScene", button.clip.length - 0.5f);
    }

    public void LoadAchievementScene()
    {
        SceneManager.LoadScene("Achievement");
    }

    public void ExitGame()
    {
        button.Play();
        Application.Quit();
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


}
