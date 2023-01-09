using System;
using System.Collections.Generic;
using System.IO;
using UltimateReplay.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateReplay.test
{
    public class ReplayKart : MonoBehaviour
    {
        private ReplayScene recordScene = null;
        private ReplayScene playbackScene = null;
        private ReplayFileTarget recordStorage = null;
        private ReplayFileTarget playbackStorage = null;
        private ReplayHandle recordHandle;
        private ReplayHandle playbackHandle;

        public ReplayObject playerCar;
        public ReplayObject ghostCar;

        // Start is called before the first frame update
        void Start()
        {
            recordScene = new ReplayScene(playerCar);
            playbackScene = new ReplayScene(ghostCar);

            /*
            recordStorage = ReplayFileTarget.CreateReplayFile("test.replay");

            recordHandle = ReplayManager.BeginRecording(recordStorage, recordScene);
            */

            
            // Load the replay
            playbackStorage = ReplayFileTarget.ReadReplayFile("test.replay");

            // Enable the ghost car
            ghostCar.gameObject.SetActive(true);

            // Clone identities - This allows the ghost car to be replayed as the player car
            ReplayObject.CloneReplayObjectIdentity(playerCar, ghostCar);

            // Start replaying
            playbackHandle = ReplayManager.BeginPlayback(playbackStorage, playbackScene);

            // Add end playback listener
            ReplayManager.AddPlaybackEndListener(playbackHandle, OnVehiclePlaybackComplete);
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("="))
            {
                ReplayManager.StopRecording(ref recordHandle);
                Debug.Log("Recording Length: " + recordStorage.Duration);

                recordStorage.Dispose();
                recordStorage = null;
            }
        }

        private void OnVehiclePlaybackComplete()
        {
            // Hide ghost car
            ghostCar.gameObject.SetActive(false);

            // Cleanup playback
            playbackStorage.Dispose();
            playbackStorage = null;

            Debug.Log("Playback end");
        }
    }
}