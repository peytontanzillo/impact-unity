using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class DialogPage {

}
public class StandardPage : DialogPage {
    public string text;
    public DialogPage next = null;
    public StandardPage(string text) {
        this.text = text;
    }
    public StandardPage SetNextStandard(StandardPage next) {
        this.next = next;
        return next;
    }

    public PlayerOption SetNextPlayerOption(PlayerOption next) {
        this.next = next;
        return next;
    }

    public void SetNextConversation(string nextConversation) {
        this.next = new DialogEnd(nextConversation);
    }
}

public class PlayerOption : DialogPage {
    private class DialogOption {
        public string text;
        public DialogPage next;

        public DialogOption(string text, DialogPage next) {
            this.text = text;
            this.next = next;
        }
    }
    private List<DialogOption> options = new List<DialogOption>();

    public void AddOption(string text, DialogPage next) {
        options.Add(new DialogOption(text, next));
    }

    public List<string> GetOptionStrings() {
        return options.Select(option => option.text).ToList();
    }

    public DialogPage GetNextAtIndex(int index) {
        return options[index].next;
    }

    public int GetOptionCount() {
        return options.Count;
    }
}

public class DialogEnd : DialogPage {
    public string nextConversation;

    public DialogEnd(string nextConversation) {
        this.nextConversation = nextConversation;
    }

}

public abstract class Conversation {
    protected string id;
    public abstract DialogPage ConversationStart();

    public string GetID() {
        return id;
    }
}

public static class ConversationManager {
        private static Dictionary<string, Conversation> conversations = new Dictionary<string, Conversation>();

        static ConversationManager() {
            List<Conversation> conversationList = new List<Conversation>() {
                new TestConversation(),
                new TestConversation2(),
                new AlreadyTalkedConversation(),
                new ApplesOrangesConversation()
            };

            foreach (Conversation conversation in conversationList) {
                conversations.Add(conversation.GetID(), conversation);
            }
        }
        public static DialogPage GetConversationStart(string key) {
            return conversations[key].ConversationStart();
        }
 }