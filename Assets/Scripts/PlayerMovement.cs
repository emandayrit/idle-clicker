using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    [SerializeField] float moveSpeed;

    private Vector3 _input;

    void Update()
    {
        GetInput();
        Look();
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
