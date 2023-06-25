using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.Drama
{
    public class VNSectionData : ScriptableObject
    {
        [SerializeField]
        public List<VisualNovelSentence> sentences;
        [SerializeField]
        public List<VisualNovelAction> actions;
    }
}