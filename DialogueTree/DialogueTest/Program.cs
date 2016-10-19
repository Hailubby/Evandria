
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
            LandonDialogue();
            SaraDialogue();
            LouisDialogue();
            ThomasDialogue();
            ScottDialogue();
            FrancisDialogue();
            TaraDialogue();
            AsunaDialogue();
            AnzioDialogue();
        }


        public static void JessicaDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Sally";
            dialogue.clue = "Jessica seems to cycle through her pets very quickly, suspicious.";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes I do, why do you ask?");
            var node3 = new DialogueNode("No I don't sorry.");
            var node4 = new DialogueNode("Of course Alex. Feel free to ask me anything.");

            var node5 = new DialogueNode("We worked at the same company a few years back. I didn't know her too well then as she wasn't there for long. We live in the same neighbourhood now so i see her more often.");
            var node6 = new DialogueNode("Hmmm. I thought she was a bit intimidating at first as it didn't seem like she was open to interacting with her peers and preferred to work all the time.");
            var node7 = new DialogueNode("I don't know the details sorry. I think it may have been due to not being able to handle the stress at work. I don't think she got along with her team that well either as she's quite an opinionated person.");
            var node8 = new DialogueNode("She seems to be doing quite well for herself now. Back then she was doing some entry level accounting work but now I've heard she's climbed her way up and become a chartered accountant.");

            var node9 = new DialogueNode("Yes she lives alone.");
            var node10 = new DialogueNode("She doesn't like to talk about them, I think she might not have a very good relationship with them.");
            var node11 = new DialogueNode("I'm not too sure. Whenever the topic is brought up she tends to get nervous. There may be parts of her private life she's trying to hide.");
            var node12 = new DialogueNode("Not personally, but I have seen them visit. Her mother is often covered in bruises though. That may be why she doesn't like talking about her family.");

            var node13 = new DialogueNode("She's had quite a few dogs actually, though i don't know what happened to them all.");
            var node14 = new DialogueNode("I've never seen her with the same one for more than a few months. I wonder if she keeps giving them away as she's too busy to look after them? But she always ends up getting a new one sometime later anyway.");
            node14.isClue = true;

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

            //node 2 options
            dialogue.AddOption("I'm Alex from the ISC. Do you have time to answer a few questions regarding Jessica?", node2, node4);
            dialogue.AddOption("What is your relationship with Jessica?", node2, node5);
            dialogue.AddOption("Does Jessica have any pets?", node2, node13);

            //Exit option for node 3
            dialogue.AddOption("That's alright, see you.", node3, null);

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
            dialogue.AddOption("Thank you for your time.", node8, null);

            //node 9 options
            dialogue.AddOption("What about her relatives?", node9, node10);
            dialogue.AddOption("What are her hobbies?", node9, node15);

            //node 10 options
            dialogue.AddOption("Why doesn't she like talking about them?", node10, node11);
            dialogue.AddOption("Have you met any of her relatives?", node10, node12);

            //node 11 exit options
            dialogue.AddOption("Interesting...", node11, null);

            //node 12 exit options
            dialogue.AddOption("Thank you for your time.", node12, null);

            //node 13 options
            dialogue.AddOption("What do you mean by that?", node13, node14);
            dialogue.AddOption("What are her hobbies?", node13, node15);

            //node 14 options & exit options
            dialogue.AddOption("Interesting...", node14, null);
            dialogue.AddOption("Does she have any hobbies?", node14, node15);

            //node 15 exit option
            dialogue.AddOption("Thankyou for your cooperation, it was very helpful.", node15, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("jessica_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void GabrielDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Claire";
            dialogue.clue = "Gabriel started supporting a charity for orphanages 6 years ago.";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes I do, why do you ask?");
            var node3 = new DialogueNode("No I don't sorry.");
            var node4 = new DialogueNode("Of course Alex. Fire away!");

            var node5 = new DialogueNode("We work in the neurology department at the hospital together. He's a very smart man, I look up to him a lot.");

            var node6 = new DialogueNode("We don't see him outside of work much but when we do talk, he often mentions the ShipStar charity.");
            var node7 = new DialogueNode("It seems to be a charity which supports local orphanages.");
            var node8 = new DialogueNode("No, I don't have the time or the money.");
            var node9 = new DialogueNode("I think it was around 6 years ago when he first started supporting it. I remember he took quite a long time off from work back then. I'm pretty sure he first mentioned it after he got back from his time off.");
            node9.isClue = true;
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
            dialogue.AddOption("Hello, do you know of Gabriel Johan?", node1, node2);

            //node 2 options
            dialogue.AddOption("I'm Alex from the ISC and would like to ask you a few questions regarding Gabriel if you don't mind.", node2, node4);
            dialogue.AddOption("How did you and Gabriel meet?", node2, node5);
            dialogue.AddOption("What type of person do you see Gabriel as?", node2, node15);

            //Exit option for node 3
            dialogue.AddOption("That's alright, see you.", node3, null);

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
            dialogue.AddOption("Yeah that's understandable. Thankyou for your time.", node8, null);

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
            dialogue.AddOption("Thankyou for answering all my questions. It was very helpful.", node14, null);

            //node 15 options
            dialogue.AddOption("Thankyou for your time.", node15, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("gabriel_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }


        public static void LandonDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Bart";
            dialogue.clue = "Landon is an innovative designer, but with ambition designs come great risks. Hopefully it was a one time mistake that he learned from?";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yeah I've known his for a few years now. What do you need to know?");
            var node3 = new DialogueNode("Yes I work there with my apprentice Landon.");

            var node4 = new DialogueNode("Well, he's a reliable worker but there was one repair we had trouble on.");
            var node5 = new DialogueNode("Landon is a very pleasant and enthusiastic worker to be around. He is always looking for new ways to solve issues customers bring in that are better than the way I already do things.");

            var node6 = new DialogueNode("Landon went off the books and gave the customer an advanced custom distributer he had made for their new car which he hoped to improve efficiency.");
            var node7 = new DialogueNode("Well I wouldn't hold it against him, he had good intentions.");

            var node8 = new DialogueNode("His custome design managed to completely ruin the customer's engine due to a minor miscalculation he made within his design. The customer was severely injured.");
            node8.isClue = true;

            var node9 = new DialogueNode("Definitely, he's a great individual that I'd hope to see achieve great things.");
            var node10 = new DialogueNode("Ah, so he signed up to go to Evandria did he? Well it's be worth letting him go if he was making great strides for humanity.");

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

            //node 1 options
            dialogue.AddOption("I hear you are familiar with Landon Ortega.", node1, node2);
            dialogue.AddOption("Do you own the local garage?", node1, node3);

            //node 2 options
            dialogue.AddOption("Have you ever had any issues with Landon?", node2, node4);
            dialogue.AddOption("Do you enjoy working with Landon?", node2, node5);

            //node 3 options
            dialogue.AddOption("Have you ever had any issues with Landon?", node3, node4);
            dialogue.AddOption("Do you enjoy working with Landon?", node3, node5);

            //node 4 options
            dialogue.AddOption("What went wrong?", node4, node6);
            dialogue.AddOption("That's unfortunate, I had high hopes for him.", node4, node7);

            //node 5 options
            dialogue.AddOption("So you would vouch for his good nature?", node5, node9);
            dialogue.AddOption("I guess you would be sad to see him go then?", node5, node10);

            //node 6 options
            dialogue.AddOption("I guess it's safe to assume it didn't work as intended.", node6, node8);

            //node 7 exit option
            dialogue.AddOption("Thanks for your help Bart!", node7, null);

            //node 8 exit option
            dialogue.AddOption("Thanks for your help Bart!", node8, null);

            //node 9 exit option
            dialogue.AddOption("Thanks for your help Bart!", node9, null);

            //node 10 exit option
            dialogue.AddOption("Thanks for your help Bart!", node10, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("landon_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void SaraDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Paula";
            dialogue.clue = "There’s an ongoing custody battle between Sara and her husband.";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Oh, yes! I've been her neighbour for almost 5 years now.");
            var node3 = new DialogueNode("My neighbour, Sara used to work there actually.");

            var node4 = new DialogueNode("Tommy and Lara! They are two energetic young children and they love their mother so much. It's a shame that their father is no longer around.");
            var node5 = new DialogueNode("She's a hard working lady! I remember during her time as a teacher she received multiple awards for being such an inspiring woman!");

            var node6 = new DialogueNode("I guess he just found it too difficult to live with Sara. There have been rumours around the neighbourhood that there were cases of domestic violence.");
            var node7 = new DialogueNode("They seem to be coping well, although I think there's a bigger issue at hand.");

            var node8 = new DialogueNode("You didn't hear this from me, but apparently there's a custody battle going on between the parents. There's been multiple incidents of Sara neglecting her children.");
            node8.isClue = true;

            var node9 = new DialogueNode("Actually, she helped me organise a large book-a-thon, where kids around the neighbourhood were able to get free books.");
            var node10 = new DialogueNode("Personally, I just think her hands became way too full handling Tommy and Lara. There's only so much a strong woman can handle before it becomes too much.");

            var node11 = new DialogueNode("Oh, nothing really. Sara's been such a good person to me, it'd be rude of me to gossip about her.");

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

            //node 1 options
            dialogue.AddOption("Do you know of Sara Van Haver?", node1, node2);
            dialogue.AddOption("Hi, do you know of Oak Stark Primary School?", node1, node3);

            //node 2 options
            dialogue.AddOption("I hear that Sara has two children.", node2, node4);
            dialogue.AddOption("What kind of person is Sara?", node2, node5);

            //node 3 optiona
            dialogue.AddOption("I hear that Sara has two children.", node3, node4);
            dialogue.AddOption("What kind of person is Sara?", node3, node5);

            //node 4 options
            dialogue.AddOption("What ever happened to their father?", node4, node6);
            dialogue.AddOption("Do you know how their children feel about the split between Sara and her Husband?", node4, node7);

            //node 5 options
            dialogue.AddOption("Awards you say? Have you personally worked with Sara before?", node5, node9);
            dialogue.AddOption("Do you have any idea why she stopped working as a teacher?", node5, node10);

            //node 6 exit option
            dialogue.AddOption("Alright, Paul, thanks so much for your help.", node6, null);

            //node 7 options
            dialogue.AddOption("Bigger issue? What do you mean by that?", node7, node8);

            //node 8 exit option
            dialogue.AddOption("Alright, Paul, thanks so much for your help.", node8, null);

            //node 9 exit option
            dialogue.AddOption("Alright, Paul, thanks so much for your help.", node9, null);

            //node 10 options
            dialogue.AddOption("What did you mean by too much?", node10, node11);

            //node 11 exit option
            dialogue.AddOption("Alright, Paul, thanks so much for your help.", node11, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("sara_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void LouisDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Javier";
            dialogue.clue = "Louis’s ex-girlfriend was murdered, but he quickly started dating someone else shortly after – Did her death affect him?";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes of course I know him! I'm Javier, his sous chef at the main restaurant in the city!");
            var node3 = new DialogueNode("Yes I do, I'm Javier, his sous chef.");

            var node4 = new DialogueNode("Well he is very popular with the ladies. But it is kind of weird, he seems to move on from them pretty fast. I wouldn't be able to if it was me, I'd be devastated.");
            var node5 = new DialogueNode("I don't know if you've already heard or not but, his former girlfriend Miranda was recently murdered in a serial killing case.");
            var node6 = new DialogueNode("There has actually. Quite tragic really, I wouldn't be able to act the way he did if it was me. I'd be devastated.");
            var node7 = new DialogueNode("I saw Louis the day after the news broke out, he seemed fine as if nothing happened. It happened only about a month ago too, but Louis moved on pretty quickly and started dating someone else two weeks later.");
            node7.isClue = true;

            var node8 = new DialogueNode("I'm not too sure. Cooking really does seem like his life as well as women of course. I know he enjoys practising pocket knife tricks and showing it off, he always has it on him.");
            var node9 = new DialogueNode("No I don't think so, he's a chef! He knows how to handle his knives.");

            var node10 = new DialogueNode("Quite a while now! Louis and I go way back, I was there when he first opened his restaurant, it's probably been around 10 years now.");
            var node11 = new DialogueNode("He is a very busy man, he's always out doing interviews or filming for cooking shows. But when he does come in to the restaurant, the dishes he makes are superb.");

            var node12 = new DialogueNode("He is a very proud person and doesn't tolerate anything not up to his standards so he's not very nice to the newbies and criticizes them quite a bit. A lot of them end up leaving because they can't handle it, but the pay is really good.");

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

            //node 1 options
            dialogue.AddOption("Hello do you know a person called Louis Dubois?", node1, node2);
            dialogue.AddOption("I hear you work for the famous chef Louis Dubois.", node1, node3);

            //node 2 options
            dialogue.AddOption("How long have you been working there?", node2, node10);
            dialogue.AddOption("Do you know if Louis ever does anything that isn't work related?", node2, node8);
            dialogue.AddOption("The public seems to like Louis quite a lot. Do you have anything to say about his private life?", node2, node4);


            //node 3 options
            dialogue.AddOption("The public seems to like Louis quite a lot. Do you have anything to say about his private life?", node3, node4);
            dialogue.AddOption("Do you know if Louis ever does anything that isn't work related?", node3, node8);
            dialogue.AddOption("How long have you been working there?", node3, node10);

            //node 4 options
            dialogue.AddOption("How long have you been working there?", node4, node10);
            dialogue.AddOption("What do you mean by that?", node4, node5);
            dialogue.AddOption("What do the other workers think of him?", node4, node12);

            //node 5 options
            dialogue.AddOption("That sounds horrible, how did Louis take it?", node5, node7);

            //node 6 options
            dialogue.AddOption("What do you mean by that?", node6, node5);
            dialogue.AddOption("What do the other workers think of him?", node6, node12);

            //node 7 exit option
            dialogue.AddOption("Thanks for your help Javier. I'll make sure to come by the restaurant and have a meal.", node7, null);

            //node 8 options
            dialogue.AddOption("Isn't that dangerous?", node8, node9);
            dialogue.AddOption("Has anything strange been happening around him recently?", node8, node6);

            //node 9 exit option
            dialogue.AddOption("Thanks for your help Javier. I'll make sure to come by the restaurant and have a meal.", node9, null);

            //node 10 options
            dialogue.AddOption("Oh that's great! You must know him very well then. What can you tell me about him?", node10, node11);
            dialogue.AddOption("What do the other workers think of him?", node10, node12);

            //node 11 options
            dialogue.AddOption("Thanks for your help Javier. I'll make sure to come by the restaurant and have a meal.", node11, null);

            //node 12 options
            dialogue.AddOption("Thanks for your help Javier. I'll make sure to come by the restaurant and have a meal.", node12, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("louis_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void ThomasDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Gary";
            dialogue.clue = "Seems to be a workaholic. Is an aggressive boss and rarely understand the needs of those around him.";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Why yes, I live with him. Is there a problem?");
            var node3 = new DialogueNode("Sure thing!");

            var node4 = new DialogueNode("I moved in with him approximately 2 years ago after he posted an ad saying that he wanted a roommate.");
            var node5 = new DialogueNode("When he does come home early, he continues on with his work in his room. I often hear him holding online group calls and meetings with his coworkers and assistants.");
            var node6 = new DialogueNode("There have been times during those online group meetings where they have argued about their heavy work load. His subordinates have tried applying for leave but I've only ever hear him rejecting them saying there's still work to be done.");
            node6.isClue = true;

            var node7 = new DialogueNode("As he's a musician and composer, he frequently plays the piano during the weekends. He also immensely enjoys listening to recent hit music across all genres. He says it helps him keep his musical creativity in top-notch standard.");
            var node8 = new DialogueNode("He's never invited friends over, no. Whenever he does go to parties it is mainly to socialize with potential collaborators such as singers, producers or lyricists instead of going to have fun.");

            var node9 = new DialogueNode("He is a lot more charasmatic than he sounds. I think this is a result of him having to perform in front of others as a musician. He is interesting to talk to and especially captivating when he's performing.");
            var node10 = new DialogueNode("Oh yes! he is well known in the music industry, alot of producers and singers want to collaborate with him as he has made many hit songs. Everyone would've heard one of his hit songs one time or another.");

            var node11 = new DialogueNode("No, not really. He seems to be a hard worker and enjoys his job. He works hard to maintain his fame as a composer but he doesn't let the fame go to his head. He is a rather down to earth person.");
            var node12 = new DialogueNode("Not that I recall, he doesn't cause any trouble around the house. He is relatively clean and always does his share of the chores. Although, sometimes it is a little lonely around here as he is always focused on his work.");

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

            //node 1 options
            dialogue.AddOption("Excuse me, do you know Thomas Reid?", node1, node2);
            dialogue.AddOption("I'm from the ISC and would like to ask some things about Thomas. It'd be great if you could help!", node1, node3);

            //node 2 options
            dialogue.AddOption("Do you know whether Thomas has any hoppies he regularly enjoys?", node2, node7);
            dialogue.AddOption("Does he participate in any social events such as inviting friends over or parties?", node2, node8);
            dialogue.AddOption("How long have you known Thomas for?", node2, node4);

            //node 3 options
            dialogue.AddOption("Do you know whether Thomas has any hoppies he regularly enjoys?", node3, node7);
            dialogue.AddOption("Does he participate in any social events such as inviting friends over or parties?", node3, node8);
            dialogue.AddOption("How long have you known Thomas for?", node3, node4);

            //node 4 options
            dialogue.AddOption("What struck you the most about Thomas when you first met him?", node4, node9);
            dialogue.AddOption("What is he like at home?", node4, node5);

            //node 5 options
            dialogue.AddOption("Do you have an idea of what his coworkers and subordinates think of him?", node5, node6);
            dialogue.AddOption("Do you find anything out of the ordinary about Thomas?", node5, node11);

            //node 6 exit option
            dialogue.AddOption("That's all for now. Thank you for your help.", node6, null);

            //node 7 options
            dialogue.AddOption("What struck you the most about Thomas when you first met him?", node7, node9);
            dialogue.AddOption("Have you ever watched him perform or listen to his compositions?", node7, node10);

            //node 8 options
            dialogue.AddOption("Do you find anything out of the ordinary about Thomas?", node8, node11);
            dialogue.AddOption("Have you ever encountered any problems while living with him?", node8, node12);

            //node 9 exit options
            dialogue.AddOption("That's all for now. Thank you for your help.", node6, null);

            //node 10 options
            dialogue.AddOption("Have you ever encountered any problems while living with him?", node10, node12);

            //node 11 exit
            dialogue.AddOption("That's all for now. Thank you for your help.", node11, null);

            //node 12 exit
            dialogue.AddOption("That's all for now. Thank you for your help.", node12, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("thomas_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void ScottDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Jeffrey";
            dialogue.clue = "He works overnight sometimes supposedly, but it seems like he's hiding something...";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Sure thing!");
            var node3 = new DialogueNode("Umm, ok Mr.");

            var node4 = new DialogueNode("He's my hero! He's always worked so hard, yet always happy and cheerful and lightening up everyone's day. I don't get to see him a lot because of his work though.");
            var node5 = new DialogueNode("I don't rememeber much about my mom... She passed away 5 years ago, I was only 6 then.");
            var node6 = new DialogueNode("I don't know what to say, I'm 11, I go to school? I do the dishes and I like trains?");

            var node7 = new DialogueNode("Yes he does. He says he works overtime a lot and doesn't come home overnight sometimes. It's a bit weird when he comes home like he's had the time of his life.");
            var node8 = new DialogueNode("He doesn't talk too much about it, like it's something he kind of avoids. But from what he's told me, I think he loves that kind of stuff!");

            var node9 = new DialogueNode("I asked him that too, but he never really says much. I feel like he's hiding something, but I'm too afraid to ask.");
            node9.isClue = true;
            var node10 = new DialogueNode("He thinks that the small and under-appreciated things still matter, so I believe he's content with it.");

            var node11 = new DialogueNode("Hmm... I guess that she was always cheerful like my dad.");
            var node12 = new DialogueNode("She would say what I would say! He's the hapiest, most cheerful person in the world who works super hard!");

            var node13 = new DialogueNode("I don't actually know. My dad never told me.");

            var node14 = new DialogueNode("I think a better question is what doesn't he enjoy!");

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

            //node 1 options
            dialogue.AddOption("Hey there young man, my name is Alex from the ISC. Can I ask you some questions about your dad Scott?", node1, node2);
            dialogue.AddOption("My name is Alex, and I'm from the ISC. I have some questions for you kiddo.", node1, node3);

            //node 2 options
            dialogue.AddOption("Tell me a bit about your mother.", node2, node5);
            dialogue.AddOption("Tell me a bit about your father.", node2, node4);
            dialogue.AddOption("Tell me a bit about yourself", node2, node6);

            //node 3 options
            dialogue.AddOption("Tell me a bit about your mother.", node3, node5);
            dialogue.AddOption("Tell me a bit about your father.", node3, node4);
            dialogue.AddOption("Tell me a bit about yourself", node3, node6);

            //node 4 options
            dialogue.AddOption("He works as a cleaner, correct?", node4, node7);
            dialogue.AddOption("He studied for a Diploma in Arts. Would you say it's one of his passions?", node4, node8);

            //node 5 options
            dialogue.AddOption("Are there any things that might stick out in your mind?", node5, node11);
            dialogue.AddOption("How do you think she would describe your father?", node5, node12);

            //node 6 options
            dialogue.AddOption("Tell me a bit about your father.", node6, node4);
            dialogue.AddOption("Tell me a bit about your mother.", node6, node5);

            //node 7 options
            dialogue.AddOption("Why would he seem so happy after work?", node7, node9);
            dialogue.AddOption("Do you think he enjoys his job?", node7, node10);

            //node 8 exit option
            dialogue.AddOption("Ok, thanks for answering my questions kiddo.", node8, null);

            //node 9 exit options
            dialogue.AddOption("Ok, thanks for answering my questions kiddo.", node9, null);

            //node 10 options
            dialogue.AddOption("What else do you think he'd enjoy or be passionate about?", node10, node14);
            dialogue.AddOption("He studied for a Diploma in Arts. Would you say it’s one of his passions?", node10, node8);

            //node 11 options
            dialogue.AddOption("How did she pass away?", node11, node13);
            dialogue.AddOption("How do you think she would describe your father?", node11, node12);

            //node 12 options
            dialogue.AddOption("Ok, thanks for answering my questions kiddo.", node12, null);

            //node 13 options
            dialogue.AddOption("Ok, thanks for answering my questions kiddo.", node13, null);

            //node 14 options
            dialogue.AddOption("Ok, thanks for answering my questions kiddo.", node14, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("scott_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void FrancisDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Sarah";
            dialogue.clue = "Francis is working on a side-project that could remove debt. Is he using this for sinister purposes?";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yeah he's a long-time colleague of mine.");
            var node3 = new DialogueNode("Ok sure thing.");

            var node4 = new DialogueNode("He's a brilliant developer, probably the most skilled I've ever seen. He does have a tendency to not show up and not do anything all day.");
            var node5 = new DialogueNode("I know he plays a lot of computer games, he also said he spends a lot of time on his side projects.");

            var node6 = new DialogueNode("I think he just doesn't care, maybe our company doesn't align well with what he wasnt to do with his skills.");
            var node7 = new DialogueNode("He's quite introverted, it often takes a while for people to get to know him well enough. I know he's a sweet guy who keeps to himself but always thinks of his friends.");

            var node8 = new DialogueNode("Francis has always had strong opinions on capitalism, he hates how large corporations have too much power over people, especially through debt.");
            var node9 = new DialogueNode("Surprisingly, despite being lazy, he always manages to keep on top of all his deadlines. It's quite motivating actually.");

            var node10 = new DialogueNode("There is one to do with debt, personal loan, getting rid of those sorts of things. He's not a finance person but a person with his skills could produce something that could make a big difference.");
            node10.isClue = true;

            var node11 = new DialogueNode("Aside from the usual student loan, I really don't think he has any big debts? He's very good at saving money, actually.");

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

            //node 1 options
            dialogue.AddOption("Hey, I was wondering if you knew a person named Francis Smith?", node1, node2);
            dialogue.AddOption("I'm from teh ISC and was wondering if you could answer some questions about Francis Smith?", node1, node3);

            //node 2 options
            dialogue.AddOption("What do you think of Francis at work?", node2, node4);
            dialogue.AddOption("What does Francis do in his spare time?", node2, node5);

            //node 3 options
            dialogue.AddOption("What do you think of Francis at work?", node3, node4);
            dialogue.AddOption("What does Francis do in his spare time?", node3, node5);

            //node 4 options
            dialogue.AddOption("Why doesn't he work?", node4, node6);
            dialogue.AddOption("What's Francis like as a person?", node4, node7);

            //node 5 options
            dialogue.AddOption("Could you tell me more about his side projects?", node5, node10);

            //node 6 options
            dialogue.AddOption("What specifically doesn't align well?", node6, node8);
            dialogue.AddOption("I've heard he's quite lazy. Does this affect the quality of his work?", node6, node9);

            //node 7 exit options
            dialogue.AddOption("Alright, thank you for your co-operation.", node7, null);

            //node 8 options
            dialogue.AddOption("Do you know if Francis has any outstanding debts?", node8, node11);

            //node 9 exit options
            dialogue.AddOption("Alright, thank you for your co-operation.", node9, null);

            //node 10 exit options
            dialogue.AddOption("Alright, thank you for your co-operation.", node10, null);

            //node 11 exit options
            dialogue.AddOption("Alright, thank you for your co-operation.", node11, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("francis_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void TaraDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Felicity";
            dialogue.clue = "Tara was at a charity event on 11/11/2048 at 10am";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("I might, who are you?!");
            var node3 = new DialogueNode("I might be able to help you. What do you need?");

            var node4 = new DialogueNode("Ha, she's too good looking and rich for you. Who are you anyway? And what do you want with Tara?");
            var node5 = new DialogueNode("I only just met Tara through a mutual friend at a charity event last wekk. We were participating in a fundraiser.");

            var node6 = new DialogueNode("Well she's a Williams. You know them right? Wealthiest family in the city. They're always flaunting their wealth and like to spend big. Tara's no different. What's ironic is no amount of money can save health or get them out of this polluted planet.");
            var node7 = new DialogueNode("She's a Williams, you should already know what she's like. Wealthy, popular and basically has the world at ehr hand. What's surprising is the amount of charity work she does.");

            var node8 = new DialogueNode("Look around you, this place is in shambles. Everyone is sick or diseased. You can't even get a nutritious meal nowadays. I've already applied for Evandria but I'm still waiting to hear back from them.");
            var node9 = new DialogueNode("Do you mean romantically, or with the mob? Either way, I wouldn't know. I only did just meet her last week.");

            var node10 = new DialogueNode("Well it was raising funds for all the orphan children in the city. Tara seemed like she wanted to help those poor homeless kids.");
            var node11 = new DialogueNode("We just spent a day with the orphans of the city and raised funds for them. One of the kids from the shelter Tom was there, and Tara was absolutely in love with him. Here’s a photo of the event.");
            node11.isClue = true;

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

            //node 1 options
            dialogue.AddOption("Excuse me Madam, do you know a Miss Tara Williams?", node1, node2);
            dialogue.AddOption("I'm a special investigatior on a mission to find information on Tara Willaims. Could you help me?", node1, node3);

            //node 2 options
            dialogue.AddOption("Tell me what you know about Tara Williams.", node2, node4);
            dialogue.AddOption("How do you know Tara?", node2, node5);

            //node 3 options
            dialogue.AddOption("Tell me what you know about Tara Williams.", node3, node4);
            dialogue.AddOption("How do you know Tara?", node3, node5);

            //node 4 options
            dialogue.AddOption("How would you describe Tara?", node4, node6);
            dialogue.AddOption("What kind of impression did you get when you met her?", node4, node7);

            //node 5 options
            dialogue.AddOption("Tell me more about this fundraiser?", node5, node10);
            dialogue.AddOption("What did she do at this fundraiser?", node5, node11);

            //node 6 options
            dialogue.AddOption("What do you mean?", node6, node8);
            dialogue.AddOption("Is she involved with anyone?", node6, node9);

            //node 7 exit options
            dialogue.AddOption("Alright, thank you for your help!", node7, null);

            //node 8 options
            dialogue.AddOption("Alright, thank you for your help!", node8, null);

            //node 9 options
            dialogue.AddOption("Alright, thank you for your help!", node9, null);

            //node 10 options
            dialogue.AddOption("Alright, thank you for your help!", node10, null);

            //node 11 options
            dialogue.AddOption("Alright, thank you for your help!", node11, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("tara_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void AsunaDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "Kirito";
            dialogue.clue = "Asuna had an abusive stepmother, she gained anger management issues from this.";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes. It just so happens that I am her boyfriend!");
            var node3 = new DialogueNode("Sure! Since it’s both for her sake and your sake, I would be glad to.");

            var node4 = new DialogueNode("Well, she is very creative, and we love to build small things together such as Lego sets, or even plastic models!");
            var node5 = new DialogueNode("She doesn’t talk too much about her family to me, but I do know she has a younger sister, and moved out her parent’s house as soon as she left High School.");

            var node6 = new DialogueNode("Hmm… I think a little over 2 years right about now. Only recently has she started opening up to me. But I’m a patient man. Everyone has their own pace in getting to know someone else, and I know deep down she’s a good girl.");
            var node7 = new DialogueNode("I know she’s got a decent paying job, but doesn’t seem to spend a lot of her money on luxuries herself. So I pamper her instead, because she doesn’t do it herself!");

            var node8 = new DialogueNode("I’m not sure if I should say this… But from the little she has told me about her family, she didn’t necessarily have a very good relationship with her stepmother…");
            var node9 = new DialogueNode("Not that I know of, but I do know she has some secrets that she won’t tell me. But I won’t force them out of her either. Everyone has their own little secrets which they keep to themselves, and I understand that.");

            var node10 = new DialogueNode("Well, I’ve met her stepmother once, and it was not a pleasant experience. I could tell that she was a very “controlling” woman, and that’s where I made the connection that growing up with that kind of stepmother could have easily been the cause of Asuna’s current anger issues.");
            node10.isClue = true;

            var node11 = new DialogueNode("Not too sure. Saving it for a house? Either way, I am happy with the way we are now, and don’t mind spoiling her a little bit here and there. I can tell she really appreciates it, but it does seem like she’s a bit too frugal at times.");

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

            //node 1 options
            dialogue.AddOption("Hello, do you kow a person called Asuna Touyama?", node1, node2);
            dialogue.AddOption("Would you mind if I asked you some questions about your girlfriend Asuna?", node1, node3);

            //node 2 options
            dialogue.AddOption("What sort of hobbies or activities does she like to do?", node2, node4);
            dialogue.AddOption("Do you know if there is anything going on with her family at the moment?", node2, node5);

            //node 3 options
            dialogue.AddOption("What sort of hobbies or activities does she like to do?", node3, node4);
            dialogue.AddOption("Do you know if there is anything going on with her family at the moment?", node3, node5);

            //node 4 options
            dialogue.AddOption("How long have you been together with her?", node4, node6);
            dialogue.AddOption("Would you happen to know anything about her work?", node4, node7);

            //node 5 options
            dialogue.AddOption("Do you know why she moved out so quickly?", node5, node8);
            dialogue.AddOption("Do you think she has anything to hide?", node5, node9);

            //node 6 exit options
            dialogue.AddOption("Thanks for your help Kirito.", node6, null);

            //node 7 options
            dialogue.AddOption("Thanks for your help Kirito.", node7, null);

            //node 8 options
            dialogue.AddOption("I see. I was just wondering if you would happen to know anything about her childhood?", node8, node10);

            //node 9 options
            dialogue.AddOption("Would you happen to know anything about her work?", node9, node7);
            dialogue.AddOption("Do you know what she does with her money?", node9, node11);

            //node 10 exit options
            dialogue.AddOption("Thanks for your help Kirito.", node10, null);

            //node 11 exit options
            dialogue.AddOption("Thanks for your help Kirito.", node11, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("asuna_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }

        public static void AnzioDialogue()
        {
            Dialogue dialogue = new Dialogue();

            dialogue.npcName = "James";
            dialogue.clue = "Anzio values his family greatly";

            var node1 = new DialogueNode("Hello!");
            var node2 = new DialogueNode("Yes, I’m his colleague. Why do you ask?");
            var node3 = new DialogueNode("Ah I see. No I don’t mind at all, ask away!");

            var node4 = new DialogueNode("Between you and me, even though we’ve been working together for three years now, I still can’t stand that prick. His arrogant and condescending personality is a pain to work with.");
            var node5 = new DialogueNode("Every day we would receive new software builds from the development team to test for bugs and errors. The job itself is tedious and boring, but we do get to see the latest secret projects that the company is working on. I guess you can consider that a perk of our job.");
            var node6 = new DialogueNode("Anzio himself is single right now, he mentioned before that he thinks marriage is nothing but trouble. But everybody in the department knows that he really loves his parents.");

            var node7 = new DialogueNode("Not really, he works just as hard as any other employees. He arrives on time to work every day, never misses the deadline, and stays for over hour if he needs to.");

            var node8 = new DialogueNode("I’ve heard that he recently moved in to a massive house. I honestly wonder how he managed that, seeing that we’re doing the same job and we make so little money.");

            var node9 = new DialogueNode("He takes great care of his parents like no other. This one time he got a phone call from the hospital saying that his mother hurt herself by falling from the staircase, Anzio rushed to the hospital immediately without even telling his supervisor!");
            node9.isClue = true;

            var node10 = new DialogueNode("Well I guess that may be true. I don't find our job particularly exciting, but maybe he does. I guess the pay won't matter to him too much then.");

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

            //node 1 options
            dialogue.AddOption("Hi there, does the name Anzio Romano mean anything to you?", node1, node2);
            dialogue.AddOption("I work for the ISC, would you mind if I ask you a few questions regarding Anzio?", node1, node3);

            //node 2 options
            dialogue.AddOption("What do you think of Anzio?", node2, node4);
            dialogue.AddOption("Can you describe to me what you and Anzio do on a daily basis?", node2, node5);
            dialogue.AddOption("Can you tell me a bit about his family?", node2, node6);

            //node 3 options
            dialogue.AddOption("What do you think of Anzio?", node3, node4);
            dialogue.AddOption("Can you describe to me what you and Anzio do on a daily basis?", node3, node5);
            dialogue.AddOption("Can you tell me a bit about his family?", node3, node6);

            //node 4 options
            dialogue.AddOption("Has he caused any trouble in the workplace?", node4, node7);
            dialogue.AddOption("Can you describe to me what you and Anzio do on a daily basis?", node4, node5);

            //node 5 options
            dialogue.AddOption("Can you tell me a bit about his family?", node5, node6);
            dialogue.AddOption("Is there anything special or strange that you noticed about Anzio recently?", node5, node8);

            //node 6 options
            dialogue.AddOption("Oh? Could you elaborate on that?", node6, node9);

            //node 7 exit options
            dialogue.AddOption("Thank you for you time James.", node7, null);

            //node 8 options
            dialogue.AddOption("Interesting, but is it possible that he simply comes from a wealthy family?", node8, node10);

            //node 9 exit options
            dialogue.AddOption("Thank you for you time James.", node9, null);

            //node 10 exit options
            dialogue.AddOption("Thank you for you time James.", node10, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("anzio_npc_dialogue.xml");

            serz.Serialize(writer, dialogue);
        }
    }
}
