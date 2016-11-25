using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lime.Protocol;
using Lime.Protocol.Network;
using Murphy.Models;
using Newtonsoft.Json;

namespace Murphy
{
    public class BlockManager
    {
        private IDictionary<Guid, Block> _blocks;

        private BlockManager(IDictionary<Guid, Block> blocks)
        {
            _blocks = blocks;
        }

        public static BlockManager CreateBlockManager(string file)
        {
            var blockList = JsonConvert.DeserializeObject<List<Block>>(File.ReadAllText(file));

            return new BlockManager(blockList.ToDictionary(block => block.BlockId));
        }

        public async Task SendMessage(IMessageSenderChannel sender, Node to, Block block)
        {
            foreach (var document in block.Messages)
            {
                var message = new Message
                {
                    To = to,
                    Content = document
                };

                await sender.SendMessageAsync(message);
            }
        }

        public Block GetBlock(string answer)
        {
            var blockReturn = GetDefaultBlock();
            Guid guid;
            if (!Guid.TryParse(answer, out guid)) return blockReturn;
            if (_blocks.ContainsKey(guid))
            {
                blockReturn = _blocks[guid];
            }
            return blockReturn;
        }

        private Block GetDefaultBlock()
        {
            return new Block();
        }
    }
}