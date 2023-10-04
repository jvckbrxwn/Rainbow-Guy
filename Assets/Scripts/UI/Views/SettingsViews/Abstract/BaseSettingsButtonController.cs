using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.SettingsViews.Abstract
{
	public abstract class BaseSettingsButtonController : MonoBehaviour
	{
		[SerializeField] protected Button button;
		[SerializeField] protected Image stateImage;

		[SerializeField] private Sprite activeSprite;
		[SerializeField] private Sprite inactiveSprite;

		private bool state;

		public event Action Clicked;

		protected internal bool State
		{
			get => state;
			protected set
			{
				state = value;
				UpdateVisual(state);
			}
		}

		protected abstract void OnClicked();

		private void Awake()
		{
			Init();
		}

		private void Init()
		{
			Clicked += OnClicked;
			button.onClick.AddListener(() => Clicked?.Invoke());
			State = true;
		}

		private void UpdateVisual(bool state)
		{
			stateImage.sprite = state ? activeSprite : inactiveSprite;
		}
	}
}