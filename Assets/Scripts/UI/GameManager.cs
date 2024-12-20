using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    private GameObject[] gameObjects;
    private Vector3 playerPos;
    [SerializeField] private GameObject[] pfPlayer;

    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {   
        if ( SceneManager.GetActiveScene().name == "Level 3")
        {
            playerPos = new Vector3(-22, 8, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            playerPos = new Vector3(-23, 0, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            playerPos = new Vector3(6.5f, -10, 0);
        }
        else
        {
            playerPos = new Vector3(-20, -3, 0);
        }

        if ( DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID) == 1)
        {
            Instantiate(pfPlayer[0], playerPos, Quaternion.identity);
        }
        else if ( DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID) == 2)
        {
            Instantiate(pfPlayer[1], playerPos, Quaternion.identity);
        }
        else if (DataManager.GetInt(PlayerPrefKeys.SelectedPlayerID) == 3)
        {
            Instantiate(pfPlayer[2], playerPos, Quaternion.identity);
        }
    }

    public void ResetGame()
    {   
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
