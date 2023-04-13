using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sean
{
    public class PlayerControls : MonoBehaviour
    {
        public PlayerControls input = null;

        internal float RetrieveMoveInput
        {
            get; private set;
        }

        private bool retrieveJumpInput;

        internal bool GetRetrieveJumpInput()
        {
            return retrieveJumpInput;
        }

        private void SetRetrieveJumpInput(bool value)
        {
            retrieveJumpInput = value;
        }

        internal bool RetrieveJumpInput => throw new NotImplementedException();
    }

}

       
             
    

