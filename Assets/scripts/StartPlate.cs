using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartPlate : IClickable {
	private RadialMenu menu;
	private Canvas radialCanvas;
	public RadialMenu radialMenuPrefab;
	public Button launchButton;
	private CameraHandler cameraHandler;

	// Use this for initialization
	void Start () {
		this.radialCanvas = GameObject.FindGameObjectWithTag("RadialCanvas").GetComponent<Canvas>();
		cameraHandler = FindObjectOfType<CameraHandler> ();
	}
	
	// Update is called once per frame
	public override void Click() {
		print ("clicked");
		if (GameObject.FindObjectsOfType<RadialMenu>().Length > 0) {
			return;
		}

		if (menu != null) {
			DestroyImmediate(menu);
		}

		menu = Instantiate(radialMenuPrefab);
		menu.transform.SetParent(radialCanvas.transform, false);
		Vector3 world = Camera.main.WorldToScreenPoint (transform.position);
		menu.transform.position = new Vector2 (world.x, world.y);
		menu.ShowMenu(MenuExecuted);
	}

	void MenuExecuted(Module modulePrefab) {
		if (modulePrefab != null) {            
			Module module = Instantiate (modulePrefab);
			AttachmentPoint attachmentPoint = module.FindAttachmentPoint(AttachmentFacingDirection.SOUTH);
			if (attachmentPoint == null) {
				DestroyImmediate(module.gameObject);
				print ("Could not find a southward attachmentpoint, needed for starting object");
			} else {
				module.name = "Rocket";
				Rocket rocketComponent = module.gameObject.AddComponent<Rocket> ();
				module.transform.Translate(-attachmentPoint.transform.localPosition);
				launchButton.onClick.AddListener(rocketComponent.Launch);
				cameraHandler.track = module.gameObject;
				DestroyImmediate (this.gameObject);
			}

		}
	}

}
