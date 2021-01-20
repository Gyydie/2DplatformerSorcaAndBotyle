using UnityEngine;


public class SoundPlayer : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _sound;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _source = GetComponent<AudioSource>();

        int rand = Random.Range(0, _sound.Length);
        _source.clip = _sound[rand];
        _source.Play();
    }

    #endregion
}
