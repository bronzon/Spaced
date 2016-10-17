using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModuleDescription : MonoBehaviour {
	public Module modulePrefab;
	public Text nameText;
	public Text descriptionText;

	void Start () {
		nameText.text = modulePrefab.moduleName;
		descriptionText.text = modulePrefab.GetDescription ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
