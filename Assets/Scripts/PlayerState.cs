
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State
    {
        Free,
        Dragged
    }
    public State state;
    private void Start()
    {
        state = State.Free;
    }
}
