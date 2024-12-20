using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    private Vector3 direction;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        direction = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (transform.position.x <= minPosX)
        {
            direction.x = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (transform.position.x >= maxPosX)
        {
            direction.x = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
