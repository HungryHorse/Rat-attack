using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject tooltipObject;
    public Canvas canvas;
    GameObject currentToolTip;
    public string toolTipDescription;
    public string toolTipTitle;
    public string cost;
    public bool castOnLeft;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentToolTip = Instantiate(tooltipObject, canvas.transform);
        if (castOnLeft)
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x - (Screen.width * 0.4f) , gameObject.transform.position.y - Screen.height * 0.4f);
        }
        else
        {
            currentToolTip.transform.position = new Vector3(gameObject.transform.position.x + 2.8f, gameObject.transform.position.y - 1.2f);
        }

        currentToolTip.transform.GetChild(0).GetComponent<Text>().text = toolTipDescription;
        currentToolTip.transform.GetChild(1).GetComponent<Text>().text = toolTipTitle;
        currentToolTip.transform.GetChild(2).GetComponent<Text>().text = "Cost: " + cost;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentToolTip);
    }
}
