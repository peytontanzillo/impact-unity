using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGPortal : MonoBehaviour
{
    public string goesTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RPGPlayer player = other.gameObject.GetComponent<RPGPlayer>();
        if (player != null) {
            GlobalState.enemyDestroyed.Clear();
            SceneManager.LoadScene(goesTo);
        }
    }
}
