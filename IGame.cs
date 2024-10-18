using System.Collections.Generic;

namespace MinimaxCS
{
    public interface IGame<TData>
    {
        public float Evaluate(TData data);

        public TData[] GetPossibleMoves(TData data);

        public bool IsEnd(TData data);
    }
}