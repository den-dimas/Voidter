using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// Singleton
public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    public UIDocument[] uiDocuments;
    public GameObject combatManager;

    void Awake()
    {
        animator.enabled = false;
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.enabled = true;

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        animator.SetTrigger("endTransition");

        if (sceneName == "ChooseWeapon")
        {
            uiDocuments[0].gameObject.SetActive(true);
            uiDocuments[1].gameObject.SetActive(false);

            uiDocuments[0].enabled = true;
            uiDocuments[1].enabled = false;
        }
        else
        {
            uiDocuments[0].gameObject.SetActive(false);
            uiDocuments[1].gameObject.SetActive(true);

            uiDocuments[0].enabled = false;
            uiDocuments[1].enabled = true;

            combatManager.SetActive(true);
        }

        Player.Instance.transform.position = new(0, -4.5f);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
