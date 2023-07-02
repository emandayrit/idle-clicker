using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float moveSpeed;

    private Vector3 _input;

    void Update()
    {
        GetInput();
        Look();

        // Player Animations here
        if (_input == Vector3.zero)
        {
            playerAnimator.SetFloat("Speed", 0);
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0.5f);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(_input != Vector3.zero)
        {
            Vector3 relative = (transform.position + _input) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relative);

            playerBody.transform.rotation = rotation;
        }
    }

    void Move()
    {
        transform.position += _input.normalized * moveSpeed * Time.fixedDeltaTime;
    }

}
