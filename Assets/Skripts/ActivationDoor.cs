using UnityEngine;


public class ActivationDoor : MonoBehaviour
{
	private Animator _animator;
	[SerializeField] Animator _animatorOpenDoor;

	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_animator.SetFloat("activSwitch", 1);

			_animatorOpenDoor.SetFloat("openDoor", 1);
		}
	}
}
