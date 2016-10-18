using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public enum AttachmentFacingDirection {
    NORTH,
    SOUTH,
    EAST,
    WEST,
    FORWARD,
    BACKWARDS
}


public class AttachmentPoint : IClickable {
    private Canvas radialCanvas;
    public static AttachmentFacingDirection GetOpposingDirection(AttachmentFacingDirection direction) {
        switch (direction) {
            case AttachmentFacingDirection.BACKWARDS:
                return AttachmentFacingDirection.FORWARD;;
                case AttachmentFacingDirection.FORWARD:
                return AttachmentFacingDirection.BACKWARDS;
                case AttachmentFacingDirection.EAST:
                return AttachmentFacingDirection.WEST;
                case AttachmentFacingDirection.WEST:
                return AttachmentFacingDirection.EAST;
                case AttachmentFacingDirection.NORTH:
                return AttachmentFacingDirection.SOUTH;
                case AttachmentFacingDirection.SOUTH:
                return AttachmentFacingDirection.NORTH;
        }

        throw new ArgumentException("no implementation for opposite found");
    }

    private RadialMenu menu;

    public AttachmentFacingDirection attachmentFacingDirection;
    public RadialMenu radialMenuPrefab;
	private CameraHandler cameraHandler;
 
    void Start() {
        this.radialCanvas = GameObject.FindGameObjectWithTag("RadialCanvas").GetComponent<Canvas>();
		this.cameraHandler = FindObjectOfType<CameraHandler> ();
    }

	public override void Click () {
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
            AttachmentFacingDirection opposingDirection = GetOpposingDirection(attachmentFacingDirection);
            AttachmentPoint attachmentPoint = module.FindAttachmentPoint(opposingDirection);
            if (attachmentPoint == null) {
                DestroyImmediate(module.gameObject);
            } else {
				module.transform.SetParent(transform, false);
				module.transform.Translate(-attachmentPoint.transform.localPosition);
				GetComponent<FixedJoint> ().connectedBody = module.GetComponent<Rigidbody>();
				GetComponent<BoxCollider> ().enabled = false;
				cameraHandler.track = module.gameObject;
            }
            
        }
    }
}