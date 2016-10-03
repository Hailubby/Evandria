
using DialogueTree;
using System.Xml.Serialization;
using System.IO;

namespace DialogueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dialogue dialogue = new Dialogue();

            //create some nodes ie npc replies
            DialogueNode node1 = new DialogueNode("Hi, welcome to the test dialogue.");
            DialogueNode node2 = new DialogueNode("Well that's rude, I don't want to talk to you!");
            DialogueNode node3 = new DialogueNode("My name is Sarah.");
            DialogueNode node4 = new DialogueNode("Nice to meet you Alex.");

            dialogue.AddNode(node1);
            dialogue.AddNode(node2);
            dialogue.AddNode(node3);
            dialogue.AddNode(node4);

            //add exit options to nodes 2 and 4
            dialogue.AddOption("Exit", node2, null);
            dialogue.AddOption("Exit", node4, null);

            //add options to node 1
            dialogue.AddOption("You smell!", node1, node2);
            dialogue.AddOption("I'm Alex", node1, node4);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("test_npc_dialogue1.xml");

            serz.Serialize(writer, dialogue);
        }
    }
}
