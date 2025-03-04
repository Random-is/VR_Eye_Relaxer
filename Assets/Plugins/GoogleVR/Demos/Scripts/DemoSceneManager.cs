//-----------------------------------------------------------------------
// <copyright file="DemoSceneManager.cs" company="Google Inc.">
// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.Demos {
    using UnityEngine;

    /// <summary>Ensures correct app and scene setup.</summary>
    public class DemoSceneManager : MonoBehaviour {
        private void Start() {
            Input.backButtonLeavesApp = true;
        }

        private void Update() {
            // Exit when (X) is tapped.
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }
}