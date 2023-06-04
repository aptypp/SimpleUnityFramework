﻿using Architecture.Architecture.ContextObjects;
using UnityEngine;

namespace Game.TestProjectObjects
{
    [CreateAssetMenu(fileName = nameof(TestProjectObject), menuName = "Test/TestProjectObject")]
    public class TestProjectObject : ProjectObject
    {
        public string GetWorks() => "ITS WORKS";
    }
}