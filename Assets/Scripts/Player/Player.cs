using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }


    PlayerMovement playerMovement;
    Animator animator;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        animator = GameObject.Find("EngineEffects").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        playerMovement.MoveBound();
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}
