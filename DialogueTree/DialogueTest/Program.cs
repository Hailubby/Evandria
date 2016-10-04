
using DialogueTree;
using System.Xml.Serialization;
using System.IO;

namespace DialogueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDialogue();
        }

        public static void TestDialogue() {
            Dialogue dialogue = new Dialogue();

            //create some nodes ie npc replies
            DialogueNode node1 = new DialogueNode("Hi");
            DialogueNode node2 = new DialogueNode("Why yes i do. ___ lives a few houses down from me so we see each other quite often. Why do you ask?");
            DialogueNode node3 = new DialogueNode("Sure thing. How may I help you Alex?");
            DialogueNode node4 = new DialogueNode("Sorry I don't know anything");
            DialogueNode node5 = new DialogueNode("Ahhh _____ is a very hard worker. Animal lover too.");

            dialogue.AddNode(node1);
            dialogue.AddNode(node2);
            dialogue.AddNode(node3);
            dialogue.AddNode(node4);
            dialogue.AddNode(node5);

            //add exit options to nodes 4
            dialogue.AddOption("Thankyou for your time", node4, null);
            dialogue.AddOption("Can you tell me something you have heard about them?", node4, null);

            //add options to node 1
            dialogue.AddOption("Hello. Do you know someone named ____?", node1, node2);
            dialogue.AddOption("Hello, I'm Alex from the ISC. Do you have time for a few questions?", node1, node3);
            dialogue.AddOption("Have you heard anything fishy about ____?", node1, node4);

            //add options to node 2
            dialogue.AddOption("I'm doing some background research as __ is a potential candidate to go to Evandria. What do you know about __?", node2, node5);
            dialogue.AddOption("That's confidential sorry. Is there anything about ___ that worries you?", node2, node4);

            //add options to node 3
            dialogue.AddOption("Do you happen to know anyone named ____?", node3, node2);
            dialogue.AddOption("Our records state that ___ lives in this neighbourhood. Do you know anything about them?", node3, node4);

            //add options to node 5
            dialogue.AddOption("Our records show that they have ____. Do you know anything about that?", node5, node4);
            dialogue.AddOption("Are they _____?", node5, node4);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("test_npc_dialogue2.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void JessicaDialogue()
        {

        }
    }
}
