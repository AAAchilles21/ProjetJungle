using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Camera Camera;
    public Transform player;
    public float smoothSpeed = 10f;
    public Vector3 offset = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 desPos = player.position + offset;

        Vector3 newPos = Vector3.Lerp(transform.position, desPos, smoothSpeed * Time.deltaTime);

        transform.position = newPos;
    }
}
