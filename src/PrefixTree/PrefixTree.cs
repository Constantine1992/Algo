using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Prefix
{
    public class PrefixTree
    {
        public int Dept { get; private set; }

        private PrefixNode _rootNode;

        public PrefixTree()
        {
            _rootNode = new PrefixNode();
        }

        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            var node = _rootNode;

            foreach (var symbol in word)
            {
                if (node._childrens.TryGetValue(symbol, out var children) == false)
                {
                    children = new PrefixNode();
                    node._childrens[symbol] = children;
                }

                node = children;
            }

            node.IsEndOfWord = true;
            SetDept(word.Length);
        }

        public bool Search(string word)
        {
            var lastNode = _rootNode.GetLastWordNode(word);

            return lastNode?.IsEndOfWord == true;
        }

        public bool StartsWith(string word)
        {
            var lastNode = _rootNode.GetLastWordNode(word);

            return lastNode is not null;
        }

        private void SetDept(int lenth)
        {
            Dept = Math.Max(Dept, lenth);
        }
    }
}