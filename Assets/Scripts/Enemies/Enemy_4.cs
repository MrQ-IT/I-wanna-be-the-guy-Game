using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    [SerializeField] private GameObject pfCannonBall;
    private GameObject cannonBall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cannonBall != null) {
            cannonBall.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);
            if ( cannonBall.transform.position.x < -25)
            {
                Destroy(cannonBall);
                cannonBall = null;
            }
        }
    }

    // Animation Event
    private void Spawn()
    {
        if (cannonBall == null) 
        { 
            cannonBall = Instantiate(pfCannonBall, transform.position, Quaternion.identity);
        }
    }
}
