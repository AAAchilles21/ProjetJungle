using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    public Rigidbody rigi;
    public float explosionRadius;
    public float explosionForce;
    public float vitesse;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Destroy(gameObject, 1);
    }

    private void FixedUpdate()
    {
        rigi.velocity = transform.forward * vitesse;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision " + collision.collider.name);
        Collider[] result = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in result)
        {
            Rigidbody r = collider.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject);
    }
}
