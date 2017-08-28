using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System.Linq;
using System.Collections.Generic;
using DiyetisyenimBot.EF;
using DiyetisyenimBot.Controllers;
namespace DiyetisyenimBot.Dialogs
{

    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var reply = context.MakeMessage();
            var activity = await result as Activity;
            activity.AsTypingActivity();

            context.Wait(MessageReceivedAsync);
        }
    }
}