
using UnityEngine;

public class DogDrag : MonoBehaviour
{
    [SerializeField]
    private DogAI _dogAI;
    [SerializeField]
    private Transform _player;
    public Transform movePointPlayer;
    
    private PlayerState _playerState;
    void Start()
    {
        _playerState = _player.GetComponent<PlayerState>();
        _dogAI = GetComponentInParent<DogAI>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_playerState.state == PlayerState.State.Dragged)
        {
            _player.position = transform.position;
            movePointPlayer.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerState.state = PlayerState.State.Dragged;
        _dogAI._state = DogAI.State.GoHome;
        _dogAI.isDragging = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerState.state = PlayerState.State.Free;
        _dogAI.isDragging = false;
    }
}
