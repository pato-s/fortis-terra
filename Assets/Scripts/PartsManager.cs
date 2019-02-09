using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour {

	public static PartsManager Instance;

	public GameObject[] Parts;
	public GameObject[] PartsHolo;
	private int index = 0;

	void Awake()
	{
		Instance = this;
	}

	public GameObject GetPart()
	{
		return Instantiate(PartsHolo[index], CursorManager.Instance.CursorPosition.transform);
	}

	public GameObject GetPartHolo()
	{
		return Instantiate(Parts[index], CursorManager.Instance.CursorPosition.transform);
	}
}
