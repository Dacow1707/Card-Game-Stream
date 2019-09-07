﻿using System;
using CardGame.Cards;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.Components
{
    public class CardView : MonoBehaviour
    {
        [Required] [SerializeField] private Image cardBackImage;
        [Required] [SerializeField] private Image cardFrontImage;
        [Required] [SerializeField] private TextMeshProUGUI healthText;
        [Required] [SerializeField] private TextMeshProUGUI attackText;
        [Required] [SerializeField] private TextMeshProUGUI manaCostText;
        [Required] [SerializeField] private TextMeshProUGUI titleText;
        [Required] [SerializeField] private TextMeshProUGUI descriptionText;

        public bool IsFaceUp { get; private set; } = false;

        private Card card = null;
        private GameObject[] faceUpElements = null;
        private GameObject[] faceDownElements = null;

        private void Awake()
        {
            faceUpElements = new GameObject[]
            {
                cardFrontImage.gameObject,
                healthText.gameObject,
                attackText.gameObject,
                manaCostText.gameObject,
                titleText.gameObject,
                descriptionText.gameObject,
            };

            faceDownElements = new GameObject[]
            {
                cardBackImage.gameObject,
            };

            Flip(IsFaceUp);
        }

        private void Flip(bool shouldShow)
        {
            IsFaceUp = shouldShow;

            GameObject[] show = shouldShow ? faceUpElements : faceDownElements;
            GameObject[] hide = shouldShow ? faceDownElements : faceUpElements;

            Toggle(show, true);
            Toggle(hide, false);

            Refresh();
        }

        private void Toggle(GameObject[] elements, bool isActive)
        {
            for (int i = 0; i < elements.Length; i++) { elements[i].SetActive(isActive); }
        }

        private void Refresh()
        {
            if (!IsFaceUp) { return; }

            manaCostText.text = card.ManaCost.ToString();
            titleText.text = card.Name;
            descriptionText.text = card.Description;

            if (card is Minion minion)
            {
                attackText.text = minion.Attack.ToString();
                healthText.text = minion.MaxHealth.ToString();
            }
            else
            {
                attackText.text = string.Empty;
                healthText.text = string.Empty;
            }
        }
    }
}
