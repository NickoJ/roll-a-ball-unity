using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text winText;

	Rigidbody rb;
	int count = 0;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical).normalized * speed * Time.fixedDeltaTime;
		rb.AddForce (movement);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = string.Format ("Count: {0}", count);
		if (count >= 10) winText.text = "You Win!";
			
	}

}