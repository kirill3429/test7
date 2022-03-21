
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    private int _animVertical;
    private int _animHorizontal;
    void Start()
    {
        anim = GetComponent<Animator>();
        _animVertical = Animator.StringToHash("Vertical");
        _animHorizontal = Animator.StringToHash("Horizontal");
    }
    public void updateAnimateValues(float horizontal , float vertical)
    {
        anim.SetFloat(_animVertical, vertical);
        anim.SetFloat(_animHorizontal, horizontal);
    }
}
