using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _playerLauerMask;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage = 0.2f;
    private Vector3 _moveDirection = Vector3.zero;
    private RaycastHit2D _checkPlayerLeft;
    private RaycastHit2D _checkPlayerRight;


    private bool _isPlayerLeft;
    private bool _isPlayerRight;

    #endregion


    #region UnityMethods

    void Update()
    {
        TrggerPlayer();

        if(_isPlayerLeft)
        {
            _moveDirection.x = -1;
        }else if (_isPlayerRight)
        {
            _moveDirection.x = 1;
        }else
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

    void TrggerPlayer()
    {
        _checkPlayerLeft = Physics2D.Raycast(transform.position, Vector2.left, _rayDistance, _playerLauerMask);
        _isPlayerLeft = _checkPlayerLeft;
        _checkPlayerRight = Physics2D.Raycast(transform.position, Vector2.right, _rayDistance, _playerLauerMask);
        _isPlayerRight = _checkPlayerRight;
    }

    #endregion
}
