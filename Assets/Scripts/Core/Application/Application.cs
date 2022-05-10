using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NFTViewer
{
    public class Application : MonoBehaviour
    {
        public static ApplicationState ApplicationState { get; private set; }
        public static event Action<ApplicationState> OnStateChanged;

        public static void ChangeState (ApplicationState applicationState)
        {
            Debug.Log("New state: " + applicationState);
            OnStateChanged?.Invoke(applicationState);
        }

        public void Start()
        {
            ChangeState(ApplicationState.Search);
        }
    }
}
