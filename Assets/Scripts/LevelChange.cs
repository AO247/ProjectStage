using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class LevelChange : MonoBehaviour
{
    public Animator animator;

    public async void ChangeLevel()
    {
        //animator.Play("kurtyna_zaslon");
        //Debug.Log("Zas³anianie kurtyny");
        //// Poczekaj, a¿ animacja siê skoñczy
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


