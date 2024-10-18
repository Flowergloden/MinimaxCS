using System;
using System.Linq;

namespace MinimaxCS
{
    public class MinimaxTree<TGame, TData> where TGame : IGame<TData>
    {
        public MinimaxTree(TGame game, TData data, int maxDepth, bool bMaximizing)
        {
            _game = game;
            _maxDepth = maxDepth;
            _bMaximizing = bMaximizing;
            _root = new MinimaxNode<TData>(data, null);
        }

        private readonly TGame _game;
        private readonly MinimaxNode<TData> _root;
        private readonly int _maxDepth;
        private readonly bool _bMaximizing;

        public TData Run()
        {
            InnerMinimax(_root, _maxDepth, _bMaximizing);

            return _bMaximizing ? _root.Nodes.Max().Data : _root.Nodes.Min().Data;
        }

        private void InnerMinimax(MinimaxNode<TData> node, int depth, bool bMaximizing)
        {
            if (depth <= 0 || _game.IsEnd(node.Data))
            {
                var res = _game.Evaluate(node.Data);
                node.Value = res;
                return;
            }

            foreach (var child in _game.GetPossibleMoves(node.Data).Select(move => new MinimaxNode<TData>(move, node)))
            {
                node.Nodes.Add(child);
                InnerMinimax(child, depth - 1, !bMaximizing);
            }

            node.Value = bMaximizing ? node.Nodes.Max(x => x.Value) : node.Nodes.Min(x => x.Value);
        }
    }
}