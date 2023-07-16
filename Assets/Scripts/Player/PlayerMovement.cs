using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float moveSpeed;

    void Update()
    {
        MoveHandle();
    }

    void FixedUpdate()
    {
        MoveDestination();
    }

    void MoveHandle()
    {
        WalkAnimation();
        PlayerDirection();
    }

    void PlayerDirection()
    {
        if (IsPlayerIdle())
        {
            Vector3 relative = (transform.position + GetInput()) - transform.position;
            playerBody.transform.rotation = Quaternion.LookRotation(relative);
        }
    }

    void WalkAnimation()
    {
        float _value = (IsPlayerIdle()) ? 0.5f : 0;
        playerAnimator.SetFloat("Speed", _value);
    }

    void MoveDestination()
    {
        transform.position += GetInput().normalized * moveSpeed * Time.fixedDeltaTime;
    }

    Vector3 GetInput()
    {
        Vector3 _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        return _input;
    }

    //to enhance readability
    bool IsPlayerIdle() { return (GetInput() != Vector3.zero) ? true : false; }
}
