using UnityEngine;
using System.Collections;

public class AttachmentPointInput : MonoBehaviour {
	public LayerMask layermask;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, float.MaxValue, layermask)) {
				hit.collider.GetComponent<IClickable> ().Click ();
			}
		}
	}
}
