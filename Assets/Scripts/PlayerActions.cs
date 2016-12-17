using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}
public class PlayerActions:MonoBehaviour{
	public Rigidbody player;
	public GameObject playerShot;
	public Transform shotSpawn;
	public Boundary boundary;
	
	public int speed;
	public int tilt;
	public int bank;
	public float fireRate;
	private float shotDelay;

	void Start(){
		player.GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		Move();
	}

	void Update(){
		Shoot();
	}

	public void Move(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(moveHorizontal, moveVertical, 0f);
		player.velocity = move * speed;
		player.position = new Vector3(Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax), 0f);
		transform.rotation = Quaternion.Euler(0f, 0f, player.velocity.x * -bank);
	}

	public void Shoot(){
		if(Input.GetKey("space") && Time.time > shotDelay){
			shotDelay = Time.time + fireRate;
			Instantiate(playerShot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
