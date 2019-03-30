using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{

    public NodePrimitive node;
    public Transform enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = node.matrix.GetColumn(3);
        transform.position += (node.transform.up * 2);
        transform.up = node.transform.up;
    }

    void OnTriggerEnter(Collider other)
    {
        if (enemy == null)
        {
            if (other.CompareTag("Enemy"))
            {
                enemy = other.transform;
            }
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			if (enemy != null)
			{
				if (other.transform == enemy)
				{
					enemy = null;
				}
			}
		}
	}
}
