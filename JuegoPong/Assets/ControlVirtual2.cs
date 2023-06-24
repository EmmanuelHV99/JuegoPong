using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlVirtual2 : MonoBehaviour, IDragHandler,
IPointerDownHandler, IPointerUpHandler {
	public static Image imFondo2;
	public static Image imControl2;
	public static Vector3 inputVector2; 

	// Use this for initialization
	void Start () {
		imFondo2=GetComponent<Image>();
		imControl2 = transform.GetChild (0).GetComponent<Image> ();
		inputVector2 = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
		
	}//fin del Update

	public void OnDrag(PointerEventData ped){
		Vector2 pos;
		//inicio de Super if
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle 
			(imFondo2.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = pos.x / imFondo2.rectTransform.sizeDelta.x;
			pos.y = pos.y / imFondo2.rectTransform.sizeDelta.y;

			inputVector2 = new Vector3 (pos.x*2 -1, 0, pos.y*2-1);
			//inputVector1 = (inputVector1.magnitude > 1) ? 
			//	inputVector1.normalized : inputVector1;
			if (inputVector2.magnitude > 1)
				inputVector2 = inputVector2.normalized;
			//Debug.Log (inputVector);

			//mover imagen control
			imControl2.rectTransform.anchoredPosition = 
				new Vector3 (inputVector2.x * imFondo2.rectTransform.sizeDelta.x / 3, 
					inputVector2.z * imFondo2.rectTransform.sizeDelta.y / 3);
		}//fin del Super if
	}//fin del método OnDrag

	public void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}//fin del método OnPointerDown

	public void OnPointerUp(PointerEventData ped){
		inputVector2 = Vector3.zero;
		imControl2.rectTransform.anchoredPosition = Vector3.zero;
	}//fin del método OnPointerUp

}//fin del código
