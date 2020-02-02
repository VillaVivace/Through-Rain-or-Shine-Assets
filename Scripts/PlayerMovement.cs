using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public string state = "normal";

    Vector2 movement;

    public Animator playerAnim;

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        playerAnim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        playerAnim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate() {
        switch(state) {
            case "normal":
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                break;
            case "talking":
                break;
            default:
                break;
        }
    }
}
