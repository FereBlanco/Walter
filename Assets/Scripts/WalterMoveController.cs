using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class WalterMoveController : MonoBehaviour
{
    enum Direction {Up, Down, Left, Right};
    float walkSpeed = 5f;
    float gravityForce = 100f;
    float jumpForce = 4000f;
    Rigidbody m_Rigidbody;
    bool isJumping = false;
    bool isFalling = false;
    bool isOnGroung = true;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0f, gravityForce * (-1), 0f);
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walter moves
        if (Input.GetKey(KeyCode.UpArrow)) Move(Direction.Up);
        if (Input.GetKey(KeyCode.DownArrow)) Move(Direction.Down);
        if (Input.GetKey(KeyCode.LeftArrow)) Move(Direction.Left);
        if (Input.GetKey(KeyCode.RightArrow)) Move(Direction.Right);
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        // Check jump
            if (isJumping && !isFalling)
            {
                isFalling = isFalling || (m_Rigidbody.velocity.y < 0f);
            }

            if (isJumping && isFalling)
            {
                isOnGroung = (m_Rigidbody.velocity.y == 0f);
                if (isOnGroung)
                {
                    isFalling = false;
                    isJumping = false;
                }
            }
}

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                transform.position += new Vector3(walkSpeed * Time.deltaTime * (-1), 0f, 0f);
                transform.localEulerAngles = new Vector3(0f, -90f, 0f);
                break;
            case Direction.Down:
                transform.position += new Vector3(walkSpeed * Time.deltaTime, 0f, 0f);
                transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                break;
            case Direction.Left:
                transform.position += new Vector3(0f, 0f, walkSpeed * Time.deltaTime * (-1));
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                break;
            case Direction.Right:
                transform.position += new Vector3(0f, 0f, walkSpeed * Time.deltaTime);
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                break;
        }
    }

    private void Jump()
    {
        if (isOnGroung)
        {
            isJumping = true;
            isFalling = false;
            isOnGroung = false;
            m_Rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
