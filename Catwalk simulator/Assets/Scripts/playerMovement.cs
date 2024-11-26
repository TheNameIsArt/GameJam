using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator; // Reference to Animator
    public float speed = 5f;  // Forward movement speed
    public float turnSpeed = 100f; // Turning speed
    private float gameEndPositionY = -5f;
    
    void Update()
    {
        float moveDirection = 0;

        // Check for input
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1; // Left turn
            animator.Play("Left", 0); // Force play LeftTurn animation
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime); // Rotate left
            
            // Always move downward (negative Y direction)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1; // Right turn
            animator.Play("Right", 0); // Force play RightTurn animation
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime); // Rotate right
            
            // Always move downward (negative Y direction)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Update Animator parameters
        animator.SetFloat("MoveDirection", moveDirection);
        animator.SetBool("isStopping", moveDirection == 0);    

        // Check if the character has reached the end of the game
        if (transform.position.y <= gameEndPositionY)
        {
            EndGame(); // End the game if the player reaches the target position
        }  
    }

    void EndGame()
        {
            // End the game when the player reaches the end trigger
            Time.timeScale = 0; // Stop time
            Debug.Log("Game Over: Reached the end of the game!");

            // Optionally, you could trigger an end screen, transition, or restart the level
            // UIManager.ShowGameEndScreen();
        } 
}
