using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterTemplate {
        public GameObject template;
        public Transform selectorTransform;
        public float percentage = 0.0F;
    }
public class Stage : MonoBehaviour
{
    GameObject player;
    public List<string> characterNameList;
    List<CharacterTemplate> characterTemplates = new List<CharacterTemplate>();
    List<KeyCode> controlList = new List<KeyCode>() { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    int currentPlayerIndex = 0;
    private bool isSwitchingCharacters = false;

    // Start is called before the first frame update
    void Start()
    {
        PopulateCharacterTemplates();
        CreateCharacterSelectors();
        ResetPlayerState();
        CreatePlayerObject(new Vector2(0, 0));
        //player.GetComponent<PlatPlayer>().SetPercentage(GlobalState.party[currentPlayerIndex].percentage);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCharacter();
    }

    void CreateCharacterSelectors() {
        for (int i = 0; i < GlobalState.party.Count; i++) {
            currentPlayerIndex = i;
            CreatePlayerObject(new Vector2(0, 0));
            Sprite playerIcon = player.GetComponent<PlatPlayer>().icon;
            Destroy(player);
            GameObject selector = Instantiate(Resources.Load("Character Selector") as GameObject, new Vector2(i * 80 + 40, 390), Quaternion.identity);
            selector.transform.SetParent(GameObject.Find("Canvas").transform);
            Transform panelTransform = selector.transform.Find("Panel");
            panelTransform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            panelTransform.Find("Icon").GetComponent<Image>().sprite = playerIcon;
            panelTransform.Find("Percentage").GetComponent<Text>().text = GlobalState.party[i].percentage + "%";

            SetSelectorSelected(panelTransform, i == 0);

            GlobalState.party[i].selectorTransform = panelTransform;
        }
        currentPlayerIndex = 0;
    }

    void CreatePlayerObject(Vector2 loc) {
        player = Instantiate(GlobalState.party[currentPlayerIndex].template, loc, Quaternion.identity) as GameObject;
    }

    void ResetPlayerState() {
        CreatePlayerObject(new Vector2(0, 0));
        PlayerState.SetPlayerInit(player.GetComponent<PlatPlayer>(), GlobalState.party[currentPlayerIndex].percentage);
        Destroy(player);
    }

    void SetSelectorSelected(Transform selectorTransform, bool isSelected) {
        if (isSelected) {
            selectorTransform.GetComponent<Image>().color = new Color32(133,133,133,255);
        } else {
            selectorTransform.GetComponent<Image>().color = new Color32(133,133,133,100);
        }
    }

    void PopulateCharacterTemplates() {
        // Return if already populated
        if (GlobalState.party.Count > 0) { return; }
        foreach (string charName in characterNameList) {
            CharacterTemplate template = new CharacterTemplate();
            template.template = Resources.Load("Characters/" + charName) as GameObject;
            GlobalState.party.Add(template);
        }
    }

    void SwitchCharacter() {
        for (int i = 0; i < GlobalState.party.Count; i++) {
            if (i == currentPlayerIndex) { continue; }
            if (Input.GetKeyDown(controlList[i])) {
                isSwitchingCharacters = true;
                Vector2 playerLoc = player.transform.position;
                PlayerState.SetPlayerInit(player.GetComponent<PlatPlayer>(), GlobalState.party[i].percentage);
                Destroy(player);
                SetSelectorSelected(GlobalState.party[currentPlayerIndex].selectorTransform, false);
                currentPlayerIndex = i;
                CreatePlayerObject(playerLoc);
                SetSelectorSelected(GlobalState.party[currentPlayerIndex].selectorTransform, true);
            }
        }
    }

    public void SetSelectorPercentage(float pct) {
        GlobalState.party[currentPlayerIndex].percentage = pct;
        GlobalState.party[currentPlayerIndex].selectorTransform.Find("Percentage").GetComponent<Text>().text = pct + "%";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlatCharacter character = other.gameObject.GetComponent<PlatCharacter>();
        if (character != null)
        {
            if (isSwitchingCharacters) {
                isSwitchingCharacters = false;
            } else {
                SceneManager.LoadScene("RPG");
                character.SetPercentage(0.0F);
                other.gameObject.transform.position = new Vector2(0, 0);
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }

        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            Destroy(other.gameObject);
        }

    }
}
