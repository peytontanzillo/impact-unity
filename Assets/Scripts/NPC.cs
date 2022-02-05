using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    RPGPlayer conversationWith;
    GameObject dialogBox;
    Dialog dialog;
    public Dictionary<DialogMood, Sprite> moods = new Dictionary<DialogMood, Sprite>();

    [System.Serializable]
    public struct Mood {
        public DialogMood mood;
        public Sprite sprite;
    }
    public Mood[] moodList;

    public string conversation;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Mood mood in moodList) {
            moods.Add(mood.mood, mood.sprite);
        }
        if (!GlobalState.conversations.ContainsKey(gameObject.name)) { GlobalState.conversations.Add(gameObject.name, conversation); }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EndConversation() {
        Destroy(dialogBox);
        conversationWith.talkingTo = null;
    }

    public void ContinueConversation() {
        dialog.NextPage();
        DialogPage pg = dialog.GetPage();
        if (pg == null) {
            EndConversation();
        } else if (pg is DialogEnd) {
            GlobalState.conversations[gameObject.name] = ((DialogEnd) pg).nextConversation;
            EndConversation();
        }
    }

    public void StartConversation(RPGPlayer player) {
        if (dialogBox == null) {
            conversationWith = player;
            dialogBox = Instantiate(Resources.Load("Dialog Box") as GameObject, new Vector2(510, 60), Quaternion.identity);
            dialogBox.transform.SetParent(GameObject.Find("Canvas").transform);
            dialog = dialogBox.GetComponent<Dialog>();
            dialog.StartDialog(this);
        }
    }
}
