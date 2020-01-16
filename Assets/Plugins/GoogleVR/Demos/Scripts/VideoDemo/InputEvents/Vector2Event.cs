//-----------------------------------------------------------------------
// <copyright file="Vector2Event.cs" company="Google Inc.">
// Copyright 2016 Google Inc. All rights reserved.
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

namespace GoogleVR.VideoDemo {
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>A `UnityEvent` wrapper for Vector2 events.</summary>
    [Serializable]
    public class Vector2Event : UnityEvent<Vector2> {
    }
}