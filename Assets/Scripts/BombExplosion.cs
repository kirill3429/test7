using System.Collections;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private bool isActive = false;

    private void Awake()
    {
        StartCoroutine(Delay());
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        isActive = true;
        StopCoroutine(Delay());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive)
        {
            collision.GetComponent<Effects>().SlowEffect();
            Destroy(gameObject);
        }
    }
}
