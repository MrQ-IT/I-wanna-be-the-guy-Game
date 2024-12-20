using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] lightning;

    private void Start()
    {
        InvokeRepeating("EnableLightning", 2f, 2f);
    }

    public void EnableLightning()
    {
        for (int i = 0; i < lightning.Length; i++)
        {
            lightning[i].SetActive(true);
        }
    }
}
