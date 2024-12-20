using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 startPos;
    [SerializeField] private float loopPos;
    [SerializeField] private bool isHorizontal;
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (isHorizontal)
            MoveHorizontally();
        else
            MoveVertically();
    }


    public void MoveHorizontally()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= loopPos)
        {
            transform.position = startPos;
        }
    }

    public void MoveVertically()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= loopPos)
        {
            transform.position = startPos;
        }
    }
}
