using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prefix
{
    internal sealed class PrefixNode
    {
        //public bool IsRoot { get; private set; }

        public bool IsEndOfWord { get; set; }

        public Dictionary<char, PrefixNode> _childrens = new Dictionary<char, PrefixNode>();

        public PrefixNode? GetLastWordNode(string word)
        {
            var node = this;

            foreach (var symbol in word)
            {
                if (node is null)
                {
                    return node;
                }

                node._childrens.TryGetValue(symbol, out node);
            }

            return node;
        }
    }
}