using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectWord : MonoBehaviour
{
    public TextMeshProUGUI[] letters;
    public static bool movable = false;
    private void Start()
    {
        foreach (var item in letters)
        {
            item.transform.Rotate(new Vector3(0,0,1),Random.Range(-70, 70));
        }
    }
}
