public class TestConversation : Conversation {
    public TestConversation() {
        id = "TEST";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("Hello World!");
        StandardPage node = start.SetNextStandard(new StandardPage("I am a cohesive, multi-page conversation!"));
        node = node.SetNextStandard(new StandardPage("Look at me go! Aren't I cool?"));
        node = node.SetNextStandard(new StandardPage("No?"));
        node = node.SetNextStandard(new StandardPage("Well, you're not cool >:("));
        return start;
    }

}