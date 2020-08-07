using UnityEngine;

public class SimplePistol : MonoBehaviour
{
	[SerializeField] private string BulletName = "";

	private Transform Transform;
	private GameObject Bullet;

	void Shoot()
	{
		Instantiate(Bullet, Transform.position, Transform.rotation);
	}

	private void Awake()
	{
		Transform = GetComponent<Transform>();
		Bullet = Resources.Load<GameObject>("Guns/Bullets/" + BulletName);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
	}
}
