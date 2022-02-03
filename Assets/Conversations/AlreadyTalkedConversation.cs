public class AlreadyTalkedConversation : Conversation {

    public AlreadyTalkedConversation() {
        id = "ALREADY_TALKED";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("We\'ve already talked, so I'm saying something different.");
        start.SetNextStandard(new StandardPage("Goodbye."));
        return start;
    }

}