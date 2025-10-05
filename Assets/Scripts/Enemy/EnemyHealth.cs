using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public EnemyData _enemyData;
    public int currentHealth;
    public AudioClip deathClip;
    private float remainingTime = 0;
    private EnemyPooling pool;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    
    private string DeadString = "Dead";

    public UnityEvent <int> addScore;
    

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = _enemyData.startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * _enemyData.sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (DeadString);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        addScore?.Invoke(_enemyData.scoreValue);
        StartCoroutine(DeactiveEnemy());
    }

    IEnumerator DeactiveEnemy()
    {
        yield return new WaitForSeconds (2);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        remainingTime = 3;
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.AddToQueue(this);
        }
    }

    public void SetPool(EnemyPooling ep)
    {
        pool = ep;
    }
}
