using System.Collections.Generic;

namespace FileAllocationTableTool.Layout
{
    class DirectoryTree
    {
        public delegate bool TraversalDataDelegate(DirectoryEntry data);
        public delegate bool TraversalNodeDelegate(DirectoryTree node);

        private readonly DirectoryEntry _data;
        private readonly DirectoryTree _parent;
        private readonly int _level;
        private readonly List<DirectoryTree> _children;

        public DirectoryTree(DirectoryEntry data)
        {
            _data = data;
            _children = new List<DirectoryTree>();
            _level = 0;
        }

        public DirectoryTree(DirectoryEntry data, DirectoryTree parent) : this(data)
        {
            _parent = parent;
            _level = _parent != null ? _parent.Level + 1 : 0;
        }

        public int Level { get { return _level; } }
        public int Count { get { return _children.Count; } }
        public bool IsRoot { get { return _parent == null; } }
        public bool IsLeaf { get { return _children.Count == 0; } }
        public DirectoryEntry Data { get { return _data; } }
        public DirectoryTree Parent { get { return _parent; } }

        public DirectoryTree this[int key]
        {
            get
            {
                return _children[key];
            }
        }

        public void Clear()
        {
            _children.Clear();
        }

        public DirectoryTree AddChild(DirectoryEntry value)
        {
            DirectoryTree node = new DirectoryTree(value, this);
            _children.Add(node);

            return node;
        }

        public bool HasChild(DirectoryEntry data)
        {
            return FindInChildren(data) != null;
        }

        public DirectoryTree FindInChildren(DirectoryEntry data)
        {
            int i = 0, l = Count;
            for (; i < l; ++i)
            {
                DirectoryTree child = _children[i];
                if (child.Data.Equals(data)) return child;
            }

            return null;
        }

        public bool RemoveChild(DirectoryTree node)
        {
            return _children.Remove(node);
        }

        public void Traverse(TraversalDataDelegate handler)
        {
            if (handler(_data))
            {
                int i = 0, l = Count;
                for (; i < l; ++i) _children[i].Traverse(handler);
            }
        }

        public void Traverse(TraversalNodeDelegate handler)
        {
            if (handler(this))
            {
                int i = 0, l = Count;
                for (; i < l; ++i) _children[i].Traverse(handler);
            }
        }
    }
}
