using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private bool checkPlayer;
    [SerializeField] private float speed;
    private Vector3 direction;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    [SerializeField] private float startY;
    [SerializeField] private float endY;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (!isHorizontal)
            MoveVertically();
        else MoveHorizontally();
    }

    public void Initialize()
    {
        checkPlayer = false;
        direction = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkPlayer = false;
        }
    }

    public void MoveVertically()
    {
        if (checkPlayer)
        {
            if (transform.position.y > endY)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y < startY)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    public void MoveHorizontally()
    {
        if (checkPlayer)
        {
            if (transform.position.y > endX)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y < startX)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
