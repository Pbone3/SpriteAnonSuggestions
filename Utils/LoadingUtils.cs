using ReLogic.Content;
using System;
using System.Threading;
using Terraria;

namespace SpriteAnonSuggestions.Utils
{
    public static class LoadingUtils
    {
        // InvokeOnMainThread by absoluteAquarian, used with permission
        public static void InvokeOnMainThread(Action action)
        {
            if (!AssetRepository.IsMainThread)
            {
                ManualResetEvent evt = new(false);

                Main.QueueMainThreadAction(() => {
                    action();
                    evt.Set();
                });

                evt.WaitOne();
            }
            else
                action();
        }
    }
}
