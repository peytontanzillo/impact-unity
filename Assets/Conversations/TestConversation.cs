public class TestConversation : Conversation {

    public TestConversation() : base() {}
    public override DialogPage ConversationStart() {
        start = new DialogPage("Hello World!");
        DialogPage node = start.SetNext(new DialogPage("I am a cohesive, multi-page conversation!"));
        node = node.SetNext(new DialogPage("Look at me go! Aren't I cool?"));
        node = node.SetNext(new DialogPage("No?"));
        node = node.SetNext(new DialogPage("Well, you're not cool >:("));
        return start;
    }

}