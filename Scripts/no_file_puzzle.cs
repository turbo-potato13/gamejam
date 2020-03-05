using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class no_file_puzzle : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {

        if (File.Exists("./pepega"))
            Debug.Log("WRONG!");
        else
        {
           Debug.Log("Correct!");
        }
    }
    void Update()
    {
		
    }

}
