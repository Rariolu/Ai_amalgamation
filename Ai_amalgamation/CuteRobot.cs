using AIMLbot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_amalgamation
{
    public class CuteRobot
    {
        const string UserId = "User";
        private Bot AimlBot;
        private User myUser;
        bool initialised = false;
        public CuteRobot(string settingsFile)
        {
            if (Bot.LoadFromFile(settingsFile,out AimlBot))
            {
                myUser = new User(UserId, AimlBot);
                initialised = true;
            }
        }
        // Given an input string, finds a response using AIMLbot lib
        public String GetOutput(String input)
        {
            if (initialised)
            {
                Request r = new Request(input, myUser, AimlBot);
                Result res = AimlBot.Chat(r);
                return (res.Output);
            }
            return "The bot failed to initialise, but for some dynamic speech I will give you a random number: " + (new Random().Next());
        }
    }
}