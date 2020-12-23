using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitsNBobs
{
    public class ShowMenu : PopUp
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                IsOn = !IsOn;

                UpdateState();
            }
            
        }

        
    }
}
