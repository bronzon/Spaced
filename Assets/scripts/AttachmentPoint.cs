using System;
using UnityEngine;
using System.Collections;

public enum AttachmentFacingDirection {
    NORTH,
    SOUTH,
    EAST,
    WEST,
    FORWARD,
    BACKWARDS
}


public class AttachmentPoint : MonoBehaviour {
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
    private ModuleSpawner moduleSpawner;

    void Start() {
        this.moduleSpawner = ModuleSpawner.instance;
        this.radialCanvas = GameObject.FindGameObjectWithTag("RadialCanvas").GetComponent<Canvas>();
    }

    void OnMouseDown() {
        if (menu != null) {
            DestroyImmediate(menu);
        }

        menu = Instantiate(radialMenuPrefab);
        menu.transform.SetParent(radialCanvas.transform, false);
        menu.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        menu.menuExecuted += MenuExecuted;
    }

    void MenuExecuted(RadialMenuAction radialMenuAction) {
        DestroyImmediate(menu.gameObject);
        if (radialMenuAction != RadialMenuAction.CANCEL) {            
            Module module = moduleSpawner.Spawn(radialMenuAction);
            AttachmentFacingDirection opposingDirection = GetOpposingDirection(attachmentFacingDirection);
            AttachmentPoint attachmentPoint = module.FindAttachmentPoint(opposingDirection);
            if (attachmentPoint == null) {
                DestroyImmediate(module.gameObject);
            } else {
                module.transform.SetParent(transform, false);
                module.transform.Translate(-attachmentPoint.transform.localPosition);
            }
            
        }
    }
}