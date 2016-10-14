using System.Collections.Generic;


//What NPC says
namespace DialogueTree
{
    public class DialogueNode
    {
        public int NodeID = -1;
        public string Text;
        public bool isClue = false;
        public List<DialogueOption> Options;

        //default constructor for XML serialisation
        public DialogueNode() {
            Options = new List<DialogueOption>();
        }

        public DialogueNode(string text) {
            this.Text = text;
            Options = new List<DialogueOption>();
        }
    }
}
