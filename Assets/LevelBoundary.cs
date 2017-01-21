using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour {
	private List<PlayerPoints> _players = new List<PlayerPoints>(); 

	private void Start () {
		_players.AddRange(FindObjectsOfType<PlayerPoints>());
	}

	private void Update () {
		foreach (PlayerPoints p in _players) {
			if(p.transform.position.y < transform.position.y) {
				//TODO Restart Level
				_players.ForEach(x => x.Points += (x != p) ? 1 : 0);
			}
		}
	}
}
