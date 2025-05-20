using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    public List<Enemy> enemies;
    public Transform zPrefab;
    private Transform _z1;
    private Transform _z2;

    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;

    private Animator _animator;
    private bool _isWalking;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, Random.Range(-180 , 180), 0);
        CreateAndAnimateZ();
    }

    private void CreateAndAnimateZ()
    {
        _z1 = Instantiate(zPrefab, transform);
        _z1.position = transform.position + Vector3.up * 2;
        _z1.localScale = Vector3.zero;
        _z1.DOMoveY(_z1.transform.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        _z1.DOScale(1, 1f).SetLoops(-1, LoopType.Restart);
        _z1.LookAt(_z1.transform.position + Vector3.forward);

        _z2 = Instantiate(zPrefab , transform);
        _z2.position = transform.position + Vector3.up * 2;
        _z2.localScale = Vector3.zero;
        _z2.DOMoveY(_z2.transform.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        _z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        _z2.LookAt(_z2.transform.position + Vector3.forward);

    }

    private void Update()
    {
        if (_player.isAppleCollected)
        {
            
            navMeshAgent.destination = _player.transform.position;
            if (!_isWalking)
            {
                _isWalking= true;
                _animator.SetTrigger("Walk");
                _z1.DOKill();
                _z2.DOKill();
                Destroy(_z1.gameObject);
                Destroy(_z2.gameObject);


            }

        }
    }

    public void Stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Idle");

    }
}
