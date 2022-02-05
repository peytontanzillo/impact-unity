public class ApplesOrangesConversation : Conversation {

    public ApplesOrangesConversation() {
        id = "APPLES_ORANGES";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("Do you like apples or oranges?", DialogMood.Neutral);
        PlayerOption applesOranges = new PlayerOption(DialogMood.Neutral);
        StandardPage path = new StandardPage("Oh, interesting...", DialogMood.Neutral);
        applesOranges.AddOption("Apples", path);
        applesOranges.AddOption("Oranges", path);
        start.SetNextPlayerOption(applesOranges);
        path = path.SetNextStandard(new StandardPage("Me? I think they're incomparable...", DialogMood.Happy));
        path.SetNextConversation("ALREADY_TALKED");
        return start;
    }

}