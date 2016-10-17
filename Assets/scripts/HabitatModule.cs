using UnityEngine;
using System.Collections;

public class HabitatModule : Module {
	public int spaceForAstronouts;

	public override string GetDescription () {
		return "Space for: " + spaceForAstronouts + "\r\n" + "Mass: " + mass;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
