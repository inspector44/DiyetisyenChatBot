using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.Helper
{
    public class MyHelper
    {
        public IMessageActivity CreateCard(Activity activity, 
                                           IMessageActivity reply,  
                                           string button1, 
                                           string button2)
        {
            ReceiptCard AnswersCard = new ReceiptCard()
            {
                
                Buttons = new List<CardAction>()
                                    {
                                        new CardAction()
                                        {
                                              Title = button1,
                                              Type = ActionTypes.MessageBack,
                                              Text = activity.Text
                                        },
                                        new CardAction()
                                        {
                                              Title = button2,
                                              Type = ActionTypes.MessageBack,
                                              Text = activity.Text
                                        }

                                    },

            };
            Attachment atc = AnswersCard.ToAttachment();
            reply.Attachments.Add(atc);
            return reply;
        }


        
    }
}