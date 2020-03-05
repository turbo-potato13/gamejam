using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text text;
    public static int scr = 0;
    public static int minus = 0;
    void Update()
    {
        text.text = ("Score:  " + scr);
    }
}
