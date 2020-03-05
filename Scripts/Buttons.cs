using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button[] buttons;
    public Letter[] keys;
    public GameObject rect;
    RectTransform r;
    // Update is called once per frame
    void Update()
    {
       if (!buttons[0].IsActive() && !buttons[1].IsActive() && !buttons[2].IsActive())
        {
            CollectWord.movable = true;
            rect.SetActive(true);
            r = rect.GetComponent<Image>().rectTransform;
        }
       if(rect.activeSelf)
        {
            int num = 0;
            foreach (var item in keys)
            {
                if (r.rect.Contains(new Vector2(item.transform.localPosition.x, item.transform.localPosition.y)))
                    num++;
            }
            if(num == 8)
            {
                SceneManager.LoadScene("vidos");
            }
        }
    }
}
