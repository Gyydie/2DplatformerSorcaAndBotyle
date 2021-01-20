using UnityEngine.UI;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField] private Text _bottlePointText;
    [SerializeField] private GameObject _bbottlePointText;

    private int _point;


    public void Score(int point)
    {
        _point += point;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _bottlePointText.text = "X " + _point;
    }
}
