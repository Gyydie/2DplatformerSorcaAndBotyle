using UnityEngine;


public class MovementController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rayDistance;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBulletTransform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask GroundLauerMask;

    private RaycastHit2D _checkGroundRay;
    private Vector3 _moveDirection = Vector3.zero;
    private bool _isForfard = true;
    private bool _isGround;
    

    #endregion


    #region UnityMethods

    private void Update()
    {
        StateUpdate();

        Jump();

        if (_moveDirection.x > 0 && !_isForfard)
        {
            Flip();
        }
        else if (_moveDirection.x < 0 && _isForfard)
        {
            Flip();
        }

        Fire();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion


    #region Methods

    private void StateUpdate()
    {
        _checkGroundRay = Physics2D.Raycast(transform.position, -Vector2.up, _rayDistance, GroundLauerMask);
        _isGround = _checkGroundRay;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            this._rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _startBulletTransform.position, _startBulletTransform.rotation);
        }
    }

    private void Flip()
    {
        _isForfard = !_isForfard;
        var vector = Vector3.zero;
        if (_isForfard)
        {
            vector.y = 0;
        }
        else if (!_isForfard)
        {
            vector.y = 180;
        }
        transform.rotation = Quaternion.Euler(vector);
    }

    #endregion
}
