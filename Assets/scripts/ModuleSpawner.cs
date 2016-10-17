using System;
using UnityEngine;
using System.Collections;

public class ModuleSpawner : MonoBehaviour {
    public static ModuleSpawner instance;
    public PropulsionModule propulsionModulePrefab;
    public HabitatModule habitatModulePrefab;
    public FuelModule fuelModulePrefab;

    void Awake() {
        instance = this;
    }

    public Module Spawn(RadialMenuAction action) {
        switch (action) {
            case RadialMenuAction.PROPULSION:
                return Instantiate(propulsionModulePrefab);
            case RadialMenuAction.FUEL:
                return Instantiate(fuelModulePrefab);
            case RadialMenuAction.HABITAT:
                return Instantiate(habitatModulePrefab);
        }

        throw new ArgumentException("No prefab found for action "+ action);
    }
}