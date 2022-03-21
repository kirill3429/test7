
using UnityEngine;

public class SightTrigger : MonoBehaviour
{
    private DogAI dogAI;
    void Start()
    {
        dogAI = GetComponentInParent<DogAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dogAI.isInSight = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dogAI.isInSight = false;
    }
}
