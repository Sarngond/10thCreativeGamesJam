using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AnimationClip attackAnim;
    public AnimationClip attack2Anim;

    private Animator anim;
    private PlayerMovement playerMovement;

    private float attack2Length = 0f;
    private bool isAttacking = false;

    private float lastClickTime;
    private float clickCatchTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack() {
        if (Input.GetButtonDown("Fire1")) {
            playerMovement.enabled = false;
            anim.SetBool("isWalking", false);

            if (Time.time - lastClickTime < clickCatchTime) {
                anim.SetTrigger("Attack2");
                playerMovement.enabled = false;
                //attack2Length = attack2Anim.length + 0.25f;
                isAttacking = true;
            }
            else if (!isAttacking) {
                anim.SetTrigger("Attack");
                attack2Length = 0f;
                isAttacking = true;
            }
            Invoke("StartMoving", attackAnim.length + 0.5f + attack2Length);
            lastClickTime = Time.time;
        }

    }

    private void StartMoving() {
        playerMovement.enabled = true;
        isAttacking = false;
    }
}
