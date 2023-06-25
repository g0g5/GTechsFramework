using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.Drama
{
    public enum SpeakerPosition
    {
        Left,
        LeftAlt,
        Right,
        RightAlt,
    }

    public struct VisualNovelAction
    {
        //change the background at the given index
        public int actWhenIndex;
        public Sprite newBgSprite;
    }

    public struct VisualNovelSentence
    {
        //speaker stuff
        public Sprite speakerSprite;
        public Transform speakerSpriteSlot;
        public string speakerName;

        //sentence stuff
        public string sentence;
        public float sentencePeroid;


    }
}