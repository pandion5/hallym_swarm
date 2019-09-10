using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    private float shot_limit;
    private float shot_time = 0.15f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shot_limit < 1.0f)
        {
            shot_limit += Time.deltaTime;
        }
        if(shot_limit> shot_time)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, this.transform);
                shot_limit = 0;
            }
        }
        
    }
}
