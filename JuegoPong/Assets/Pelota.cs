using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pelota : MonoBehaviour {
	private  int CoordX, CoordZ, vel=5, cont1=0, cont2=0;
	private Rigidbody rb;
	public Text tContador1, tContador2;
	private AudioSource[] sonidos;
	public Button bJugar, bFin;
	
	void Start () {
		//Ocultar botones
		bJugar.gameObject.SetActive(false);
		bFin.gameObject.SetActive(false);
		rb= GetComponent <Rigidbody> ();
		sonidos = GetComponents<AudioSource> ();
		Inicio();
	}

	void Inicio(){
		//Manda pelota al origen
		transform.localPosition=new Vector3 (0, 0, 0);

		CoordX=Random.Range(0,2);
		if(CoordX==0)
			CoordX=-1;

		if(CoordZ==0)
			CoordZ=-1;

		rb.velocity=new Vector3 (CoordX*vel, 0, CoordZ*vel);
	}//fin de Inicio
	
	void Fin(){
		//Mostrar botones
		bJugar.gameObject.SetActive(true);
		bFin.gameObject.SetActive(true);
		//Manda pelota al origen
		transform.localPosition=new Vector3 (0,0,0);
		//Detiene el movimiento de la pelota
		rb.velocity=new Vector3 (0,0,0);
	}//fin de Fin

	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		//Incrementar Contador1
		if(col.gameObject.tag=="muro2"){
			sonidos[2].Play();
			cont1++;
			tContador1.text=""+cont1;
			Inicio();
			if(cont1==10){
				Fin();
				tContador1.text="GANADOR";
				tContador2.text="PERDEDOR";
			}
		}//fin de incrementar Contador1

		//Incrementar Contador2
		if(col.gameObject.tag=="muro1"){
			sonidos[3].Play();
			cont2++;
			tContador2.text=""+cont2;
			Inicio();
			if(cont2==10){
				Fin();
				tContador2.text="GANADOR";
				tContador1.text="PERDEDOR";
			}
		}

		if(col.gameObject.tag=="muro"){
			sonidos[4].Play();
		}
		if(col.gameObject.tag=="jugador1"){
			sonidos[0].Play();
		}
		if(col.gameObject.tag=="jugador2"){
			sonidos[1].Play();
		}
	}
}
