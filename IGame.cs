using System.Collections.Generic;

namespace MinimaxCS
{
    public interface IGame<TData>
    {
        public float Evaluate(TData data);

        public List<TData> GetPossibleMoves(TData data);
    }
}