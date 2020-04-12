using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onjects : MonoBehaviour
{
    private Transform obj;
    public static float objSpeed = 10;

    private void Awake()
    {
        obj = GetComponent<Transform>();
    }
    void Update()
    {
        if (PlayerScript.hasStarted) obj.transform.position -= new Vector3(objSpeed * Time.deltaTime, 0, 0);
    }
}
