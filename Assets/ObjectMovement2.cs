using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement2 : MonoBehaviour
{
    public float speed = 1.0f;
    public float length = 1.0f;

    private float run_time = 0.0f;
    private float PosY = 0.0f;

    // Update is called once per frame
    void Update()
    {
        run_time += Time.deltaTime * speed;
        PosY = Mathf.Sin(run_time) * length;
        Debug.Log(PosY);
        transform.position = new Vector3(0, PosY);
    }
}
