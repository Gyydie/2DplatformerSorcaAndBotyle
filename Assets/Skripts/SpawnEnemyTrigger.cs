using UnityEngine;


public class SpawnEnemyTrigger : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint1;
    [SerializeField] private Transform _spawnPoint2;
    [SerializeField] private Transform _spawnPoint3;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_enemy, _spawnPoint1.position, _spawnPoint1.rotation);
            Instantiate(_enemy, _spawnPoint2.position, _spawnPoint2.rotation);
            Instantiate(_enemy, _spawnPoint3.position, _spawnPoint3.rotation);
            Destroy(gameObject);
        }
    }

    #endregion
}