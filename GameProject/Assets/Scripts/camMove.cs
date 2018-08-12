using UnityEngine;

public class camMove : MonoBehaviour {

    public GameObject player;
	public GameObject planet;
	bool playerOrPlanet = true;
	public void SetPlanet(GameObject newPlanet) {
		this.planet = newPlanet;
	}
	public void SetCameraMode(bool newPlayerOrPlanet) {
		this.playerOrPlanet = newPlayerOrPlanet;
	}

	void Update () {
		if (playerOrPlanet) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f); // перемещение камеры за играком
		}
		else {
			transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y, -10f); // перемещение камеры за играком
		}
	}
}
