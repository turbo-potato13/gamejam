using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dvizh : MonoBehaviour
{
    public GameObject gvozd;
    public GameObject re;
    static public float  v = 9;
    Transform str;
    int f = 1;

    void Initialize()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        str = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
       gameObject.transform.Translate(new Vector3( -1, 0, 0) * Time.deltaTime * v); 

        if (gameObject.transform.position.x < -70)
        {
            Instantiate(Resources.Load("doska"), new Vector3 (56.82f, transform.position.y, transform.position.z), Quaternion.identity);
            // Instantiate(re, new Vector3 (56.82f, -9.625356f, 65.47443f), Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
