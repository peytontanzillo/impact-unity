using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour
{
    Text textObject;
    DialogPage page;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartDialog(Text textObject, DialogPage page) {
        this.textObject = textObject;
        this.page = page;
        textObject.text = page.text;

    }

    public void NextPage() {
        this.page = page.next;
        UpdateDialogDisplay();
    }

    void UpdateDialogDisplay() {
        if (page != null) {
            textObject.text = page.text;
        }
    }

    public bool isFinished() {
        return page == null;
    }
}
