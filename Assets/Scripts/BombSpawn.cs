
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    private InputHandler _input;
    private PlayerState _state;
    private float currentTime;
    private float lastSet = 0;
    private bool canSet;

    public float cooldown;
    public float delta;

    [SerializeField]
    private GameObject _bombPrefab;
    void Start()
    {
        _input = GetComponent<InputHandler>();
        _state = GetComponent<PlayerState>();

    }


    void Update()
    {
        if (_input.action && _state.state == PlayerState.State.Free) Spawn();

        currentTime = Time.time;
        delta = currentTime - lastSet;
        if ((delta) > cooldown)
            canSet = true;
        else
            canSet = false;
        
    }

    void Spawn()
    {
        if (canSet)
        {
            GameObject bomb = Instantiate(_bombPrefab, gameObject.transform, false);
            bomb.transform.parent = null;
            lastSet = Time.time;
        }
        
    }
}
