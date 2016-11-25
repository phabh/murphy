using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;
using Murphy;
using Murphy.Models;

namespace 
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;
        private readonly IDictionary<string, object> _settings;
        private readonly BlockManager blockManager;

        public PlainTextMessageReceiver(IMessagingHubSender sender, IDictionary<string, object> settings)
        {
            _sender = sender;
            _settings = settings;
            blockManager = BlockManager.CreateBlockManager(_settings["jsonFile"].ToString());
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            var block = blockManager.GetBlock(message.Content.ToString());
            await blockManager.SendMessage(_sender, message.From, block);
        }
    }
}
