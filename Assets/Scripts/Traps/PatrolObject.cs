using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (isHorizontal)
            MoveHorizontally();
        else MoveVertically();
    }

    public void Initialize()
    {
        direction = Vector3.zero;
    }

    public void MoveHorizontally()
    {
        if (transform.position.x >= maxPosX)
        {
            direction.x = -1;
        }
        if (transform.position.x <= minPosX)
        {
            direction.x = 1;
        }
        transform.Translate(direction * Time.deltaTime * speed);
    }

    public void MoveVertically()
    {
        if (transform.position.y >= maxPosY)
        {
            direction.y = -1;
        }
        if (transform.position.y <= minPosX)
        {
            direction.y = 1;
        }
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
