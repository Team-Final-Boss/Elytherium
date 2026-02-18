using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

/// <summary>
///     MoveScript is responsible for handling the player's movement and physics interactions. It uses a Rigidbody component to apply forces for movement and gravity, and it checks for ground collisions to determine when the player is grounded. The script allows for movement in the horizontal plane based on player input and applies gravity when the player is not grounded. This script should be attached to the player GameObject that has a Rigidbody component, and it should be configured with appropriate values for velocity, gravitational force, ground check distance, and ground layer in the Unity Inspector.
/// </summary>
/// 
/// 
public class MoveScript : MonoBehaviour
{

    #region global variables

    #region physics constants
    // changed from public to serialized private to encapsulate fields while still allowing them to be edited in the Unity Inspector
    [SerializeField] float velocity = 20f;
    [SerializeField] float gravitationalForce = 9.81f;

    // Ground is used to determine if the player is currently on the ground, which affects movement and gravity behavior. Ground check distance is the distance used for raycasting to check for ground collisions, and ground layer specifies which layers are considered ground for collision detection.
    [SerializeField] float groundCheckDistance = 0.2f;

    #endregion
        
    private Vector3 currentInputDirection;

    private Rigidbody body;
    private bool isOnFloor;

    // hitFloor is used to store information about the ground collision detected by the raycast in the CheckGround method. It contains details such as the point of contact, the normal of the surface, and the distance to the ground, which can be used for movement calculations and to determine how the player interacts with different types of terrain (e.g., slopes).
    private RaycastHit hitFloor;

    // LayerMask is used to specify which layers are considered ground for the purpose of ground checking. This allows the raycast in the CheckGround method to only detect collisions with objects on the specified ground layer, improving performance and accuracy in determining whether the player is grounded.
    [SerializeField] LayerMask groundLayer;

    #endregion

    #region Unity Methods
    /// <summary>
    ///     Awake is called when the script instance is being loaded. It initializes the Rigidbody component, sets it to freeze rotation to prevent unwanted physics interactions, enables interpolation for smoother movement, and sets the collision detection mode to Continuous to improve collision detection at high speeds.
    /// </summary>
    void Awake()
    {
        body = GetComponent<Rigidbody>();

        body.freezeRotation = true;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    /// <summary>
    ///     FixedUpdate is called at a fixed interval and is used for physics updates. It checks if the player is grounded, applies movement based on player input, and applies gravity when the player is not grounded. This method ensures that the player's movement and physics interactions are consistent and responsive.
    /// </summary>
    void FixedUpdate()
    {
        CheckGround();
        ApplyMovement();
        ApplyGravity();
    }

    #endregion

    #region Control Methods


    /// <summary>
    ///     SetDirection is called by the PlayerController to update the current input direction based on player input. This direction is used in the ApplyMovement method to determine the movement of the player character in the world space.
    /// </summary>
    /// <param name="direction">
    ///     The direction vector representing the player's input in world space.
    /// </param>
    public void SetDirection(Vector3 direction)
    {
        currentInputDirection = direction;
    }


    /// <summary>
    ///     CheckGround is called in FixedUpdate to determine if the player is currently grounded by performing a raycast downwards from the player's position. It updates the isOnFloor boolean and hitFloor RaycastHit based on whether the raycast hits a collider on the specified ground layer within the ground check distance. This information is used to control movement and gravity behavior in the ApplyMovement and ApplyGravity methods.
    /// </summary>
    void CheckGround()
    {
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        isOnFloor = Physics.Raycast(
            origin,
            Vector3.down,
            out hitFloor,
            groundCheckDistance,
            groundLayer
        );
    }

    /// <summary>
    ///     ApplyGravity is called in FixedUpdate to apply a downward force to the player when they are not grounded. This simulates gravity and allows the player to fall when they walk off edges or jump. The gravitational force is applied as an acceleration, which ensures that the player's falling speed increases over time until they hit the ground.
    /// </summary>
    void ApplyGravity()
    {
        if (!isOnFloor)
        {
            body.AddForce(Vector3.down * gravitationalForce, ForceMode.Acceleration);
        }
    }

    /// <summary>
    ///     ApplyMovement is called in FixedUpdate to apply movement to the player based on the current input direction and whether the player is grounded. If the player is grounded, it projects the movement onto the plane of the ground (to allow for movement on slopes) and applies velocity accordingly. If the player is not grounded, it applies a reduced velocity to allow for some air control while falling. This method ensures that the player's movement feels responsive and natural based on their input and the environment they are in.
    /// </summary>
    void ApplyMovement()
    {
        Vector3 currentVelocity = body.linearVelocity;

        // Converte input para espaço do personagem
        Vector3 worldDirection =
            transform.forward * currentInputDirection.z +
            transform.right * currentInputDirection.x;

        if (worldDirection.magnitude > 1f)
            worldDirection.Normalize();

        if (isOnFloor)
        {
            Vector3 rampMovement =
                Vector3.ProjectOnPlane(worldDirection, hitFloor.normal);

            currentVelocity.x = rampMovement.x * velocity;
            currentVelocity.z = rampMovement.z * velocity;
        }
        else
        {
            currentVelocity.x = worldDirection.x * velocity * 0.5f;
            currentVelocity.z = worldDirection.z * velocity * 0.5f;
        }

        body.linearVelocity = currentVelocity;
    }

    #endregion
}
