using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 

public class handbit : MonoBehaviour
{ 
    public  Slider mainSlider;
    public GameObject plr;
    Random rnd = new Random();
    public Rigidbody ruka;
    public Transform tr;
    public static int health = 101;
    public Image endgame;
    Vector3 strt;
    int f;
    float time;
    float vremya = 0;

    void Start() 
    {
        mainSlider.value = 0;
        ruka = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        strt = tr.position;
    }
    void Update() 
    {
        time = time + Time.deltaTime;
        float del = Random.Range(0f, 0.5f);
        mainSlider.value = (float)health/100;
        
      
        vremya = vremya + Time.deltaTime;
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {   
            vremya = 0;
             
            Vector3 opa = new Vector3 (0, 1, 0);
            ruka.AddForce(opa * -45000f * 1);
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            vremya = 0;
            plr.transform.position = strt;
            ruka.velocity = new Vector3(0, 0, 0);
        }
        if (health <= 0)
        {
            endgame.gameObject.SetActive(true);
        }
    }
    
    
}
