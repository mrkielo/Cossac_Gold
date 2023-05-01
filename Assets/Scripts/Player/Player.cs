using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] GameObject hint;
	GameObject box;
	PlayerMovement m;
	public bool isPulling;
	public bool isHiding;
	public bool dead;
	DialogueCamera cam;
	bool hintUsed = false;

	float hideProgress;
	[SerializeField] float hideTime;

	void Awake()
	{
		cam = FindObjectOfType<DialogueCamera>();
		dead = false;
		m = GetComponent<PlayerMovement>();
	}
	public void Die()
	{
		dead = true;
		GetComponent<Animator>().SetTrigger("Die");
		GameManager.instance.GameOver();
	}

	void Update()
	{
		if (!dead)
		{
			Pull();
			Hide();
		}
	}

	void Pull()
	{
		RaycastHit2D boxRay = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, 0.6f, m.groundLayers);

		if (boxRay && boxRay.collider.gameObject.tag == "Pull")
		{
			hint.SetActive(true);
			hintUsed = true;
			hint.transform.position = boxRay.collider.transform.position;

			if (Input.GetButton("Fire2"))
			{
				hint.SetActive(false);
				isPulling = true;
				box = boxRay.collider.gameObject;
				box.GetComponent<FixedJoint2D>().enabled = true;
				box.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
			}
			else if (box != null && Input.GetButtonUp("Fire2"))
			{
				isPulling = false;
				box.GetComponent<FixedJoint2D>().enabled = false;
			}

		}
		else
		{
			hint.gameObject.SetActive(false);
			hintUsed = false;
		}
	}

	void Hide()
	{
		Collider2D isHideinRange = Physics2D.OverlapCircle(transform.position, 1, LayerMask.GetMask("Hide"));
		if (isHideinRange && !isHiding)
		{
			hint.gameObject.SetActive(true);
			hint.transform.position = isHideinRange.transform.position;


			if (Input.GetButtonDown("Fire2"))
			{
				isHiding = true;
				hideProgress = 0;
				GetComponent<Animator>().SetBool("hiding", true);
				m.canJump = false;
				m.canMove = false;

			}
		}
		if ((isHideinRange == null || isHiding) && !hintUsed)
		{
			hint.SetActive(false);
		}

		if (isHiding && isHideinRange.transform.position.x == transform.position.x && Input.GetButtonDown("Fire2"))
		{
			isHiding = false;
			GetComponent<Animator>().SetBool("hiding", false);
			m.canJump = true;
			m.canMove = true;
			transform.position = new Vector2(transform.position.x + 0.03f, transform.position.y);
		}

		if (isHiding && hideProgress < hideTime)
		{
			transform.position = Vector2.Lerp(transform.position, isHideinRange.transform.position, hideProgress / hideTime);
			hideProgress += Time.deltaTime;
		}


	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("ContextCam"))
		{
			cam.SetMode(true, other.transform, 1.5f);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("ContextCam"))
		{
			cam.SetMode(false);
		}
	}

}
