using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGEnemy : MonoBehaviour
{
    Vector3 startTransform;
    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform.position;
        if (!GlobalState.enemyDestroyed.ContainsKey(startTransform)) {
            GlobalState.enemyDestroyed.Add(startTransform, false);
        }
        if (GlobalState.enemyDestroyed[startTransform]) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RPGPlayer player = other.gameObject.GetComponent<RPGPlayer>();
        if (player != null) {
            GlobalState.enemyDestroyed[startTransform] = true;
            SceneManager.LoadScene("Platform Fighter");
        }
    }
}
