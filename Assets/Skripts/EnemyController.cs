using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _playerLauerMask;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage = 0.2f;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private GameObject _bullet;
    private Vector3 _moveDirection = Vector3.zero;
    private RaycastHit2D _checkPlayerLeft;
    private RaycastHit2D _checkPlayerRight;
    private Vector3 _moveDirectionY;

    private bool _isPlayerLeft;
    private bool _isPlayerRight;
    private float nextTime = 0.0F;
    private float timeRate = 1F;


    #endregion


    #region UnityMethods

    void Update()
    {

        TrggerPlayer();

        if (_isPlayerLeft)
        {
            _moveDirection.x = -1;
            _moveDirectionY.y = 0;
            transform.rotation = Quaternion.Euler(_moveDirectionY);
            Fire();
        }
        else if (_isPlayerRight)
        {
            _moveDirection.x = 1;
            _moveDirectionY.y = 180;
            transform.rotation = Quaternion.Euler(_moveDirectionY);
            Fire();
        }
        else
        {
            _moveDirection.x = 0;
        }
        transform.position += _moveDirection * _speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<HealthBar>();
            player.HurtPlayer(_damage);
        }
    }

    #endregion


    #region Methods

    private void Fire()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + timeRate;
            Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
        }
    }

    void TrggerPlayer()
    {
        _checkPlayerLeft = Physics2D.Raycast(transform.position, Vector2.left, _rayDistance, _playerLauerMask);
        _isPlayerLeft = _checkPlayerLeft;
        _checkPlayerRight = Physics2D.Raycast(transform.position, Vector2.right, _rayDistance, _playerLauerMask);
        _isPlayerRight = _checkPlayerRight;
    }

    #endregion
}
