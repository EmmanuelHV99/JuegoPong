using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador1 : MonoBehaviour {
	private int velJ=5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Mover arriba
		if(Input.GetKey(KeyCode.W)&(transform.localPosition.z<3.5)){
			transform.Translate(new Vector3 (0,0,velJ)*Time.deltaTime);
		}
		//Mover abajo
		if(Input.GetKey(KeyCode.S)&(transform.localPosition.z>-3.5)){
			transform.Translate(new Vector3 (0,0,-velJ)*Time.deltaTime);
		}
		//Mover adelante
		if(Input.GetKey(KeyCode.D)&(transform.localPosition.z<-1)){
			transform.Translate(new Vector3 (velJ,0,0)*Time.deltaTime);
		}
		//Mover atras
		if(Input.GetKey(KeyCode.A)&(transform.localPosition.z>-7)){
			transform.Translate(new Vector3 (-velJ,0,0)*Time.deltaTime);
		}
		ControlJugador1();
	}
	void ControlJugador1(){
		//Mover arriba con control virtual1
		if(ControlVirtual1.inputVector1.z>0){
			if(transform.localPosition.z<3.5)
				transform.Translate(new Vector3(0,0, ControlVirtual1.inputVector1.z*velJ)*Time.deltaTime);
		}
		//Mover abajo con control virtual1
		if(ControlVirtual1.inputVector1.z<0){
			if(transform.localPosition.z>-3.5)
				transform.Translate(new Vector3(0,0, ControlVirtual1.inputVector1.z*velJ)*Time.deltaTime);
		}
		//Mover adelante con control virtual1
		if(ControlVirtual1.inputVector1.x>0){
			if(transform.localPosition.x<-1)
				transform.Translate(new Vector3(ControlVirtual1.inputVector1.x*velJ,0,0)*Time.deltaTime);
		}
		//Mover atras con control virtual1
		if(ControlVirtual1.inputVector1.x<0){
			if(transform.localPosition.x>-7)
				transform.Translate(new Vector3(ControlVirtual1.inputVector1.x*velJ,0,0)*Time.deltaTime);
		}
	}
	
}
