using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 
    public float speed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;


    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
            anim.SetBool("isMoving", success);
        }
        else {
            anim.SetBool("isMoving", false);
        }

    }
    bool TryMove(Vector2 direction) {
        int count = rb.Cast(
           direction,
           movementFilter,
           castCollision,
           speed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            return true;
        }
        else {
            return false;
        }
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }
}
