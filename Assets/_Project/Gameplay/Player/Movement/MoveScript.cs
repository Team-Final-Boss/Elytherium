using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    public float velocity = 20f;
    public float gravitationalForce = 9.81f;

    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody body;
    private bool isOnFloor;
    private RaycastHit hitFloor;

    private Vector3 currentInputDirection;

    void Awake()
    {
        body = GetComponent<Rigidbody>();

        body.freezeRotation = true;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    public void SetDirection(Vector3 direction)
    {
        currentInputDirection = direction;
    }

    void FixedUpdate()
    {
        CheckGround();
        ApplyMovement();
        ApplyGravity();
    }

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

    void ApplyGravity()
    {
        if (!isOnFloor)
        {
            body.AddForce(Vector3.down * gravitationalForce, ForceMode.Acceleration);
        }
    }

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
}
