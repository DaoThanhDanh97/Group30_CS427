using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Vector3 myPos;
    public Transform mychar;

    public void Update()
    {
        transform.position = mychar.position + myPos;
    }
}
