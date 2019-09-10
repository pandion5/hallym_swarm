using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    private float bullet_speed = 3000.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * bullet_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
