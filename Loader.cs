using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    [SerializeField]
    private int thisLoad;



    private void loader(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.tag == "SharedPlayer")
        {
            loader(thisLoad);
        }
    }

    public void menuLoad()
    {
        loader(1);
    }
}

