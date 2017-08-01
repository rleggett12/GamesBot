using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using Discord; // imports discord functionalities
using Discord.Commands; // imports discord commands
using Discord.WebSocket; //imports discord bot commands

namespace GamesBot
{
    class MyBot
    {
        DiscordSocketClient discord; // sets up the discord client
        CommandService commands;

        public MyBot()
        {
            discord = new DiscordSocketClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
                x.AppName = "Games Bot";
            }); //log in functionalities

            Discord.usingCommands(x =>
            {
                x.PrefixChar = "!";
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            }); // allows users to execute bot command by mentioning the bot or using ! before the command

            commands = Discord.getService<CommandService>();

            commands.CreateCommand("hey")
                    .Do(async (e) =>
            {
                await e.channel.SendMessage("Hi!");
            }); // creates the first command that will print "Hi!" when the hey command is executed by a user

            Discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzQxODUxODQ5MTQ3NTQ3NjUw.DGHQ4A.VAt4J9ogBFt2DTGNVrEAI2PaVtI");
            }); // connects the bot to disocrd using the specific token
        }

        private void Log(object sender, DiscordSocketClient#Log e)
        {
            Console.WriteLine(e.Message);// outputs messages at different statuses for the log
        }
    }
}
