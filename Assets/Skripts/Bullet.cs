using UnityEngine;


public class Bullet : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _lifeTime = 4.0f;
    [SerializeField] private int _damage = 1;

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
        gameObject.transform.position += transform.right * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }

    #endregion
}
