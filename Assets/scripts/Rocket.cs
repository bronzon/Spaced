using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public void Launch() {		
		var modules = GetComponentsInChildren<Module> ();
		foreach (Module module in modules) {
			module.Launch ();
		}
	}
}
