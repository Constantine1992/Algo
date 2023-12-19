using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prefix.LeetCode
{
    public class Trie
    {
        public bool IsEndWord { get; private set; }

        private Dictionary<char, Trie> _childrens = new Dictionary<char, Trie>();

        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            var node = this;

            foreach (var symbol in word)
            {
                if (node._childrens.TryGetValue(symbol, out var children) == false)
                {
                    children = new Trie();
                    node._childrens[symbol] = children;
                }

                node = children;
            }

            node.IsEndWord = true;
        }

        public bool Search(string word)
        {
            var lastNode = GetLastChildNodeByValue(word);

            return lastNode?.IsEndWord == true;
        }

        public bool StartsWith(string prefix)
        {
            var existLastNode = GetLastChildNodeByValue(prefix) is not null;

            return existLastNode;
        }
#nullable enable
        private Trie? GetLastChildNodeByValue(string prefix)
        {
            var node = this;

            foreach (var symbol in prefix)
            {
                node._childrens.TryGetValue(symbol, out node);

                if (node is null)
                {
                    return node;
                }
            }

            return node;
        }
    }

    public class Tre
    {
        private readonly HashSet<string> _values = new();
        private readonly HashSet<string> _keys = new();

        public void Insert(string word)
        {
            _values.Add(word);

            for (var i = word.Length; i > 0; i--)
            {
                var s = word[..i];
                if (!_keys.Contains(word[..i]))
                {
                    _keys.Add(word[..i]);
                }
                else
                {
                    // all prev string are in KEYS
                    break;
                }
            }
        }

        public bool Search(string word)
        {
            return _values.Contains(word);
        }

        public bool StartsWith(string prefix)
        {
            return _keys.Contains(prefix);
        }
    }
}
