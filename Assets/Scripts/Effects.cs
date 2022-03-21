using System.Collections;

using UnityEngine;

public class Effects : MonoBehaviour
{
    private MoveController _moveController;
    void Start()
    {
        _moveController = GetComponent<MoveController>();
    }

    public void SlowEffect()
    {
        StartCoroutine(Slow());
        StopCoroutine(Slow());
    }
    public IEnumerator Slow()
    {
        _moveController.speed = _moveController.slowSpeed;
        yield return new WaitForSeconds(3);
        _moveController.speed = _moveController.normalSpeed;
    }
}
