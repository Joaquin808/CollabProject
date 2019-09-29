using UnityEngine;
using System.Collections;

public class DogAi : MonoBehaviour {
	
	public Transform position;
	
	void Start () {
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.destination = position.position;
	}
	
}