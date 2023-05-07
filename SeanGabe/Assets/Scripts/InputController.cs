using UnityEngine;
using UnityEngine.InputSystem;

namespace Sean
{
    /// <summary>
    /// This class retrieves the input from the manager
    /// </summary>
    public abstract class InputController : MonoBehaviour
    {
        public abstract float RetrieveMoveInput();
        public abstract bool RetrieveJumpInput();
        public abstract bool RetrieveJumpHoldInput();
        public abstract bool RetrieveClimbHoldInput();
    }
}
