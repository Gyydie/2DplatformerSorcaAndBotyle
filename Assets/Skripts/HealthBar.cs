using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private float _health;

    void Start()
    {
        _health = 1f;
    }

    void Update()
    {
        _bar.fillAmount = _health;
    }

    public void HurtPlayer(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
