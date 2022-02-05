public class AlreadyTalkedConversation : Conversation {

    public AlreadyTalkedConversation() {
        id = "ALREADY_TALKED";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("We\'ve already talked, so I'm saying something different.", DialogMood.Neutral);
        start.SetNextStandard(new StandardPage("Goodbye.", DialogMood.Neutral));
        return start;
    }

}