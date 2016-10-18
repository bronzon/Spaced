using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	private Statistics statistics;

	public void Launch() {		
		var modules = FindObjectsOfType<Module> ();
		foreach (Module module in modules) {
			module.Launch ();
		}
	}

	void Start() {
		statistics = FindObjectOfType<Statistics> ();
	}

	void Update() {
		statistics.SetAltitude(transform.position.y);
	}
}
