using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class SelectModule : MonoBehaviour {
	ModuleDescription[] fuels;
	ModuleDescription[] habitats;
	ModuleDescription[] propulsions;

	Dictionary<RadialMenuAction, ModuleDescription[]> modules = new Dictionary<RadialMenuAction, ModuleDescription[]>();
	
	// Use this for initialization
	void Start () {
		fuels = Resources.LoadAll<ModuleDescription>("prefabs/descriptions/fuels");
		habitats =  Resources.LoadAll<ModuleDescription>("prefabs/descriptions/habitats");
		propulsions = Resources.LoadAll<ModuleDescription>("prefabs/descriptions/propulsions");

		modules [RadialMenuAction.FUEL] = fuels;
		modules [RadialMenuAction.PROPULSION] = propulsions;
		modules [RadialMenuAction.HABITAT] = habitats;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ShowSelectPrefabs(RadialMenuAction type, Action<Module> modulePrefabSelected) {
		GetComponent<Image> ().enabled = true;
		ModuleDescription[] moduleDescriptions = modules [type];

		for (int i = 0; i < moduleDescriptions.GetLength(0); i++) {
			ModuleDescription descPrefab = moduleDescriptions [i];

			ModuleDescription description = Instantiate (descPrefab);
			description.transform.SetParent (transform, false);
			description.transform.Translate (Vector3.right * i * 100f);
			description.GetComponent<Button>().onClick.AddListener (() => {
				foreach (Transform child in transform) {
					DestroyImmediate (child.gameObject);
				}
				GetComponent<Image> ().enabled = false;
				modulePrefabSelected(description.modulePrefab);
			});
		}
	}
}
