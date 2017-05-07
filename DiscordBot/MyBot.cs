using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
     class MyBot
    {
        DiscordClient discordClient;
        CommandService commands;
        Random rng;

        public MyBot()
        {
            rng = new Random();

            discordClient = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discordClient.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discordClient.GetService<CommandService>();

            RegisterHelloCommand();
            RegisterStickersCommand();
            RegisterGachaCommand();
            RegisterChooseCommand();

            discordClient.ExecuteAndWait(async () =>
            {
            await discordClient.Connect("MzA0OTcyNDI4ODcyNzc3NzM4.C_CjpQ.XpsyqoRNGdTleBICSD54PYggfAA", TokenType.Bot);
            });
        }

        private void RegisterChooseCommand()
        {
            commands.CreateCommand("choose")
                .Parameter("Choices", ParameterType.Required)
                  .Do(async (e) =>
                  {

                      
                      string choicesText = e.GetArg("Choices");
                      string[] choice = choicesText.Split(',');
                      int choosenIndex = rng.Next(choice.Length);
                      await e.Channel.SendMessage("Lelouch vi Britannia commands you! Take " + choice[choosenIndex]);
                   

                  });
        }

        private void RegisterGachaCommand()
        {
            string[] gachaCommands;
            gachaCommands = new string[]
            {
                "Don't be stupid.",
                "Do you want to die?",
                "The only ones who should roll, are those who are prepared to roll the gacha.",
                "Lelouch vi britannia commands you, roll the gacha!"
            };


            commands.CreateCommand("gacha")
                 .Do(async (e) =>
                 {
                     int randomIndex = rng.Next(gachaCommands.Length);
                     await e.Channel.SendMessage(gachaCommands[randomIndex]);
                 });
        }

        private void RegisterStickersCommand()
        {
            commands.CreateCommand("emo")
                 .Do(async (e) =>
                 {
                     await e.Channel.SendMessage("Here are the list of my known emotions : \n" +
                         "!emo ikan why\n" +
                         "!emo ikan roll\n" +
                         "!emo bebek\n" +
                         "!emo bengong\n" +
                         "!emo happy birthday\n" +
                         "!emo kok kesel\n" +
                         "!emo logic\n" +
                         "!emo objection\n" +
                         "!emo samlekom\n" +
                         "!emo thinking\n");
                 });

            commands.CreateCommand("emo ikan why")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("sticker/bola_ikan/ikan_why.png");
                });

            commands.CreateCommand("emo ikan roll")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("sticker/bola_ikan/ikan_roll.png");
                });

            commands.CreateCommand("emo logic")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("sticker/logic.jpg");
                });

            commands.CreateCommand("emo bebek")
               .Do(async (e) =>
               {
                   await e.Channel.SendFile("sticker/bebek.png");
               });

            commands.CreateCommand("emo bengong")
               .Do(async (e) =>
               {
                   await e.Channel.SendFile("sticker/bengong.jpg");
               });

            commands.CreateCommand("emo kok kesel")
              .Do(async (e) =>
              {
                  await e.Channel.SendFile("sticker/kok kesel.jpg");
              });

            commands.CreateCommand("emo happy birthday")
              .Do(async (e) =>
              {
                  await e.Channel.SendFile("sticker/happy birthday.jpg");
              });

            commands.CreateCommand("emo objection")
              .Do(async (e) =>
              {
                  await e.Channel.SendFile("sticker/objection.jpg");
              });

            commands.CreateCommand("emo samlekom")
                  .Do(async (e) =>
                  {
                      await e.Channel.SendFile("sticker/samlekom.jpg");
                  });

            commands.CreateCommand("emo thinking")
                  .Do(async (e) =>
                  {
                      await e.Channel.SendFile("sticker/thinking.png");
                  });
        }

        private void RegisterHelloCommand()
        {
            commands.CreateCommand("hello")
                 .Do(async (e) =>
                 {
                     await e.Channel.SendMessage("Give me water");
                 });
            
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

    }
}