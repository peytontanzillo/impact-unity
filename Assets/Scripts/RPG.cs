using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalState.currentRoom = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
