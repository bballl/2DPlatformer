using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }
    [CreateAssetMenu(fileName = "SpriteAnimatorCfg", menuName = "Config / Animation Cfg", order = 1)] //атрибут 
                                                       //для CreateAsset, чтобы оттуда м.б. делать вызов по ПКМ
    public class SpriteAnimatorConfig : ScriptableObject
    {
        //класс, к-рый будет хранить последовательность спрайтов и ее название
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequence = new List<SpriteSequence>();
    }
}
