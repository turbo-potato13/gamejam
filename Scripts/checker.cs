using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "gvozd")
            {
            if (other.transform.position.y > -2.5f)
            {
                handbit.health -= 5;
            }
                Debug.Log(handbit.health);
            }

    }
}
