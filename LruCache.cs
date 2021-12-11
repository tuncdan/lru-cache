using System.Collections.Generic;

namespace LruCache
{
    public class LruCache
    {
        private readonly int m_capacity;
        private readonly LinkedList<CacheItem> m_nodes;

        public LruCache(int capacity)
        {
            m_capacity = capacity;
            m_nodes = new LinkedList<CacheItem>();
        }

        public int Get(int key)
        {
            var node = Search(key);

            if (node == null)
                return -1;

            PromoteNode(node);
            return node.Value.m_value;
        }

        public LinkedListNode<CacheItem> Search(int key)
        {
            if (m_nodes.Count == 0)
                return null;

            LinkedListNode<CacheItem> listNode = m_nodes.Last;

            do
            {
                if (listNode.Value.m_key == key)
                    return listNode;

                listNode = listNode.Previous;

            } while (listNode != null);

            return null;
        }

        private void PromoteNode(LinkedListNode<CacheItem> listNode)
        {
            if (listNode == m_nodes.Last)
                return;

            m_nodes.Remove(listNode);
            m_nodes.AddLast(listNode);
        }

        private void Add(int key, int value)
        {
            m_nodes.AddLast(new LinkedListNode<CacheItem>(new CacheItem
            {
                m_key = key,
                m_value = value,
            }));

            if (m_nodes.Count > m_capacity)
                m_nodes.RemoveFirst();
        }

        public void Put(int key, int value)
        {
            var node = Search(key);

            if (node != null)
            {
                node.Value.m_value = value;
                PromoteNode(node);
            }
            else
                Add(key, value);
        }
    }
}
