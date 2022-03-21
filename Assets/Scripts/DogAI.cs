
using UnityEngine;
using UnityEngine.Tilemaps;

public class DogAI : MonoBehaviour
{
    private InputHandler _input;
    private MoveController _moveController;
    public Vector3Int targetPos;
    public Vector3Int dogPos;
    
    public enum State
    {
        Patrolling,
        Chasing,
        GoHome
    }

    public bool isInSight;
    public bool isDragging;
    public float delay;

    public State _state;
    private float lastStepTime;

    [SerializeField]
    private Tilemap _groundTileMap;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _home;
    void Start()
    {
        _input = GetComponent<InputHandler>();
        _state = State.Patrolling;
        _moveController = GetComponent<MoveController>();
    }


    private void FixedUpdate()
    {

        if (isInSight && !isDragging) _state = State.Chasing;
        else if (isDragging) _state = State.GoHome;
        else _state = State.Patrolling;

        switch (_state)
        {
            case State.Patrolling:
                Patrolling();
                break;
            case State.Chasing:
                GoToTarget(_target.position,transform.position);
                break;
            case State.GoHome:
                GoToTarget(_home.position, transform.position);
                break;

        }
        
    }

    void Patrolling()
    {
        if ((Time.time - lastStepTime) > delay)
        {
            int direction = Random.Range(1, 5);
            
            lastStepTime = Time.time;

            switch (direction)
            {
                case 1:
                    _input.direction = Vector3.up;
                    break;
                case 2:
                    _input.direction = Vector3.down;
                    break;
                case 3:
                    _input.direction = Vector3.right;
                    break;
                case 4:
                    _input.direction = Vector3.left;
                    break;
            }
        }
    }

    void GoToTarget(Vector3 target, Vector3 dog)
    {
        targetPos = _groundTileMap.WorldToCell(target);
        dogPos = _groundTileMap.WorldToCell(dog);

        if (targetPos.y > dogPos.y && _moveController.CanMove(Vector3.left))
        {
            _input.direction = Vector3.left;
        }
        else if (targetPos.y < dogPos.y && _moveController.CanMove(Vector3.right))
        {
            _input.direction = Vector3.right;
        }
        else if (targetPos.x > dogPos.x && _moveController.CanMove(Vector3.up))
        {
            _input.direction = Vector3.up;
        }
        else
        {
            _input.direction = Vector3.down;
        }

    }

}
