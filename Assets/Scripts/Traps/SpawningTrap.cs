using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrap : MonoBehaviour
{
    [SerializeField] private GameObject pfSpike;
    [SerializeField] private Trigger trigger;
    private bool checkPf;
    private GameObject currentSpike;
    
    void Update()
    {
        if (trigger.check && !checkPf)
        {   
            checkPf = true;
            currentSpike = Instantiate(pfSpike, new Vector2(transform.position.x + 1.5f, transform.position.y), Quaternion.identity);
            Invoke("DestroySpike", 2f);
        }
    }

    private void DestroySpike()
    {
        if (currentSpike != null)
        {
            Destroy(currentSpike);
        }
    }
}
