using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    RPGPlayer conversationWith;
    GameObject dialogBox;
    Dialog dialog;

    public string conversation;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (dialog.isFinished()) {
            EndConversation();
        }
    }

    public void StartConversation(RPGPlayer player) {
        if (dialogBox == null) {
            conversationWith = player;
            dialogBox = Instantiate(Resources.Load("Dialog Box") as GameObject, new Vector2(510, 60), Quaternion.identity);
            dialogBox.transform.SetParent(GameObject.Find("Canvas").transform);
            dialog = dialogBox.GetComponent<Dialog>();
            dialog.StartDialog(dialogBox.transform.Find("Panel").Find("Text").GetComponent<Text>(), ConversationManager.GetConversationStart(conversation));
        }
    }
}
