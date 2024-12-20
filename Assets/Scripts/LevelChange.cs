using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class LevelChange : MonoBehaviour
{
    public Animator animator;
    GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        if (player.GetComponent<HealthPlayer>().IsDead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public async void ChangeLevel()
    {
        //animator.Play("kurtyna_zaslon");
        //Debug.Log("Zas�anianie kurtyny");
        //// Poczekaj, a� animacja si� sko�czy
        //await WaitForAnimation(animator, "kurtyna_zaslon");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private async Task WaitForAnimation(Animator animator, string animationName)
    {
        if (animator == null) return;

        
        var animationState = animator.GetCurrentAnimatorStateInfo(10);
        while (animationState.IsName(animationName) && animationState.normalizedTime < 1.0f)
        {
            await Task.Yield();
            animationState = animator.GetCurrentAnimatorStateInfo(10);
        }
    }
}


