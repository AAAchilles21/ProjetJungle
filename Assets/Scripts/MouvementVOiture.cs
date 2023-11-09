using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouvementVOiture : MonoBehaviour
{
    public float vitesse;
    public Rigidbody rigi;
    public Camera cam;
    public float rotationLerp;
    public float acceleration;
    public List<Transform> roues;
    private bool onTheGround = true;
    private Vector3 directionVoiture;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(gameObject);
        }
        Vector3 positionSouris = Input.mousePosition;
        positionSouris.z = 0;
        positionSouris = cam.ScreenToWorldPoint(positionSouris);
        Vector3 direction = positionSouris - cam.transform.position;
        if (Physics.Raycast(cam.transform.position, direction * 500000, out RaycastHit hit))
        {
            Debug.Log("Hit " + hit.point);
            directionVoiture = hit.point - gameObject.transform.position;
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, directionVoiture, rotationLerp);
        }
        onTheGround = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (onTheGround)
        {
        rigi.velocity = Vector3.Lerp(rigi.velocity, transform.forward * vitesse, acceleration);
        rigi.velocity = (transform.forward + rigi.velocity.normalized).normalized * vitesse;
        }

    }
}
        