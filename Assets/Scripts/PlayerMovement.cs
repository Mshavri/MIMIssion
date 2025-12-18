using UnityEngine;

// Simple player movement script with animation control
public class PlayerMovement : MonoBehaviour
{
    public Animator anim;      // Animator linked to the character
    public float moveSpeed;    // Movement speed

    private Rigidbody2D rb;    // Physics component
    private Vector2 input;     // Movement direction
    private bool moving;       // Movement state

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D from this object
    }

    private void Update()
    {
        GetInput();   // Read player input
        Animate();    // Update animations
    }

    private void FixedUpdate()
    {
        // Move player using physics
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        // Read keyboard input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Normalize direction to keep speed consistent
        input = new Vector2(x, y).normalized;
    }

    private void Animate()
    {
        // Check if player is moving
        moving = input.sqrMagnitude > 0.01f;

        // Send direction to animator while moving
        if (moving)
        {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
        }

        // Send movement state to animator
        anim.SetBool("Moving", moving);
    }
}
