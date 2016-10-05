using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> Nodes;

        public Dialogue() {
            Nodes = new List<DialogueNode>();
        }

        public void AddNode(DialogueNode node) {
            //if the node is null, it is an exit node and we do not need to add it
            if (node == null) {
                return;
            }

            //add node to the dialogue list of nodes
            Nodes.Add(node);
            //Set an ID for the node
            node.NodeID = Nodes.IndexOf(node);
        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest) {
            //add the destination load to the dialogue if it is not already there
            if (!Nodes.Contains(dest)) {
                AddNode(dest);
            }

            //add the parent node to the dialogue if it is not already there
            if (!Nodes.Contains(node)) {
                AddNode(node);
            }

            DialogueOption option;

            //create an option object. If the destination is an exit node, set index to -1
            if (dest == null) {
                option = new DialogueOption(text, -1);
            }
            else {
                option = new DialogueOption(text, dest.NodeID);
            }

            node.Options.Add(option);
        }

        public static Dialogue LoadDialogue(string path) {
            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dialogue = (Dialogue)serz.Deserialize(reader);

            return dialogue;
        }
    }
}
