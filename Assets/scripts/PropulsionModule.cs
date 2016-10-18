using UnityEngine;
using System.Collections;

public class PropulsionModule : Module {
	public float power;
	public float fuelEfficiency;

	private Rigidbody rbody;
	private FuelSupply fuelSupply;

	public override string GetDescription () {
		return "Power: " + power + "\r\n" + "Efficiency: " + fuelEfficiency + "\r\n" + "Mass: " + mass;
	}

	public override void Launch ()	{
		print ("launch");
		StartCoroutine (RunEngine ());			
	}

	void Start() {
		rbody = GetComponent<Rigidbody> ();
		fuelSupply = FindObjectOfType<FuelSupply> ();
		FindObjectOfType<Statistics> ().AddMass (mass);
		FindObjectOfType<Statistics> ().AddPower(power);
	}


	IEnumerator RunEngine () {
		GetComponentInChildren<ParticleSystem> ().Play ();
		GetComponentInChildren<Light> ().enabled = true;
		while (fuelSupply.HasFuel()) {
			fuelSupply.ConsumeFuel (power * fuelEfficiency);
			rbody.AddForce (transform.up*power);
			yield return new WaitForEndOfFrame ();
		}
		GetComponentInChildren<Light> ().enabled = false;
		GetComponentInChildren<ParticleSystem> ().Stop ();
	}
}
