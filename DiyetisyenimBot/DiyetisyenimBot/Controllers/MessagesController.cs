using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using System.Web.Http.Description;
using System.Diagnostics;
using DiyetisyenimBot.Controllers;
using Microsoft.ServiceBus.Messaging;

namespace DiyetisyenimBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static EventHubClient ConnectEventHub()
        {

            string EventCnnctString = "";
                string EventHubName = "";
                var ehClient = EventHubClient.CreateFromConnectionString(EventCnnctString, EventHubName);
            return ehClient;
        }

        [ResponseType(typeof(void))]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectEventHub();
                await Conversation.SendAsync(activity, MakeBuildForm); 
            }

            else
            {
                HandleSystemMessage(activity);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
        

        internal static IDialog<Models.MessageModel> MakeBuildForm()
        {
            
            return Chain.From(() => FormDialog.FromForm(Models.MessageModel.BuildForm));
        }

        private Activity HandleSystemMessage(Activity message)
        {
            
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
            
        }

    }
}