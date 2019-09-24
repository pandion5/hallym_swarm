using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 100;
    private int speed = 20;

    public GameObject bullet_sopt;
    public GameObject bullet;

    private float shot_limit;           //한 탄창?
    private float shot_speed = 3.0f;    //발사 속도
    private float shot_time=0;            //발사 시간?
    private bool reload = false;
    private float reload_time = 2.0f;

    private Rigidbody rb;

    private Animator anim;

    /*
    애니메이션 스피드

    */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(bullet_sopt.transform.position, 0.1f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        shot_limit = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shot_time);
        if (Input.GetMouseButton(1))
        {

            anim.SetBool("aim", true);
            if (reload)
            {
                reload_time -= Time.deltaTime;
                if (reload_time <= 0)
                {
                    shot_time = shot_limit;
                    reload_time = 2.0f;
                    reload = false;
                }
            }
            
            if (shot_time > 0 && !reload)
            {
                if (Input.GetMouseButton(0))
                {
                    shot_time -= 1.0f;
                    if(shot_time%shot_speed == 0)
                    {
                        Debug.Log("shot!");
                        anim.SetBool("attack", true);
                        Instantiate(bullet, bullet_sopt.transform);
                    }
                }
                else
                {
                    anim.SetBool("attack", false);
                    reload = true;
                }
            }
            else
            {
                anim.SetBool("attack", false);
                reload = true;
            }
        }
        else
        {
            anim.SetBool("aim", false);
        }


        
    }

    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);


        //Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        //Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장
        //mPosition.z = oPosition.z - Camera.main.transform.position.z;





    }
}
