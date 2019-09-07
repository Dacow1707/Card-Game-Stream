﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace CardGame.Components
{
    public class PlayerView : MonoBehaviour
    {
        [Required] [SerializeField] private DeckView deckView = null;
        [Required] [SerializeField] private HandView handView = null;

        public DeckView DeckView => deckView;
        public HandView HandView => handView;
    }
}
