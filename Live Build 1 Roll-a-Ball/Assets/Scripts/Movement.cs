using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
  [SerializeField] float acceleration = 600;
  Rigidbody rb;

  public float jumpForce;
  public float jumpCooldown;

  float jumpTime;
  
  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    jumpTime = Time.time;
  }

  public void Move(Vector3 moveDirection) {
    // Ensure vector is not greater that 1 in magnitude.
    if (moveDirection.magnitude > 1) moveDirection = moveDirection.normalized;

    // Multiply by acceleration
    Vector3 forceVector = moveDirection * acceleration;

    // Use the forceVector to add an acceleration to the ball. Ignoring its mass
    rb.AddForce(forceVector, ForceMode.Acceleration);
  }

  public void Jump()
  {
    float timeSinceLastJump = Time.time - jumpTime;
    if (timeSinceLastJump <= jumpCooldown) return;
    rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    jumpTime = Time.time;
  }
}
