using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {
    public Transform target;
    public float smoothing = 5.0f;

    void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(this);
        }

        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.1f));
    }

}
