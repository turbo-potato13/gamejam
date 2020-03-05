using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textFlick : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float animSpeedInSec = 1f;
    bool keepAnimating = false;

    private IEnumerator anim()
    {

        Color currentColor = textMesh.color;

        Color invisibleColor = textMesh.color;
        invisibleColor.a = 0; //Set Alpha to 0

        float oldAnimSpeedInSec = animSpeedInSec;
        float counter = 0;
        while (keepAnimating)
        {
            //Hide Slowly
            while (counter < oldAnimSpeedInSec)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //Reset counter when Speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter += Time.deltaTime;
                textMesh.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }

            yield return null;


            //Show Slowly
            while (counter > 0)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //Reset counter when Speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter -= Time.deltaTime;
                textMesh.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
        }
    }

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (CollectWord.movable)
        {
            startTextMeshAnimation();
        }
    }
    //Call to Start animation
    void startTextMeshAnimation()
    {
        if (keepAnimating)
        {
            return;
        }
        keepAnimating = true;
        StartCoroutine(anim());
    }
}

