using UnityEngine;


public class BulletEnemy : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _lifeTime = 4.0f;
    [SerializeField] private float _damage = 0.2f;

    Vector3 Dir = new Vector3(0, 0, 0);

    #endregion


    #region UnityMethods

    void Start()
    {
        Dir.x = _speed;
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += -transform.right * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<HealthBar>();
            player.HurtPlayer(_damage);
            Destroy(gameObject);
        }
    }

    #endregion
}
