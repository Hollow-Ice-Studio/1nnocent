using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public interface IGameSystem
    {
        GameController GameController { get; set; }
        void PhysicsRoutine();
        void LogicRoutine();
    }
}

