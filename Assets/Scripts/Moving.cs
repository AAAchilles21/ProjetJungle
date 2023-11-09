using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody body;
    public Camera Camera;
    private Vector3 directionCorps;
    public Surface currentSurface;
    private Vector3 directionVoiture;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.transform.position += new Vector3(0, 0, 0.01f);
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.transform.position += new Vector3(0, 0, -0.01f);
            body.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.transform.position += new Vector3(0.01f, 0, 0);
            body.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.transform.position += new Vector3(-0.01f, 0, 0);
            body.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.transform.position += new Vector3(0, 1f, 0);
        }

        Vector3 positionSouris = Input.mousePosition;
        positionSouris.z = 5;
        positionSouris = Camera.ScreenToWorldPoint(positionSouris);
        Vector3 direction = positionSouris - Camera.transform.position;
        if (Physics.Raycast(Camera.transform.position, direction * 500, out RaycastHit hit))
        {
            directionVoiture = hit.point - gameObject.transform.position;
            directionVoiture.y = 0;
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, directionVoiture, currentSurface.rotationLerp);

        }
    }
}