using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlVirtual1 : MonoBehaviour, IDragHandler,
IPointerDownHandler, IPointerUpHandler {
	public static Image imFondo1;
	public static Image imControl1;
	public static Vector3 inputVector1;

	// Use this for initialization
	void Start () {
		imFondo1=GetComponent<Image>();
		imControl1 = transform.GetChild (0).GetComponent<Image> ();
		inputVector1 = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
		
	}//fin del Update

	public void OnDrag(PointerEventData ped){
		Vector2 pos;
		//inicio de Super if
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imFondo1.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = pos.x / imFondo1.rectTransform.sizeDelta.x;
			pos.y = pos.y / imFondo1.rectTransform.sizeDelta.y;

			inputVector1 = new Vector3 (pos.x*2 -1, 0, pos.y*2-1);
			//inputVector1 = (inputVector1.magnitude > 1) ? 
			//	inputVector1.normalized : inputVector1;
			if (inputVector1.magnitude > 1)
				inputVector1 = inputVector1.normalized;
			//Debug.Log (inputVector);

			//mover imagen control
			imControl1.rectTransform.anchoredPosition = new Vector3 (inputVector1.x * imFondo1.rectTransform.sizeDelta.x / 3, inputVector1.z * imFondo1.rectTransform.sizeDelta.y / 3);
		}//fin del Super if
	}//fin del método OnDrag

	public void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}//fin del método OnPointerDown

	public void OnPointerUp(PointerEventData ped){
		inputVector1 = Vector3.zero;
		imControl1.rectTransform.anchoredPosition = Vector3.zero;
	}//fin del método OnPointerUp

}//fin del código
