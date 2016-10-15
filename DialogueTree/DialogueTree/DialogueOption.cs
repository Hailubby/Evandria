
//Text character is saying
namespace DialogueTree
{
    public class DialogueOption
    {
        public string Text;
        public int DestinationNodeID;

        //default constructor for serialisation
        public DialogueOption() { }

        public DialogueOption(string text, int dest) {
            this.Text = text;
            this.DestinationNodeID = dest;
        }
    }
}
