using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayObject : MonoBehaviour
{
    private bool checkFall;
    [SerializeField] private float speed;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private Trigger trigger;
    
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHorizontal)
        {
            if ( trigger.check == true)
            {
                checkFall = true;
            }
            if (checkFall)
            {
                FlyHorizontally();
            }
        }
        else
        {
            if (trigger.check == true)
            {
                checkFall = true;
            }
            if (checkFall)
            {
                FlyVertically();
            }
        }
    }

    private void Initialize()
    {
        checkFall = false;
        
    }

    // bay theo chieu ngang
    public void FlyVertically()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    // bay theo chieu doc
    public void FlyHorizontally()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
