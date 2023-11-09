using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MissileLauncher : MonoBehaviour
{
    public Rigidbody rigi;
    public float explosionRadius;
    public float explosionForce;
    public float vitesse;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.useGravity = false;
    }

    private void FixedUpdate()
    {
        rigi.velocity = transform.forward * vitesse * Time.fixedDeltaTime;
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
    }
}
