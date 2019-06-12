using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Vector3 myPos;
    public Transform mychar;

    public void Update()
    {
        float newx = mychar.position.x + myPos.x;
        transform.position.Set(newx, myPos.y, myPos.z);
    }
}
