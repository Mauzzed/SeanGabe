using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sean
{
    public class PlayerControls : ScriptableObject
    {
        public PlayerControls input = null;

        internal float RetrieveMoveInput()
        {
            throw new NotImplementedException();
        }

        internal bool RetrieveJumpInput()
        {
            throw new NotImplementedException();
        }
    }
}
