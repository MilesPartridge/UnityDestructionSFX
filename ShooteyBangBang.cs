using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooteyBangBang : MonoBehaviour
{
    
    public GameObject prefab;
    public float speed = 100.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    Instantiate(projectile, sp.transform.position, transform.rotation);
        if (Input.GetMouseButtonDown(0))
        {
         //   GameObject bullet = Instantiate(prefab, transform.position,  transform.rotation) as GameObject;
            GameObject bullet = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(transform.forward * speed);
        }
    }
}
