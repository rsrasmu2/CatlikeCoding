﻿using UnityEngine;

public class StuffSpawnerRing : MonoBehaviour {
	[SerializeField] int numberOfSpawners;
	[SerializeField] float radius, tiltAngle;
	[SerializeField] StuffSpawner spawnerPrefab;
	[SerializeField] Material[] stuffMaterials;

	void Awake() {
		for (int i = 0; i < numberOfSpawners; i++) {
			CreateSpawner(i);
		}
	}

	void CreateSpawner(int index) {
		Transform rotater = new GameObject("Rotater").transform;
		rotater.SetParent(transform, false);
		rotater.localRotation = Quaternion.Euler(0f, index * 360f / numberOfSpawners, 0f);
		
		StuffSpawner spawner = Instantiate<StuffSpawner>(spawnerPrefab);
		spawner.transform.SetParent(rotater, false);
		spawner.transform.localPosition = new Vector3(0f, 0f, radius);
		spawner.transform.localRotation = Quaternion.Euler(tiltAngle, 0f, 0f);

		spawner.StuffMaterial = stuffMaterials[index % stuffMaterials.Length];
	}
}