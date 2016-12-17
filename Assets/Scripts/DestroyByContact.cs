using UnityEngine;
using System.Collections;

public class DestroyByContact:MonoBehaviour{
	void OnTriggerEnter(Collider other){
		if((other.tag == "Boundary") || (other.tag == "Player")){
			return;
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
