using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainManager : MonoBehaviour
{
    string sceneName;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void In()
    {
        animator.SetBool("IsOut", false);
    }
    public void Out(string sceneName)
    {
        animator.SetBool("IsOut", true);
        this.sceneName = sceneName;
    }
    public void OutTo()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
