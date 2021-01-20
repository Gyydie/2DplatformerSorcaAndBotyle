using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _health = 10;
    private SpriteRenderer sprite;

    #endregion


    #region UnityMethods

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    #endregion


    #region Methods

    public void Hurt (int damage)
    {
        _health -= damage;
        sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", .2f);
        }
    }

    private void ResetMaterial()
    {
        sprite.color = Color.white;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion
}
