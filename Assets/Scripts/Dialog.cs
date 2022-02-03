using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour
{
    Text textObject;
    DialogPage page;
    int selectedIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update() {
        if (page is PlayerOption) {
            PlayerOption po = (PlayerOption) page;
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                selectedIndex = selectedIndex == 0 ? po.GetOptionCount() - 1 : selectedIndex - 1;
                UpdateDialogDisplay();
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                selectedIndex = selectedIndex == po.GetOptionCount() - 1 ? 0 : selectedIndex + 1;
                UpdateDialogDisplay();
            }
        }
    }

    public void StartDialog(Text textObject, DialogPage page) {
        this.textObject = textObject;
        this.page = page;
        UpdateDialogDisplay();
    }

    public void NextPage() {
        switch (page) {
            case StandardPage sp:
                this.page = sp.next;
                break;
            case PlayerOption po:
                this.page = po.GetNextAtIndex(selectedIndex);
                break;
        }
        selectedIndex = 0;
        UpdateDialogDisplay();
    }

    void UpdateDialogDisplay() {
        if (page != null) {
            switch (page) {
                case StandardPage sp:
                    textObject.text = sp.text;
                    break;
                case PlayerOption po:
                    textObject.text = GetPlayerOptionText(po);
                    break;
            }
        }
    }

    string GetPlayerOptionText(PlayerOption po) {
        List<string> optionStrings = po.GetOptionStrings();
        string totalString = "";
        for (int i = 0; i < optionStrings.Count; i++) {
            if (i == selectedIndex) {
                totalString += "<b><color=#ffff00ff>";
                totalString += optionStrings[i];
                totalString += "</color></b>";
            } else {
                totalString += optionStrings[i];
            }
            totalString += "\n";
        }
        return totalString;
    }

    public DialogPage GetPage() {
        return page;
    }
}
