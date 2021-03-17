using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D myBody;
    Animator animator;
    Vector2 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        myBody.MovePosition(myBody.position + movement * speed * Time.fixedDeltaTime);
    }
}
