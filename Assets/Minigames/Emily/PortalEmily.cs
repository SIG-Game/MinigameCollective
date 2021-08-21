using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEmily : MonoBehaviour
{
    public string LevelName;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(LevelName);
        }
    }
}
