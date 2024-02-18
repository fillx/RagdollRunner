using System.Collections.Generic;
using UnityEngine;

namespace GameSDK.Scripts.Race
{
    public  class RaceControlService
    {
        public static int Runs { get; private set; }
        public static void StartRun(int targetRunCount)
        {
            if (Runs >= targetRunCount)
            {
                Runs = 0;
                PlayerPrefs.DeleteAll();
            }

            Runs++;
        }
    }
}