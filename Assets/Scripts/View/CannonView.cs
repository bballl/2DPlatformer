﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CannonView : MonoBehaviour
    {
        public Transform _muzzleTransform;
        public Transform _emitterTransform; //точка вылета пуль
        public List<LevelObjectView> _bullets;
    }
} 

