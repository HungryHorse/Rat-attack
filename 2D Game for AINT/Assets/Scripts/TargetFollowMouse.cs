using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowMouse : MonoBehaviour {
    public Camera theCamera;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void MakeCursorVisable()
    {
        Cursor.visible = true;
    }

    public void MakeCursorInvisable()
    {
        Cursor.visible = false;
    }

    void Update () {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 newPos = new Vector3(target.x, target.y);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.1f));
    }
}
