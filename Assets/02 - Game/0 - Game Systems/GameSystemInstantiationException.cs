using System;
using UnityEngine;

namespace innocent
{
    public class GameSystemInstantiationException : Exception
    {
        public GameSystemInstantiationException(string GameSystemName)
            : base($"Falha ao instanciar o gamesystem: {GameSystemName}")
        {}

    }
}

