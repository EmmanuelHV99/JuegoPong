using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador2 : MonoBehaviour {
	private int velJ=5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Mover arriba
		if(Input.GetKey(KeyCode.UpArrow)&(transform.localPosition.z<3.5)){
			transform.Translate(new Vector3 (0,0,velJ)*Time.deltaTime);
		}
		//Mover abajo
		if(Input.GetKey(KeyCode.DownArrow)&(transform.localPosition.z>-3.5)){
			transform.Translate(new Vector3 (0,0,-velJ)*Time.deltaTime);
		}
		//Mover adelante
		if(Input.GetKey(KeyCode.LeftArrow)&(transform.localPosition.z>1)){
			transform.Translate(new Vector3 (-velJ,0,0)*Time.deltaTime);
		}
		//Mover atras
		if(Input.GetKey(KeyCode.RightArrow)&(transform.localPosition.z<7)){
			transform.Translate(new Vector3 (velJ,0,0)*Time.deltaTime);
		}
		ControlJugador2();
	}
	void ControlJugador2(){
		//Mover arriba con control virtual2
		if(ControlVirtual2.inputVector2.z>0){
			if(transform.localPosition.z<3.5)
				transform.Translate(new Vector3(0,0, ControlVirtual2.inputVector2.z*velJ)*Time.deltaTime);
		}
		//Mover abajo con control virtual2
		if(ControlVirtual2.inputVector2.z<0){
			if(transform.localPosition.z>-3.5)
				transform.Translate(new Vector3(0,0, ControlVirtual2.inputVector2.z*velJ)*Time.deltaTime);
		}
		//Mover adelante con control virtual2
		if(ControlVirtual2.inputVector2.x<0){
			if(transform.localPosition.x>1)
				transform.Translate(new Vector3(ControlVirtual2.inputVector2.x*velJ,0,0)*Time.deltaTime);
		}
		//Mover atras con control virtual2
		if(ControlVirtual2.inputVector2.x>0){
			if(transform.localPosition.x<7)
				transform.Translate(new Vector3(ControlVirtual2.inputVector2.x*velJ,0,0)*Time.deltaTime);
		}
	}
}
