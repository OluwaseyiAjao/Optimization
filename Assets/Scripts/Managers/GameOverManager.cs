using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	[SerializeField] public PlayerHealthSO playerHP;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;
	private string GameOverString = "GameOver";

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (playerHP.currentHealth <= 0)
        {
            anim.SetTrigger(GameOverString);

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
        }
    }
}
