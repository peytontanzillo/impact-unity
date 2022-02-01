using System.Collections;
using System.Collections.Generic;

public class DialogPage {
    public string text;
    public DialogPage next = null;
    public DialogPage(string text) {
        this.text = text;
    }

    public DialogPage SetNext(DialogPage next) {
        this.next = next;
        return next;
    }

    public DialogPage SetBefore(DialogPage before) {
        before.SetNext(this);
        return before;
    }
}

public abstract class Conversation {
    protected DialogPage start;
    public abstract DialogPage ConversationStart();
}

public static class ConversationManager {
        private static Dictionary<string, Conversation> conversations = new Dictionary<string, Conversation>();

        static ConversationManager() {
            conversations.Add("TEST", new TestConversation());
            conversations.Add("TEST2", new TestConversation2());
        }
        public static DialogPage GetConversationStart(string key) {
            return conversations[key].ConversationStart();
        }
 }