using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private Trigger trigger;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (trigger.check)
        {
            direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
