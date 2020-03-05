using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Disappear : MonoBehaviour
{
    private TextMeshProUGUI text;
    public Vector3 delta;
    public TextMeshProUGUI[] letters;
    void Start()
    {
        GameObject[] let = GameObject.FindGameObjectsWithTag("letter");
        for (int i = 0; i < let.Length; i++)
        {
            letters[i] = let[i].GetComponent<TextMeshProUGUI>();
        }
        text = GetComponent<TextMeshProUGUI>();
    }
    public void IncreaseSize()
    {
        text.fontSize += 5;
        text.color = Color.Lerp(Color.white, Color.red, text.fontSize / 200);
        if (text.fontSize >= 130)
        {
            gameObject.SetActive(false);
            foreach (var item in letters)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a + 0.1f);
            }
        }
        transform.Translate(delta);
    }
}