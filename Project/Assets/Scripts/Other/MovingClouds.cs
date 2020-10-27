using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
	[SerializeField] private float Speed = 1f;
	[SerializeField] private float StartXPoint = 0f;
	[SerializeField] private float EndXPoint = 1f;

	private Vector3 StartPoint;
	private Vector3 EndPoint;

	private void Awake()
	{
		StartPoint = transform.position;
		EndPoint = transform.position;

		EndPoint.x = EndXPoint;
		StartPoint.x = StartXPoint;
	}

	private void Update()
	{
		transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);

		if (transform.position.x > EndPoint.x)
		{
			transform.position = StartPoint;
		}
	}
}
