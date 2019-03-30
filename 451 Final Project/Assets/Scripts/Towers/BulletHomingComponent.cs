using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHomingComponent : MonoBehaviour
{

    /*
	Homing component of bullet. On collision with an enemy
	set the target to the enemies transform.
	 */
    public GameObject target;
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (target == null)
        {
            if (other.CompareTag("Enemy"))
            {
                target = other.gameObject;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (target != null)
        {
            if (other.gameObject.CompareTag(target.tag))
            {
                target = null;
            }
        }
    }
}
