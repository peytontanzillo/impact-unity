public class TestConversation2 : Conversation {

    public TestConversation2() {
        id = "TEST2";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("Hey, I'm a <b>different</b> NPC.\nAm I cooler than the other NPC?", DialogMood.Neutral);
        PlayerOption isCooler = new PlayerOption(DialogMood.Neutral);
        StandardPage pathYes = new StandardPage("I knew I was cooler\n:sunglasses:", DialogMood.Happy);
        isCooler.AddOption("Yes", pathYes);
        StandardPage pathNo = new StandardPage("Well, your opinion is wrong\n:sad sunglasses:", DialogMood.Sad);
        pathNo.SetNextStandard(new StandardPage("<b>YOU\'RE NOT COOL</b>", DialogMood.Angry));
        isCooler.AddOption("No", pathNo);
        start.SetNextPlayerOption(isCooler);
        return start;
    }

}