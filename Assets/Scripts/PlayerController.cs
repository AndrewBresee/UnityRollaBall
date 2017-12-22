using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public Text countText;
	public Text winText;

	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
		winText.text = "";
	}
	
	// Called before rendering a frame. Where game code will go
	void Unpdate() {

	}

	// Before any physics calculations
	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 14) {
			winText.text = "You Win";
		}
	}
}
