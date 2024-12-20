using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class AchievementManager : MonoBehaviour
{
    private bool activeMusic = false;
    private GameObject[] slotAchievements;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image turnOffMusic;
    [SerializeField] private GameObject pfAchievementSlot;
    [SerializeField] private GameObject content;

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

    // button event
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {
        // lay tat ca thanh tuu
        string achievementsString = DataManager.LoadString(PlayerPrefKeys.Achievements);
        if (!string.IsNullOrEmpty(achievementsString))
        {
            string[] achievementItems = achievementsString.Split(';');
            List<(string achievementItem, int playTime)> achievementsList = new List<(string, int)>();
            foreach (string achievementItem in achievementItems)
            {
                string[] attributes = achievementItem.Split('|');
                int playTime = int.Parse(attributes[1]);
                achievementsList.Add((achievementItem, playTime));
            }
            achievementsList.Sort((a, b) => a.playTime.CompareTo(b.playTime));
            for (int i = 0; i < achievementsList.Count; i++)
            {
                if (i < 10)
                {
                    string[] attributes = achievementsList[i].achievementItem.Split('|');
                    GameObject achievementSlot = Instantiate(pfAchievementSlot, content.transform);
                    achievementSlot.GetComponent<AchievementSlot>().GetDataIntoSlot(
                        attributes[0],
                        int.Parse(attributes[1]),
                        attributes[2],
                        int.Parse(attributes[3]),
                        i + 1
                    );
                }
            }
        }
    }

}
