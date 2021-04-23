using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward, ForceMode.Impulse);
        Destroy(gameObject, 4f);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == other)
        {
            Destroy(gameObject);
        }
    }

}
