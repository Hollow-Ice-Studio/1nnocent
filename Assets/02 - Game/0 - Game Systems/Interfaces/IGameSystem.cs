using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onennocent
{
    public interface IGameSystem
    {
        GameController GameController { get; set; }
        void PhysicsRoutine();
        void LogicRoutine();
    }
}

