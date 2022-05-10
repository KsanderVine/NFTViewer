using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NFTViewer
{
    public class MenuController : MonoBehaviour, IController
    {
        public void Awake()
        {
            Applicaton.OnStateChanged += OnStateChanged;
        }

        public void OnStateChanged(ApplicationState applicationState)
        {
            if (applicationState != ApplicationState.Menu)
            {
            }
        }
    }
}
