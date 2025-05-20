using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public LevelManager levelManager;

    public float speed;
    public bool isAppleCollected;
    private Rigidbody _rb;

    private bool _isCharacterWalking;
    public Animator animator;

    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _rb = GetComponent<Rigidbody>();
        _rb.position = new Vector3(0, 0, -8);
        isAppleCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            isAppleCollected = true;
            levelManager.AppleCollected();
        }
        if (other.CompareTag("Door") && isAppleCollected == true)
        {
            gameDirector.LevelCompleted();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    
    void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
            SetWalkAnimationSpeed(2.5f);
        }
        else
        {
            speed = 2;
            SetWalkAnimationSpeed(1f);

        }



        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
            TriggerWalkAnimation();

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            TriggerWalkAnimation();

        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            TriggerWalkAnimation();

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            TriggerWalkAnimation();

        }

        if (direction.magnitude < .1f)
        {
            TriggerIdleAnimation();
        }
        else
        {
            TriggerWalkAnimation();
        }


            transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;
    }

    void TriggerWalkAnimation()
    {
        if (!_isCharacterWalking)
        {
            animator.SetBool("isWalking", true);
            _isCharacterWalking = true;
        }
    }

    void TriggerIdleAnimation()
    {
        if (_isCharacterWalking)
        {
            animator.SetBool("isWalking", false);
            _isCharacterWalking = false;
        }
    }
    void SetWalkAnimationSpeed(float s)
    {
        animator.SetFloat("WalkSpeedMultipler" , s);
    }


}
