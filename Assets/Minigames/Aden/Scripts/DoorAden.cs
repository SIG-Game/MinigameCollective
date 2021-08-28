using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAden : MonoBehaviour
{
    public string destinationScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            SceneManager.LoadScene(destinationScene);
        }
    }
}
