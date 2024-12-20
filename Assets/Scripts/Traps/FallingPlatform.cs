using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float maxPosY;
    [SerializeField] private float minPosY;
    [SerializeField] private Trigger trigger;
    private GameObject outFlag;
    private bool checkFall;

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkFall)
            MoveVertically();
        else SetGround();
    }

    private void Initialize()
    {
        direction = new Vector3(0, 0, 0);
        outFlag = GameObject.Find("OutFlag");
        checkFall = false;
    }

    public void MoveVertically()
    {
        if (transform.position.y > minPosY)
        {
            direction.y = -1;
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            transform.tag = "Ground";
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
            outFlag.transform.position = new Vector3(21, -3.5f, 0);
        }
    }

    public void SetGround()
    {
        if (trigger.check)
        {
            Invoke("SetCheckFall", 1f);
            transform.tag = "Traps";
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
            Debug.Log("Fall");
        }
    }

    public void SetCheckFall()
    {
        checkFall = true;
    }
}
