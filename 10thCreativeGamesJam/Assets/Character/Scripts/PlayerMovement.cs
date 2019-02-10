using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float strafeSpeed = 5f;

    private Animator anim;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
    }

    private void Move () {
        float h = Input.GetAxis("Horizontal") * strafeSpeed;
        float v = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(h,0,v);

        transform.Translate(movement * Time.deltaTime);

        if(h == 0 && v == 0) {
            canMove = false;
        } else {
            canMove = true;
        }

        anim.SetBool("isWalking", canMove);
        anim.SetFloat("VelocityX", h);
        anim.SetFloat("VelocityZ", v);
        
    }

    private void Attack () {
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Attack");
        }
        
    }
}
