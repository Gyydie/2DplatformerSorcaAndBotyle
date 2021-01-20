using UnityEngine;


public class FallingPlatform : MonoBehaviour
{
    #region Fields

    [SerializeField] private Rigidbody2D _rigidbody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("FallPlatform", 1f);
            Destroy(this.gameObject, 2f);
        }
    }

    #endregion


    #region Methods

    private void FallPlatform()
    {
        _rigidbody.isKinematic = false;
    }

    #endregion
}
