using UnityEngine.SceneManagement;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject win;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        win.SetActive(true);
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
    }
}
