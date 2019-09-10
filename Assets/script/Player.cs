using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 100;
    private int speed = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장
        mPosition.z = oPosition.z - Camera.main.transform.position.z;


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



        rb.AddForce(movement * speed);
    }
}
