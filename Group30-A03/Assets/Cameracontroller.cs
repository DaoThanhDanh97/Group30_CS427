using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [SerializeField]
    private Transform mychar;

    public void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(mychar.position.x, -6.15f, 6.15f), 0, -10);
    }
}
