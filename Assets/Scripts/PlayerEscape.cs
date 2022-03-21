
using UnityEngine;

public class PlayerEscape : MonoBehaviour
{
    InputHandler _input;
    PlayerState _state;
    public DogAI _dogAI;

    public float escapeProgress;
    public float escapeMax;



    void Start()
    {
        escapeProgress = 0;
        _input = GetComponent<InputHandler>();
        _state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.action && _dogAI.isDragging)
        {
            escapeProgress += 15 * Time.deltaTime;
            if (escapeProgress >= escapeMax)
            {
                _dogAI.isDragging = false;
                _state.state = PlayerState.State.Free;
                escapeProgress = 0;
                
            }
            
        }
        if (escapeProgress > 0)
            escapeProgress -= Time.deltaTime;

    }
}
