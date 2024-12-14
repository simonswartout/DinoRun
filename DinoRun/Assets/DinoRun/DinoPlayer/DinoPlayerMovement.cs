using UnityEngine;

public class DinoPlayerMovement : MonoBehaviour
{
    public enum MovementDirection
    {
        Left,
        Right,
        Up,
        Down,
        Idle
    }
    private MovementDirection currentDirection;
    private Vector2 movementInput;
    public float movementSpeed = 5f;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInput = Vector2.zero;
        currentDirection = MovementDirection.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from the player
        movementInput = GetMovementInput();
        // Move the player
        MovePlayer(movementInput);
        // Play the animation
        PlayAnimation(movementInput);
    }

    Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector2(horizontalInput, verticalInput);
    }

    private void MovePlayer(Vector2 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
        switch (direction)
        {
            case Vector2 _ when direction.x > 0:
                currentDirection = MovementDirection.Right;
                break;
            case Vector2 _ when direction.x < 0:
                currentDirection = MovementDirection.Left;
                break;
            case Vector2 _ when direction.y > 0:
                currentDirection = MovementDirection.Up;
                break;
            case Vector2 _ when direction.y < 0:
                currentDirection = MovementDirection.Down;
                break;
            default:
                currentDirection = MovementDirection.Idle;
                break;
        }
    }

    private void PlayAnimation(Vector2 direction)
    {
        switch (currentDirection)
        {
            case MovementDirection.Right:
                // Play right animation
                animator.Play("Walk Right");
                break;
            case MovementDirection.Left:
                // Play left animation
                animator.Play("Walk Left");
                break;
            case MovementDirection.Up:
                // Play up animation
                animator.Play("Walk Up");
                break;
            case MovementDirection.Down:
                // Play down animation
                animator.Play("Walk Down");
                break;
            case MovementDirection.Idle:
                // Play idle animation
                animator.Play("Idle");
                break;
        }
    }
}
