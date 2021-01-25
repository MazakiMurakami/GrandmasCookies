using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb;
	public float jumpForce = 500f;
	public float frameTime = 0.4f;

	private SpriteRenderer spriteRend;
	public Sprite[] sprites = new Sprite[2];
	private float animateTime;
	private int frame;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRend = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if(animateTime > frameTime)
		{
			animateTime = 0;
			frame = (frame + 1) % 2;
			spriteRend.sprite = sprites[frame];
		}
		animateTime += Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Springveer"))
		{
			col.collider.isTrigger = true;
			col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			rb.AddForce(transform.up * jumpForce);
		}
		if (col.gameObject.CompareTag("Obstacle"))
		{
			Debug.Log("DEATH");
		}
	}
}
