
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveController : MonoBehaviour
{


    public float speed;
    public float normalSpeed;
    public float slowSpeed;

    private InputHandler _input;
    private AnimatorHandler _anim;
    [SerializeField]
    private Tilemap _groundTileMap;
    [SerializeField]
    private Tilemap _collisionTileMap;
    [SerializeField]
    private Transform _movePoint;

    void Start()
    {
        _input = GetComponent<InputHandler>();
        _anim = GetComponent<AnimatorHandler>();
        _movePoint.parent = null;
    }


    void FixedUpdate()
    {
        moveMovePoint();
        Move();
        updateAnimate();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, speed * Time.deltaTime);
    }
    
    public bool CanMove(Vector3 direction)
    {
        Vector3Int pos = _groundTileMap.WorldToCell(transform.position + direction);
        return !_collisionTileMap.HasTile(pos);
    }
    void moveMovePoint()
    {
        if ((Vector3.Distance(transform.position, _movePoint.position) < 0.3f) && CanMove(_input.direction))
        _movePoint.position = _groundTileMap.GetCellCenterWorld(_groundTileMap.WorldToCell(transform.position + _input.direction));
    }



    void updateAnimate()
    {
        if (_input.direction != Vector3.zero)
            _anim.updateAnimateValues(_input.direction.x, _input.direction.y);
    }

}
