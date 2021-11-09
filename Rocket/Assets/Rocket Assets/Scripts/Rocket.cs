using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float m_MovePower = 5; // The force added to the Rocket to move it.
    [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the Rocket can rotate at.
    [SerializeField] private float m_RocketPower = 2; // The force added to the ball when it jumps.

    private const float k_GroundRayLength = 1f; // The length of the ray to check if the Rocket is grounded.
    private Rigidbody m_Rigidbody;

    private bool win = false;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        // Set the maximum angular velocity.
        GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the axis and jump input.
        float stear = CrossPlatformInputManager.GetAxis("Horizontal");
        bool fireRocket = CrossPlatformInputManager.GetButton("Jump");
        isGrounded = false;

        if(Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength)) // Werkt niet?
        {
            isGrounded = true;
        }

        this.Move((stear * Vector3.right).normalized, fireRocket, isGrounded);
    }

    public void Move(Vector3 moveDirection, bool fireRocket, bool isGrounded)
    {
        if (!isGrounded)
        {
            //m_Rigidbody.AddForce(moveDirection * m_MovePower);
            this.transform.Rotate(0, moveDirection.x / 4, 0, Space.Self);
        }

        if (fireRocket)
        {
            m_Rigidbody.AddForce(this.transform.forward * m_RocketPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Platform_Target")
        {
            win = true;
            Debug.Log("You won!");
        }
    }
}
