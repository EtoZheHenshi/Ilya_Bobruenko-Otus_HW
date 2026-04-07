using System.Collections.Generic;

namespace GameSubLogic
{
    public static class DecalLimiter
    {
        private const int MaxDecals = 20;
        private static readonly Queue<Decal> DecalQueue = new Queue<Decal>();

        public static void AddDecal(Decal decal)
        {
            if (DecalQueue.Count >= MaxDecals)
            {
                while (DecalQueue.Count >= MaxDecals)
                {
                    DecalQueue.Dequeue().DestroyDecal();
                }
            }
            
            DecalQueue.Enqueue(decal);
        }
    }
}