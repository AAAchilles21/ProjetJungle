using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public Missile missilePrefab;
    public Transform spawnPoint;
    public float vitesse;
    public Rigidbody balle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Missile projectile = Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);
            projectile.vitesse = vitesse;    
        }
    }
}
