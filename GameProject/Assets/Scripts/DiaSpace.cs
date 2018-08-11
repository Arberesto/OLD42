using UnityEngine;

public class DiaSpace : MonoBehaviour {
    public GameObject respawn; 
    private void OnTriggerEnter2D(Collider2D other) // создание тригера
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawn.transform.position;
        }
    }
}
