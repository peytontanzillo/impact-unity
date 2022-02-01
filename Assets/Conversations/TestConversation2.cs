public class TestConversation2 : Conversation {

    public TestConversation2() : base() {}
    public override DialogPage ConversationStart() {
        start = new DialogPage("Hey, I'm a different NPC.");
        start.SetNext(new DialogPage("Go away."));
        return start;
    }

}