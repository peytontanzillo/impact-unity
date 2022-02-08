public class ConditionalTestConversation : Conversation {

    public ConditionalTestConversation() {
        id = "CONDITIONAL";
    }
    public override DialogPage ConversationStart() {
        StandardPage start = new StandardPage("Hello there!", DialogMood.Neutral);
        ConditionalPage cond = new ConditionalPage(HasDefeatedAllEnemies);
        StandardPage pathDefeated = new StandardPage("Thank you <b><i>so</i></b> much for getting rid of those enemies!", DialogMood.Happy);
        cond.AddCondition("DEFEATED", pathDefeated);
        pathDefeated.SetNextStandard(new StandardPage("Now I can continue to sit here and say the same things over and over!", DialogMood.Happy));


        StandardPage pathNotDefeated = new StandardPage("Would you please defeat those enemies over there?", DialogMood.Neutral);
        pathNotDefeated.SetNextStandard(new StandardPage("They're really ruining my day-to-day life here...", DialogMood.Sad));
        cond.AddCondition("NOT_DEFEATED", pathNotDefeated);      
        start.SetNextConditionalPage(cond);
        return start;
    }

    private string HasDefeatedAllEnemies() {
        return GlobalState.enemyDestroyed.ContainsValue(false) ? "NOT_DEFEATED" : "DEFEATED";
    }

}