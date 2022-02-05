public class TestConversation : Conversation {
    public TestConversation() {
        id = "TEST";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("Hello World!", DialogMood.Happy);
        StandardPage node = start.SetNextStandard(new StandardPage("I am a cohesive, multi-page conversation!", DialogMood.Happy));
        node = node.SetNextStandard(new StandardPage("Look at me go! Aren't I cool?", DialogMood.Neutral));
        node = node.SetNextStandard(new StandardPage("No?", DialogMood.Sad));
        node = node.SetNextStandard(new StandardPage("Well, you're not cool >:(", DialogMood.Angry));
        return start;
    }

}