using UnityEngine;
using System.Collections;

public class HabitatModule : Module {
	public int spaceForAstronouts;

	public override string GetDescription () {
		return "Space for: " + spaceForAstronouts + "\r\n" + "Mass: " + mass;
	}

	public override void Launch () {
		
	}

	// Use this for initialization
	void Start () {
		FindObjectOfType<Statistics> ().AddMass (mass);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
