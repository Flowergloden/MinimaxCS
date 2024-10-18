using System;
using System.Collections.Generic;

namespace MinimaxCS
{
#nullable enable
    public class MinimaxNode<TData>: IComparable<MinimaxNode<TData>>
    {
        public MinimaxNode(TData data, MinimaxNode<TData>? parent)
        {
            Data = data;
            Parent = parent;
            Nodes = new List<MinimaxNode<TData>>();
        }

        public float Value { get; set; }
        public TData Data { get; }
        public MinimaxNode<TData>? Parent { get; }
        public List<MinimaxNode<TData>> Nodes { get; }

        public int CompareTo(MinimaxNode<TData>? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            return Value.CompareTo(other.Value);
        }
    }
#nullable disable
}