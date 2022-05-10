using System;
using UnityEngine;

namespace NFTViewer
{
    public class Application : MonoBehaviour
    {
        public static ApplicationState ApplicationState { get; private set; }
        public static event Action<ApplicationState> OnStateChanged;

        public static void ChangeState (ApplicationState applicationState)
        {
            OnStateChanged?.Invoke(applicationState);
        }

        public void Start()
        {
            ChangeState(ApplicationState.Search);
        }
    }
}
