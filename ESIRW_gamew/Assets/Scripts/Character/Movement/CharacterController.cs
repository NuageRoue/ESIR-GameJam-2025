//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.13.1
//     from Assets/Scripts/Character/Movement/MainCharacter.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

/// <summary>
/// Provides programmatic access to <see cref="InputActionAsset" />, <see cref="InputActionMap" />, <see cref="InputAction" /> and <see cref="InputControlScheme" /> instances defined in asset "Assets/Scripts/Character/Movement/MainCharacter.inputactions".
/// </summary>
/// <remarks>
/// This class is source generated and any manual edits will be discarded if the associated asset is reimported or modified.
/// </remarks>
/// <example>
/// <code>
/// using namespace UnityEngine;
/// using UnityEngine.InputSystem;
///
/// // Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
/// public class Example : MonoBehaviour, MyActions.IPlayerActions
/// {
///     private MyActions_Actions m_Actions;                  // Source code representation of asset.
///     private MyActions_Actions.PlayerActions m_Player;     // Source code representation of action map.
///
///     void Awake()
///     {
///         m_Actions = new MyActions_Actions();              // Create asset object.
///         m_Player = m_Actions.Player;                      // Extract action map object.
///         m_Player.AddCallbacks(this);                      // Register callback interface IPlayerActions.
///     }
///
///     void OnDestroy()
///     {
///         m_Actions.Dispose();                              // Destroy asset object.
///     }
///
///     void OnEnable()
///     {
///         m_Player.Enable();                                // Enable all actions within map.
///     }
///
///     void OnDisable()
///     {
///         m_Player.Disable();                               // Disable all actions within map.
///     }
///
///     #region Interface implementation of MyActions.IPlayerActions
///
///     // Invoked when "Move" action is either started, performed or canceled.
///     public void OnMove(InputAction.CallbackContext context)
///     {
///         Debug.Log($"OnMove: {context.ReadValue&lt;Vector2&gt;()}");
///     }
///
///     // Invoked when "Attack" action is either started, performed or canceled.
///     public void OnAttack(InputAction.CallbackContext context)
///     {
///         Debug.Log($"OnAttack: {context.ReadValue&lt;float&gt;()}");
///     }
///
///     #endregion
/// }
/// </code>
/// </example>
public partial class @CharacterController: IInputActionCollection2, IDisposable
{
    /// <summary>
    /// Provides access to the underlying asset instance.
    /// </summary>
    public InputActionAsset asset { get; }

    /// <summary>
    /// Constructs a new instance.
    /// </summary>
    public @CharacterController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainCharacter"",
    ""maps"": [
        {
            ""name"": ""MovementActionMap"",
            ""id"": ""a9e7bb4e-2316-449b-818c-3b6209a02d84"",
            ""actions"": [
                {
                    ""name"": ""Moving Around"",
                    ""type"": ""Value"",
                    ""id"": ""eae3fc89-7396-4d1a-915a-5840df2b8b33"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""998bd07e-939e-46e5-89a1-c2ceda6d5b73"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KB"",
                    ""id"": ""91042922-eefc-438a-8c1a-d2c9d4bd2aae"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2c379332-4ff6-4e35-87ee-1e95f196c5db"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""06525ee3-1ce1-4f96-8b72-17380c1ccf90"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""DPAD"",
                    ""id"": ""5f8b6e7e-a5c6-4650-82fe-e2eb965fc3c6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""732cef42-96cf-4dd4-ac22-02cb179ccd38"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e721a202-51ed-494e-bcf3-4d33a6b6e383"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LSTICK"",
                    ""id"": ""6f7bbf3d-bc29-49f7-a868-8a0d7eaa71d1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b3a85a54-1e2b-40e5-8910-2e5ac0d41cd5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""81c544d6-17dc-4cff-b111-7525495dc659"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e6ffe7c3-846e-4468-b83a-601a7136c74e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72370c56-0e51-4517-aefc-5aca31d4b739"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MinimapActionMap"",
            ""id"": ""0b372461-4733-4476-8bd7-f112c2620adb"",
            ""actions"": [
                {
                    ""name"": ""RoomSkill"",
                    ""type"": ""Button"",
                    ""id"": ""b8a96a21-599c-4c38-ae66-9c0b23b08cb2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d89c676-72e5-459e-abc9-5d29fc6ef0a6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RoomSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b77c7d39-ac9c-4514-9c55-b22180970e7f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RoomSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementActionMap
        m_MovementActionMap = asset.FindActionMap("MovementActionMap", throwIfNotFound: true);
        m_MovementActionMap_MovingAround = m_MovementActionMap.FindAction("Moving Around", throwIfNotFound: true);
        m_MovementActionMap_Jump = m_MovementActionMap.FindAction("Jump", throwIfNotFound: true);
        // MinimapActionMap
        m_MinimapActionMap = asset.FindActionMap("MinimapActionMap", throwIfNotFound: true);
        m_MinimapActionMap_RoomSkill = m_MinimapActionMap.FindAction("RoomSkill", throwIfNotFound: true);
    }

    ~@CharacterController()
    {
        UnityEngine.Debug.Assert(!m_MovementActionMap.enabled, "This will cause a leak and performance issues, CharacterController.MovementActionMap.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_MinimapActionMap.enabled, "This will cause a leak and performance issues, CharacterController.MinimapActionMap.Disable() has not been called.");
    }

    /// <summary>
    /// Destroys this asset and all associated <see cref="InputAction"/> instances.
    /// </summary>
    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindingMask" />
    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.devices" />
    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.controlSchemes" />
    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Contains(InputAction)" />
    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.GetEnumerator()" />
    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    /// <inheritdoc cref="IEnumerable.GetEnumerator()" />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Enable()" />
    public void Enable()
    {
        asset.Enable();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Disable()" />
    public void Disable()
    {
        asset.Disable();
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindings" />
    public IEnumerable<InputBinding> bindings => asset.bindings;

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindAction(string, bool)" />
    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindBinding(InputBinding, out InputAction)" />
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovementActionMap
    private readonly InputActionMap m_MovementActionMap;
    private List<IMovementActionMapActions> m_MovementActionMapActionsCallbackInterfaces = new List<IMovementActionMapActions>();
    private readonly InputAction m_MovementActionMap_MovingAround;
    private readonly InputAction m_MovementActionMap_Jump;
    /// <summary>
    /// Provides access to input actions defined in input action map "MovementActionMap".
    /// </summary>
    public struct MovementActionMapActions
    {
        private @CharacterController m_Wrapper;

        /// <summary>
        /// Construct a new instance of the input action map wrapper class.
        /// </summary>
        public MovementActionMapActions(@CharacterController wrapper) { m_Wrapper = wrapper; }
        /// <summary>
        /// Provides access to the underlying input action "MovementActionMap/MovingAround".
        /// </summary>
        public InputAction @MovingAround => m_Wrapper.m_MovementActionMap_MovingAround;
        /// <summary>
        /// Provides access to the underlying input action "MovementActionMap/Jump".
        /// </summary>
        public InputAction @Jump => m_Wrapper.m_MovementActionMap_Jump;
        /// <summary>
        /// Provides access to the underlying input action map instance.
        /// </summary>
        public InputActionMap Get() { return m_Wrapper.m_MovementActionMap; }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Enable()" />
        public void Enable() { Get().Enable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Disable()" />
        public void Disable() { Get().Disable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.enabled" />
        public bool enabled => Get().enabled;
        /// <summary>
        /// Implicitly converts an <see ref="MovementActionMapActions" /> to an <see ref="InputActionMap" /> instance.
        /// </summary>
        public static implicit operator InputActionMap(MovementActionMapActions set) { return set.Get(); }
        /// <summary>
        /// Adds <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <param name="instance">Callback instance.</param>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c> or <paramref name="instance"/> have already been added this method does nothing.
        /// </remarks>
        /// <seealso cref="MovementActionMapActions" />
        public void AddCallbacks(IMovementActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionMapActionsCallbackInterfaces.Add(instance);
            @MovingAround.started += instance.OnMovingAround;
            @MovingAround.performed += instance.OnMovingAround;
            @MovingAround.canceled += instance.OnMovingAround;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        /// <summary>
        /// Removes <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <remarks>
        /// Calling this method when <paramref name="instance" /> have not previously been registered has no side-effects.
        /// </remarks>
        /// <seealso cref="MovementActionMapActions" />
        private void UnregisterCallbacks(IMovementActionMapActions instance)
        {
            @MovingAround.started -= instance.OnMovingAround;
            @MovingAround.performed -= instance.OnMovingAround;
            @MovingAround.canceled -= instance.OnMovingAround;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        /// <summary>
        /// Unregisters <param cref="instance" /> and unregisters all input action callbacks via <see cref="MovementActionMapActions.UnregisterCallbacks(IMovementActionMapActions)" />.
        /// </summary>
        /// <seealso cref="MovementActionMapActions.UnregisterCallbacks(IMovementActionMapActions)" />
        public void RemoveCallbacks(IMovementActionMapActions instance)
        {
            if (m_Wrapper.m_MovementActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        /// <summary>
        /// Replaces all existing callback instances and previously registered input action callbacks associated with them with callbacks provided via <param cref="instance" />.
        /// </summary>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c>, calling this method will only unregister all existing callbacks but not register any new callbacks.
        /// </remarks>
        /// <seealso cref="MovementActionMapActions.AddCallbacks(IMovementActionMapActions)" />
        /// <seealso cref="MovementActionMapActions.RemoveCallbacks(IMovementActionMapActions)" />
        /// <seealso cref="MovementActionMapActions.UnregisterCallbacks(IMovementActionMapActions)" />
        public void SetCallbacks(IMovementActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    /// <summary>
    /// Provides a new <see cref="MovementActionMapActions" /> instance referencing this action map.
    /// </summary>
    public MovementActionMapActions @MovementActionMap => new MovementActionMapActions(this);

    // MinimapActionMap
    private readonly InputActionMap m_MinimapActionMap;
    private List<IMinimapActionMapActions> m_MinimapActionMapActionsCallbackInterfaces = new List<IMinimapActionMapActions>();
    private readonly InputAction m_MinimapActionMap_RoomSkill;
    /// <summary>
    /// Provides access to input actions defined in input action map "MinimapActionMap".
    /// </summary>
    public struct MinimapActionMapActions
    {
        private @CharacterController m_Wrapper;

        /// <summary>
        /// Construct a new instance of the input action map wrapper class.
        /// </summary>
        public MinimapActionMapActions(@CharacterController wrapper) { m_Wrapper = wrapper; }
        /// <summary>
        /// Provides access to the underlying input action "MinimapActionMap/RoomSkill".
        /// </summary>
        public InputAction @RoomSkill => m_Wrapper.m_MinimapActionMap_RoomSkill;
        /// <summary>
        /// Provides access to the underlying input action map instance.
        /// </summary>
        public InputActionMap Get() { return m_Wrapper.m_MinimapActionMap; }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Enable()" />
        public void Enable() { Get().Enable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Disable()" />
        public void Disable() { Get().Disable(); }
        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.enabled" />
        public bool enabled => Get().enabled;
        /// <summary>
        /// Implicitly converts an <see ref="MinimapActionMapActions" /> to an <see ref="InputActionMap" /> instance.
        /// </summary>
        public static implicit operator InputActionMap(MinimapActionMapActions set) { return set.Get(); }
        /// <summary>
        /// Adds <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <param name="instance">Callback instance.</param>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c> or <paramref name="instance"/> have already been added this method does nothing.
        /// </remarks>
        /// <seealso cref="MinimapActionMapActions" />
        public void AddCallbacks(IMinimapActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_MinimapActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MinimapActionMapActionsCallbackInterfaces.Add(instance);
            @RoomSkill.started += instance.OnRoomSkill;
            @RoomSkill.performed += instance.OnRoomSkill;
            @RoomSkill.canceled += instance.OnRoomSkill;
        }

        /// <summary>
        /// Removes <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
        /// </summary>
        /// <remarks>
        /// Calling this method when <paramref name="instance" /> have not previously been registered has no side-effects.
        /// </remarks>
        /// <seealso cref="MinimapActionMapActions" />
        private void UnregisterCallbacks(IMinimapActionMapActions instance)
        {
            @RoomSkill.started -= instance.OnRoomSkill;
            @RoomSkill.performed -= instance.OnRoomSkill;
            @RoomSkill.canceled -= instance.OnRoomSkill;
        }

        /// <summary>
        /// Unregisters <param cref="instance" /> and unregisters all input action callbacks via <see cref="MinimapActionMapActions.UnregisterCallbacks(IMinimapActionMapActions)" />.
        /// </summary>
        /// <seealso cref="MinimapActionMapActions.UnregisterCallbacks(IMinimapActionMapActions)" />
        public void RemoveCallbacks(IMinimapActionMapActions instance)
        {
            if (m_Wrapper.m_MinimapActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        /// <summary>
        /// Replaces all existing callback instances and previously registered input action callbacks associated with them with callbacks provided via <param cref="instance" />.
        /// </summary>
        /// <remarks>
        /// If <paramref name="instance" /> is <c>null</c>, calling this method will only unregister all existing callbacks but not register any new callbacks.
        /// </remarks>
        /// <seealso cref="MinimapActionMapActions.AddCallbacks(IMinimapActionMapActions)" />
        /// <seealso cref="MinimapActionMapActions.RemoveCallbacks(IMinimapActionMapActions)" />
        /// <seealso cref="MinimapActionMapActions.UnregisterCallbacks(IMinimapActionMapActions)" />
        public void SetCallbacks(IMinimapActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_MinimapActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MinimapActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    /// <summary>
    /// Provides a new <see cref="MinimapActionMapActions" /> instance referencing this action map.
    /// </summary>
    public MinimapActionMapActions @MinimapActionMap => new MinimapActionMapActions(this);
    /// <summary>
    /// Interface to implement callback methods for all input action callbacks associated with input actions defined by "MovementActionMap" which allows adding and removing callbacks.
    /// </summary>
    /// <seealso cref="MovementActionMapActions.AddCallbacks(IMovementActionMapActions)" />
    /// <seealso cref="MovementActionMapActions.RemoveCallbacks(IMovementActionMapActions)" />
    public interface IMovementActionMapActions
    {
        /// <summary>
        /// Method invoked when associated input action "Moving Around" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnMovingAround(InputAction.CallbackContext context);
        /// <summary>
        /// Method invoked when associated input action "Jump" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnJump(InputAction.CallbackContext context);
    }
    /// <summary>
    /// Interface to implement callback methods for all input action callbacks associated with input actions defined by "MinimapActionMap" which allows adding and removing callbacks.
    /// </summary>
    /// <seealso cref="MinimapActionMapActions.AddCallbacks(IMinimapActionMapActions)" />
    /// <seealso cref="MinimapActionMapActions.RemoveCallbacks(IMinimapActionMapActions)" />
    public interface IMinimapActionMapActions
    {
        /// <summary>
        /// Method invoked when associated input action "RoomSkill" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
        /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
        void OnRoomSkill(InputAction.CallbackContext context);
    }
}
