using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bit : MonoBehaviour
{
    public GameObject hand;
   
    Transform pers, pruff;
    Vector3 vec;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
    }

    void    Update()
    {
        pruff = GetComponent<Transform>();
        if (pruff.position.y < -2.5f)
        {   
            gameObject.transform.position = new Vector3 (pruff.position.x, -2.5f, pruff.position.z);
        }
        else 
        {
            score.minus++;
        }
    }
    public int f = 1;
    private void OnTriggerEnter(Collider other)
    {

        pers = GetComponent<Transform>();
        vec = pers.position;
        if (other.gameObject.tag == "Player")
        {
            vec.y = vec.y + 1;
            transform.Translate(vec * Time.deltaTime);
            audioSource.Play();
        } 
        if (pruff.position.y < -2.4f && f == 1)
        {
            f = 0;
            score.scr++;
            if (score.scr > 10)
                dvizh.v = dvizh.v + ((float)Math.Sqrt(score.scr) / 10);
            else
                dvizh.v = dvizh.v + ((float)Math.Sqrt(score.scr) / 5);
        }

    }
    
}
