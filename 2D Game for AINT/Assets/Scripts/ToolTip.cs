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
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentToolTip = Instantiate(tooltipObject, canvas.transform);
        currentToolTip.transform.position = new Vector3 (gameObject.transform.position.x - 11.5f, gameObject.transform.position.y - 12f);

        currentToolTip.transform.GetChild(0).GetComponent<Text>().text = toolTipDescription;
        currentToolTip.transform.GetChild(1).GetComponent<Text>().text = toolTipTitle;
        currentToolTip.transform.GetChild(2).GetComponent<Text>().text = "Cost: " + cost;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentToolTip);
    }
}
