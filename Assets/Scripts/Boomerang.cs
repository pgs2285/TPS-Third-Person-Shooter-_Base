using UnityEngine;

public class Boomerang : MonoBehaviour
{

    private PlayerInputSystem _playerInputSystem;
    private Animator _animator;
    private int _countAttack = Animator.StringToHash("AttackCount");
    [SerializeField]
    private GameObject _player;
    void Start()
    {
        _playerInputSystem = _player.GetComponent<PlayerInputSystem>();
        _player.TryGetComponent(out _animator);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {// 왼쪽 마우스 입력시 

    
            AttackCount = 0;
            _animator.SetTrigger("Attack");
           
            
        }
    }

    public int AttackCount
    {
        get => _animator.GetInteger(_countAttack);
        set => _animator.SetInteger(_countAttack, value);
    }

}
