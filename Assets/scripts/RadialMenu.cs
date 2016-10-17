using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum RadialMenuAction {
    HABITAT,
    PROPULSION,
    FUEL,
    CANCEL
}

public class RadialMenu : MonoBehaviour {
    public Action<RadialMenuAction> menuExecuted;
    public Button habitatButton;
    public Button propulsionButton;
    public Button fuelButton;
    public Button cancelButton;

    void Start() {
        habitatButton.onClick.AddListener(() => {
            if (menuExecuted != null) {
                menuExecuted(RadialMenuAction.HABITAT);
            }
        });

        fuelButton.onClick.AddListener(() => {
            if (menuExecuted != null) {
                menuExecuted(RadialMenuAction.FUEL);
            }
        });

        propulsionButton.onClick.AddListener(() => {
            if (menuExecuted != null) {
                menuExecuted(RadialMenuAction.PROPULSION);
            }
        });

        cancelButton.onClick.AddListener(() => {
            if (menuExecuted != null) {
                menuExecuted(RadialMenuAction.CANCEL);
            }
        });
    }
}