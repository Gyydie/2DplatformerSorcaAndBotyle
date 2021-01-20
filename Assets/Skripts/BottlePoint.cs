using UnityEngine;


public class BottlePoint : MonoBehaviour
{
    private int _point = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pointpluse = collision.gameObject.GetComponent<ScorePlayer>();
        pointpluse.Score(_point);
        Destroy(gameObject);
    }
}
