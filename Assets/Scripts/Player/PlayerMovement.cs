using UnityEngine;

public class PlayerMovement : IMovement
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rigidbody;

    public PlayerMovement(Rigidbody2D rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}
