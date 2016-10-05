
using DialogueTree;
using System.Xml.Serialization;
using System.IO;

namespace DialogueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            JessicaDialogue();
            GabrielDialogue();
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
            Dialogue dialogue = new Dialogue();

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes I do, why do you ask?");
            var node3 = new DialogueNode("No I don't sorry");
            var node4 = new DialogueNode("Of course Alex. Feel free to ask me anything.");

            var node5 = new DialogueNode("We worked at the same company a few years back. I didn't know her too well then as she wasn't there for long. We live in the same neighbourhood now so i see her more often.");
            var node6 = new DialogueNode("Hmmm. I thought she was a bit intimidating at first as it didn't seem like she was open to interacting with her peers and preferred to work all the time");
            var node7 = new DialogueNode("I don't know the details sorry. I think it may have been due to not being able to handle the stress at work. I don't think she got along with her team that well either as she's quite an opinionated person.");
            var node8 = new DialogueNode("She seems to be doing quite well for herself now. Back then she was doing some entry level accounting work but now I've heard she's climbed her way up and become a chartered accountant.");

            var node9 = new DialogueNode("Yes she lives alone.");
            var node10 = new DialogueNode("She doesn't like to talk about them, I think she might not have a very good relationship with them.");
            var node11 = new DialogueNode("I'm not too sure. Whenever the topic is brought up she tends to get nervous. There may be parts of her private life she's trying to hide.");
            var node12 = new DialogueNode("Not personally, but I have seen them visit. Her mother is often covered in bruises though. That may be why she doesn't like talking about her family.");

            var node13 = new DialogueNode("She's had quite a few dogs actually, though i don't know what happened to them all.");
            var node14 = new DialogueNode("I've never seen her with the same one for more than a few months. I wonder if she keeps giving them away as she's too busy to look after them? But she always ends up getting a new one sometime later anyway.");

            var node15 = new DialogueNode("I don't think she has any as she's quite a workaholic. She's often quite stressed. I've told her to go see a counsellor but she doesn't seem too keen on it.");

            dialogue.AddNode(node1);
            dialogue.AddNode(node2);
            dialogue.AddNode(node3);
            dialogue.AddNode(node4);
            dialogue.AddNode(node5);
            dialogue.AddNode(node6);
            dialogue.AddNode(node7);
            dialogue.AddNode(node8);
            dialogue.AddNode(node9);
            dialogue.AddNode(node10);
            dialogue.AddNode(node11);
            dialogue.AddNode(node12);
            dialogue.AddNode(node13);
            dialogue.AddNode(node14);
            dialogue.AddNode(node15);

            //node 1 options
            dialogue.AddOption("Hello, do you know of Jessica Chang?", node1, node2);
            dialogue.AddOption("Hello, do you know of Gabriel Johan?", node1, node3);

            //node 2 options
            dialogue.AddOption("I'm Alex from the ISC. Do you have time to answer a few questions regarding Jessica?", node2, node4);
            dialogue.AddOption("What is your relationship with Jessica?", node2, node5);
            dialogue.AddOption("Does Jessica have any pets?", node2, node13);

            //Exit option for node 3
            dialogue.AddOption("Thankyou for your time", node3, null);
            dialogue.AddOption("That's alright, see you", node3, null);

            //node 4 options
            dialogue.AddOption("What is your relationship with Jessica?", node4, node5);
            dialogue.AddOption("Does Jessica live alone?", node4, node9);
            dialogue.AddOption("Does Jessica have any pets?", node4, node13);

            //node 5 options
            dialogue.AddOption("What was your first impression of her?", node5, node6);
            dialogue.AddOption("Why wasn't she at the company for long?", node5, node7);

            //node 6 options
            dialogue.AddOption("Why wasn't she at the company for long?", node6, node7);
            dialogue.AddOption("What is Jessica doing now?", node6, node8);

            //node 7 options
            dialogue.AddOption("What is Jessica doing now?", node7, node8);
            dialogue.AddOption("Does Jessica have any hobbies or pets?", node7, node13);

            //node 8 options
            dialogue.AddOption("Thank you for your time", node8, null);

            //node 9 options
            dialogue.AddOption("What about her relatives?", node9, node10);
            dialogue.AddOption("What are her hobbies?", node9, node15);

            //node 10 options
            dialogue.AddOption("Why doesn't she like talking about them?", node10, node11);
            dialogue.AddOption("Have you met any of her relatives?", node10, node12);

            //node 11 exit options
            dialogue.AddOption("Interesting...", node11, null);
            dialogue.AddOption("Thankyou for you time. See you.", node11, null);

            //node 12 exit options
            dialogue.AddOption("Interesting...", node12, null);
            dialogue.AddOption("Thank you for your time.", node12, null);

            //node 13 options
            dialogue.AddOption("What do you mean by that?", node13, node14);
            dialogue.AddOption("What are her hobbies?", node13, node15);

            //node 14 options & exit options
            dialogue.AddOption("Interesting...", node14, null);
            dialogue.AddOption("Does she have any hobbies?", node14, node15);

            //node 15 exit option
            dialogue.AddOption("Thankyou for your cooperation, it was very helpful", node15, null);
            dialogue.AddOption("Thank you for your time", node15, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("jessica_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void GabrielDialogue()
        {
            Dialogue dialogue = new Dialogue();

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes I do, why do you ask?");
            var node3 = new DialogueNode("No I don't sorry");
            var node4 = new DialogueNode("Of course Alex. Fire away!");

            var node5 = new DialogueNode("We work in the neurology department at the hospital together. He's a very smart man, I look up to him a lot.");

            var node6 = new DialogueNode("We don't see him outside of work much but when we do talk, he often mentions the ShipStar charity.");
            var node7 = new DialogueNode("It seems to be a charity which supports local orphanages.");
            var node8 = new DialogueNode("No, I don't have the time or the money.");
            var node9 = new DialogueNode("I think it was around 6 years ago when he first started supporting it. I remember he took quite a long time off from work back then. I'm pretty sure he first mentioned it after he got back from his time off.");
            var node10 = new DialogueNode("I'm not too sure sorry. I think it may have been something to do with his family, it was due to private reasons so none of us really know why.");
            
            var node11 = new DialogueNode("Not that I know of. He is always preoccupied with his research, but I do see him looking at his family photos often and smiling during his breaks. They must give him a lot of strength when things get stressful.");
            
            var node12 = new DialogueNode("He's a diligent worker and is polite to everyone. But he doesn't seem to socilise with others much, he's often working in the labs or his office.");
            var node13 = new DialogueNode("We offer him to join us but he always declines.");
            var node14 = new DialogueNode("Now that I think of it, he used to come to work dinners and outing quite a lot and would bring his wife along too. I guess time changes people.");
            
            var node15 = new DialogueNode("He may be quiet and not talk much, but I think he's a really great guy! He's not really close with any of us in the department at work, but he's always around to lend a helping hand.");

            dialogue.AddNode(node1);
            dialogue.AddNode(node2);
            dialogue.AddNode(node3);
            dialogue.AddNode(node4);
            dialogue.AddNode(node5);
            dialogue.AddNode(node6);
            dialogue.AddNode(node7);
            dialogue.AddNode(node8);
            dialogue.AddNode(node9);
            dialogue.AddNode(node10);
            dialogue.AddNode(node11);
            dialogue.AddNode(node12);
            dialogue.AddNode(node13);
            dialogue.AddNode(node14);
            dialogue.AddNode(node15);

            //node 1 options
            dialogue.AddOption("Hello, do you know of Jessica Chang?", node1, node3);
            dialogue.AddOption("Hello, do you know of Gabriel Johan?", node1, node2);

            //node 2 options
            dialogue.AddOption("I'm Alex from the ISC and would like to ask you a few questions regarding Gabriel if you don't mind.", node2, node4);
            dialogue.AddOption("How did you and Gabriel meet?", node2, node5);
            dialogue.AddOption("What type of person do you see Gabriel as?", node2, node15);

            //Exit option for node 3
            dialogue.AddOption("Thankyou for your time", node3, null);
            dialogue.AddOption("That's alright, see you", node3, null);

            //node 4 options
            dialogue.AddOption("How did you and Gabriel meet?", node4, node5);
            dialogue.AddOption("Does Gabriel have any hobbies or things he particularly enjoys?", node4, node11);
            dialogue.AddOption("What kind of person is Gabriel?", node4, node15);

            //node 5 options
            dialogue.AddOption("Do you know if he's involved in anything else apart from work?", node5, node6);
            dialogue.AddOption("What do you have to say about his attitube towards his work and peers?", node5, node12);

            //node 6 options
            dialogue.AddOption("Can you tell me more about this charity?", node6, node7);
            dialogue.AddOption("Are you involved in this charity too?", node6, node8);

            //node 7 options
            dialogue.AddOption("How long has he been supporting this charity?", node7, node9);
            dialogue.AddOption("Are you two involved in this charity together?", node7, node8);

            //node 8 options
            dialogue.AddOption("Ahh yeah that's understandable. Thankyou for your time.", node8, null);
            dialogue.AddOption("Thankyou for your cooperation.", node8, null);

            //node 9 options
            dialogue.AddOption("Why did he take a long time off work?", node9, node10);
            dialogue.AddOption("Does he have any hobbies he enjoys?", node9, node11);

            //node 10 options
            dialogue.AddOption("Thankyou for answering my questions. See you.", node10, null);

            //node 11 options
            dialogue.AddOption("Does he seem interested in any work events?", node11, node13);
            dialogue.AddOption("Is he involved in anything else apart from work?", node11, node6);
            dialogue.AddOption("Thankyou for you time sir. Good day.", node11, null);

            //node 12 options
            dialogue.AddOption("Does he attend many work events?", node12, node13);
            dialogue.AddOption("What type of person do you see Gabriel as?", node12, node15);

            //node 13 options
            dialogue.AddOption("Any reason why?", node13, node14);
            dialogue.AddOption("Is he involved in anything else apart from work?", node13, node6);

            //node 14 options
            dialogue.AddOption("Thankyou for your cooperation.", node14, null);
            dialogue.AddOption("Thankyou for answering all my questions. It was very helpful.", node14, null);

            //node 15 options
            dialogue.AddOption("Thankyou for your time", node15, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("gabriel_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }
    }
}
