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
    
    public Button habitatButton;
    public Button propulsionButton;
    public Button fuelButton;
    public Button cancelButton;

	public void ShowMenu(Action<Module> modulePrefabSelected) {
		SelectModule selectModule = GameObject.FindObjectOfType<SelectModule> ();

		habitatButton.onClick.AddListener(() => {
			selectModule.ShowSelectPrefabs(RadialMenuAction.HABITAT, modulePrefabSelected);
			Destroy(this.gameObject);
		});

		fuelButton.onClick.AddListener(() => {
			selectModule.ShowSelectPrefabs(RadialMenuAction.FUEL, modulePrefabSelected);
			Destroy(this.gameObject);
		});

		propulsionButton.onClick.AddListener(() => {
			selectModule.ShowSelectPrefabs(RadialMenuAction.PROPULSION, modulePrefabSelected);
			Destroy(this.gameObject);
		});

		cancelButton.onClick.AddListener(() => {			
			Destroy(this.gameObject);
		});
	}
  
}