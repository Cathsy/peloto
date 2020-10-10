using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movimiento_jugador : MonoBehaviour {
	private Rigidbody rb;
	public float Speed = 1.0f;
	private int count;
	public Text countText;
	public Text winText;
	void Start(){
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		SetCountText();
	}
	void FixedUpdate(){
		float horizontal= Input.GetAxis("Horizontal");
		float vertical= Input.GetAxis("Vertical");

		Vector3 movement= new Vector3(horizontal,0.0f,vertical);
		rb.AddForce(movement*Speed);

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Pick up")){
			other.gameObject.SetActive(false);
			count+=1;
			SetCountText();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString(); 
		if (count>=12){
			winText.text= "You win!!";
		}
	}

}
