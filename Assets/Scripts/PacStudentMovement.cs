using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    // Grid for the top left inner block
    public Vector3[] grid = {
        // top left
        new Vector3(19.0f, -0.7f, 0f),
        // top right
        new Vector3(27.5f, -0.7f, 0f),
        // bottom right
        new Vector3(27.5f, -9f, 0f),
        // bottom left
        new Vector3(19f, -9f, 0f)           
    };

    // Movement speed
    public float speed = 2.0f;
    private int currentGridPosition = 0;
    private bool isMoving = false;

    private void Start()
    {
        // Set initial position
        transform.position = grid[0];
        isMoving = true;
        // Begin movement
        StartMovement();
    }

    void Update()
    {
        if (isMoving)
        {
            // Move towards grid position
            transform.position = Vector3.MoveTowards(transform.position, grid[currentGridPosition], speed * Time.deltaTime);

            // When reaching the current grid position, move towards the next grid position
            if (Vector3.Distance(transform.position, grid[currentGridPosition]) < 0.01f)
            {
                // Update to the next waypoint, or loop to the start if at the last waypoint
                currentGridPosition = (currentGridPosition + 1) % grid.Length;

                // Update rotation to face the next grid position
                UpdateRotation();
            }
        }
    }

    void UpdateRotation()
    {
        // Ensure there is a new grid position
        if (currentGridPosition < grid.Length)
        {
            Vector3 direction = grid[currentGridPosition] - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void StartMovement()
    {
        isMoving = true;
    }

    public void StopMovement()
    {
        isMoving = false;
    }
}
