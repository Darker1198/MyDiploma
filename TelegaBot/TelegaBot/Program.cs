using Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace TelegaBot
{
    class Program
    {
      static  TelegramBotClient botClient = new TelegramBotClient("768380479:AAFOoAVP4sv1-hXqoeoyBjvpFHrfHpNftoQ");
     public  static   List<ReadyPlan> plans = new List<ReadyPlan>();

        static void Main(string[] args)
        {
           
            Wait();
            int num = 0;
            TimerCallback TC = new TimerCallback(OnTimer);
            long diference = 0;

            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            diference = s + (m%5) * 60;
            diference = 300 - diference % 300;

            plans = PlanAdministrator.LoadAll();
            botClient.OnMessage += HandleMessage;
            botClient.StartReceiving();
            Timer timer = new Timer(TC, num, diference * 1000, 300*1000);
            /*
             var me = botClient.GetMeAsync().Result;
             Console.WriteLine(me.Username);         
             */

            Console.WriteLine("Compete");
            Console.ReadKey();
        }
        static void HandleMessage(object sender, MessageEventArgs messageEventArgs)
        {
            string Message = messageEventArgs.Message.Text;
            long TelegaId = messageEventArgs.Message.From.Id;

            if (Message == "/start")
            {
                botClient.SendTextMessageAsync(TelegaId, TelegaId.ToString());
            }
            else
            {
                if (plans.Where(x => x.Plan.Identificator == TelegaId.ToString()).ToList().Count != 1)
                {
                    botClient.SendTextMessageAsync(TelegaId, $"Ви не зареєстровані!!!");
                }
                else
                {
                    Plan bufer = new Plan();
                    bufer = plans.Where(x => x.Plan.Identificator == TelegaId.ToString()).First().Plan;
                    ReadyPlan ready = plans.Where(x => x.Plan.Equals(bufer)).First();
                    string baf = bufer.Destination;

                    botClient.SendTextMessageAsync(baf, $"{bufer.Name}{Environment.NewLine}{bufer.Events[ready.Last].Name}{Environment.NewLine}{Message}");
                }
                Console.WriteLine(TelegaId + "Complete");
            }
        }
    

        static void OnTimer(object obj)
        {
            Console.WriteLine(DateTime.Now);
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            int diference = 5;
             minute = minute + 5;
            if (minute >= 60 )
            {
                minute = minute % 60;
                hour++;
            }
            foreach (ReadyPlan a in plans)
            {
                if (a.Plan.Events[a.LastIndex].StartHour == hour
                    && a.Plan.Events[a.LastIndex].StartMinute == minute)
                {
                    ChatId chatId = new ChatId(int.Parse(a.Plan.Identificator));
                    string Message = $"{a.Plan.Events[a.LastIndex].Name} Через {diference} хвивлин.{Environment.NewLine}Тривалість {a.Plan.Events[a.LastIndex].Duration} хвилин";
                    botClient.SendTextMessageAsync(chatId, Message);
                    Console.WriteLine(a.Plan.Name + "  " + Message);

                    if(a.Plan.Events[a.LastIndex].NeedFeedback)
                    {
                        botClient.SendTextMessageAsync(chatId, $"Надайте доповідь!");
                    }
                    a.Next();
                }
            }
        }

        static async void Wait()
        {
           await Task.Run(()=> TCPPlanServer.Waiting());
        }
    }
}
