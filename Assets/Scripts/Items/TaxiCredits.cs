using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiCredits : MonoBehaviour
{

	[SerializeField] float speed;
	[SerializeField] Transform end;
	[SerializeField] Transform start;

	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

		if (transform.position.x > end.position.x)
		{
			transform.position = start.position;
		}
		if (Input.anyKeyDown) Application.Quit();
	}
}
