using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Letter : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        if(CollectWord.movable)
            transform.position = Input.mousePosition;
    }
}
