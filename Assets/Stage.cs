using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    GameObject player;
    public List<string> characterNameList;
    List<GameObject> characterTemplates = new List<GameObject>();
    List<KeyCode> controlList = new List<KeyCode>() { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    int currentPlayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        PopulateCharacterTemplates();
        CreatePlayerObject(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCharacter();
    }

    void CreatePlayerObject(Vector2 loc) {
        player = Instantiate(characterTemplates[currentPlayerIndex], loc, Quaternion.identity) as GameObject;
    }

    void PopulateCharacterTemplates() {
        foreach (string charName in characterNameList) {
            characterTemplates.Add(Resources.Load("Characters/" + charName) as GameObject);
        }
    }

    void SwitchCharacter() {
        for (int i = 0; i < 4; i++) {
            if (i == currentPlayerIndex) { continue; }
            if (Input.GetKeyDown(controlList[i])) {
                Vector2 playerLoc = player.transform.position;
                PlayerState.SavePlayer(player.GetComponent<Player>());
                Destroy(player);
                currentPlayerIndex = i;
                CreatePlayerObject(playerLoc);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null)
        {
            character.SetPercentage(0.0F);
            other.gameObject.transform.position = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            Destroy(other.gameObject);
        }

    }
}
