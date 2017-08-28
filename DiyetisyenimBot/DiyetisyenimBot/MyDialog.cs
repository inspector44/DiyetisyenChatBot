using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

namespace DiyetisyenimBot
{
    [Serializable]
    public class MyDialog : IDialog<object>
    {
        private const string ButtonYes = "Evet";

        private const string ButtonNo = "Hayır";
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }
        private void ShowOptions(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { ButtonYes, ButtonNo }, "Seçer misiniz?", "Not a valid option", 3);
        }

        

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case ButtonYes:
                        
                        //context.Call(new FlightsDialog(), this.ResumeAfterOptionDialog);
                        break;

                    case ButtonNo:
                        //context.Call(new HotelsDialog(), this.ResumeAfterOptionDialog);
                        break;
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var reply = context.MakeMessage();
            var activity = await result as Activity;
            
            activity.AsTypingActivity();

            if (activity.Text.ToLower().Contains("help") || activity.Text.ToLower().Contains("support") || activity.Text.ToLower().Contains("problem"))
            {
                //await context.Forward(new SupportDialog(), this.ResumeAfterSupportDialog, message, CancellationToken.None);
            }
            else
            {
                this.ShowOptions(context);
            }

        }

        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }


    }
}