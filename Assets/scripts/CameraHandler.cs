using UnityEngine;
using UnityEngine.UI;

public class CameraHandler : MonoBehaviour {
    public GameObject track;
    private Vector2 startMousePos = Vector2.zero;
    public float mouseAcceleration = 0.5f;
    void Start() {
        transform.LookAt(track.transform);
    }

    void Update() {
		transform.LookAt(track.transform);

        Vector2 mousePosition = Input.mousePosition;

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) {
            startMousePos = mousePosition;
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved ||
             (startMousePos != Vector2.zero && Input.GetMouseButton(0)))) {
            Vector2 mouseOffsetFromStart = startMousePos - mousePosition;
            float dragLength = mouseOffsetFromStart.x;
            transform.RotateAround(track.transform.position, Vector3.up, dragLength* mouseAcceleration);
            startMousePos = mousePosition;
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))) {
            startMousePos = Vector2.zero;
        }
    }

 
}
