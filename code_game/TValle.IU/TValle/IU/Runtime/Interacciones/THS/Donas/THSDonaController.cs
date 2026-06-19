using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E6 RID: 230
	public sealed class THSDonaController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00018662 File Offset: 0x00016862
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update3);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x0001866A File Offset: 0x0001686A
		public static THSDonaController instance
		{
			get
			{
				return THSDonaController.m_THSDonaController;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x00018671 File Offset: 0x00016871
		public bool enUso
		{
			get
			{
				if (base.isActiveAndEnabled)
				{
					THSDonaController.CurrentUserData currentUserData = this.m_CurrentUserData;
					return ((currentUserData != null) ? currentUserData.user : null) != null;
				}
				return false;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00018695 File Offset: 0x00016895
		public Component currentUser
		{
			get
			{
				THSDonaController.CurrentUserData currentUserData = this.m_CurrentUserData;
				if (currentUserData == null)
				{
					return null;
				}
				return currentUserData.user;
			}
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000186A8 File Offset: 0x000168A8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			THSDonaController.m_THSDonaController = this;
			this.m_THSDona = base.GetComponentInChildren<UltimateRadialMenu>(true);
			if (this.m_THSDona == null)
			{
				throw new ArgumentNullException("m_THSDona", "m_THSDona null reference.");
			}
			this.m_THSDonaGroup = this.m_THSDona.GetComponent<CanvasGroup>();
			if (this.m_THSDonaGroup == null)
			{
				throw new ArgumentNullException("m_THSDonaGroup", "m_THSDonaGroup null reference.");
			}
			if (this.m_controlsGroup == null)
			{
				throw new ArgumentNullException("m_controlsGroup", "m_controlsGroup null reference.");
			}
			if (this.m_aceptarButton == null)
			{
				throw new ArgumentNullException("m_aceptarButton", "m_aceptarButton null reference.");
			}
			if (this.m_goBackButton == null)
			{
				throw new ArgumentNullException("m_goBackButton", "m_goBackButton null reference.");
			}
			this.m_THSDonaGroup.blocksRaycasts = false;
			this.m_THSDonaGroup.interactable = false;
			this.m_controlsGroup.blocksRaycasts = false;
			this.m_controlsGroup.interactable = false;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000187A5 File Offset: 0x000169A5
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_THSDona.initialState = UltimateRadialMenu.InitialState.Disabled;
			this.m_THSDona.gameObject.SetActive(true);
			this.m_controlsGroup.gameObject.SetActive(true);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000187DC File Offset: 0x000169DC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_aceptarButton.onClick.AddListener(new UnityAction(this.OnAceptarClicked));
			this.m_goBackButton.onClick.AddListener(new UnityAction(this.OnGoBackClicked));
			this.m_canShowConfigGeneralMod = Singleton<ConfiguracionGeneralDeVentanasPrincipales>.instance.canShowConfigPanel.ObtenerModificadorNotNull(this);
			ConfiguracionGeneralDeMouse instance = Singleton<ConfiguracionGeneralDeMouse>.instance;
			this.m_canHideCursor = ((instance != null) ? instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this) : null);
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00018860 File Offset: 0x00016A60
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Button aceptarButton = this.m_aceptarButton;
			if (aceptarButton != null)
			{
				aceptarButton.onClick.AddListener(new UnityAction(this.OnAceptarClicked));
			}
			Button goBackButton = this.m_goBackButton;
			if (goBackButton != null)
			{
				goBackButton.onClick.AddListener(new UnityAction(this.OnGoBackClicked));
			}
			this.m_THSDona;
			this.StopDrawing();
			ModificadorDeBool canShowConfigGeneralMod = this.m_canShowConfigGeneralMod;
			if (canShowConfigGeneralMod != null)
			{
				canShowConfigGeneralMod.TryRemoverDeOwner(true);
			}
			ModificadorDeBool canHideCursor = this.m_canHideCursor;
			if (canHideCursor != null)
			{
				canHideCursor.TryRemoverDeOwner(true);
			}
			this.m_canShowConfigGeneralMod = null;
			this.m_canHideCursor = null;
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00018904 File Offset: 0x00016B04
		public override void OnUpdateEvent1()
		{
			if (!this.enUso)
			{
				this.m_CurrentUserData = null;
				this.m_THSDonaGroup.blocksRaycasts = false;
				this.m_THSDonaGroup.interactable = false;
			}
			this.m_controlsGroup.enabled = this.m_THSDonaGroup.enabled;
			this.m_controlsGroup.alpha = this.m_THSDonaGroup.alpha;
			this.m_controlsGroup.blocksRaycasts = this.m_THSDonaGroup.blocksRaycasts;
			this.m_controlsGroup.ignoreParentGroups = this.m_THSDonaGroup.ignoreParentGroups;
			this.m_controlsGroup.interactable = this.m_THSDonaGroup.interactable;
			try
			{
				if (this.enUso)
				{
					for (int i = 0; i < this.m_THSDona.UltimateRadialButtonList.Count; i++)
					{
						UltimateRadialMenu.UltimateRadialButton ultimateRadialButton = this.m_THSDona.UltimateRadialButtonList[i];
						if (this.m_CurrentUserData.radialsSelectedSet.Contains(ultimateRadialButton.key))
						{
							if (this.m_THSDona.spriteSwap && this.m_THSDona.selectedSprite != null)
							{
								ultimateRadialButton.radialImage.sprite = this.m_THSDona.selectedSprite;
							}
							if (this.m_THSDona.colorChange && ultimateRadialButton.radialImage.sprite != null)
							{
								ultimateRadialButton.radialImage.color = this.m_THSDona.selectedColor;
							}
						}
					}
				}
			}
			finally
			{
				this.m_radialEntered = null;
			}
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00018A88 File Offset: 0x00016C88
		public void Draw(THSDonaController.CurrentUserData userData)
		{
			if (((userData != null) ? userData.user : null) == null)
			{
				throw new ArgumentNullException("userData?.user", "userData?.user null reference.");
			}
			if (userData == this.m_CurrentUserData)
			{
				Debug.LogError("TRatando de dinujar dos veces el mismo usuario", this);
				return;
			}
			this.StopDrawing();
			this.m_CurrentUserData = userData;
			this.m_THSDonaGroup.blocksRaycasts = true;
			this.m_THSDonaGroup.interactable = true;
			this.m_aceptarButton.gameObject.SetActive(userData.config.usaAceptarBoton);
			this.m_goBackButton.gameObject.SetActive(userData.config.usaGoBackBoton);
			this.m_aceptarButton.GetComponentInChildren<Text>().text = userData.aceptarText;
			for (int i = 0; i < userData.radialItemsData.Count; i++)
			{
				THSDonaController.RadialItemData radialItemData = userData.radialItemsData[i];
				if (!radialItemData.hidden)
				{
					UltimateRadialButtonInfo ultimateRadialButtonInfo = new UltimateRadialButtonInfo();
					if (radialItemData.id < 0)
					{
						ultimateRadialButtonInfo.id = radialItemData.key.GetHashCode();
					}
					else
					{
						ultimateRadialButtonInfo.id = radialItemData.id;
					}
					ultimateRadialButtonInfo.key = radialItemData.key;
					ultimateRadialButtonInfo.name = radialItemData.text;
					this.m_THSDona.RegisterToRadialMenu(new Action<string>(this.OnRadialButtonClicked), ultimateRadialButtonInfo, -1);
					if (radialItemData.grayOut)
					{
						ultimateRadialButtonInfo.DisableButton();
					}
				}
			}
			for (int j = 0; j < this.m_THSDona.UltimateRadialButtonList.Count; j++)
			{
				this.m_THSDona.UltimateRadialButtonList[j].text.GetComponent<Outline>().effectDistance = new Vector2(0.25f, -0.25f);
			}
			this.m_THSDona.EnableRadialMenu();
			this.UpdatePanelAndCursor();
			THSDonaController.CurrentUserData currentUserData = this.m_CurrentUserData;
			if (currentUserData == null)
			{
				return;
			}
			THSDonaController.OnEventoSimpleHandler onShowed = currentUserData.onShowed;
			if (onShowed == null)
			{
				return;
			}
			onShowed(this.m_CurrentUserData, this);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00018C5C File Offset: 0x00016E5C
		public void StopDrawing()
		{
			THSDonaController.CurrentUserData currentUserData = this.m_CurrentUserData;
			if (currentUserData != null)
			{
				THSDonaController.OnEventoSimpleHandler onClosed = currentUserData.onClosed;
				if (onClosed != null)
				{
					onClosed(this.m_CurrentUserData, this);
				}
			}
			this.m_CurrentUserData = null;
			UltimateRadialMenu thsdona = this.m_THSDona;
			if (thsdona != null)
			{
				thsdona.RemoveAllRadialButtons(0);
			}
			UltimateRadialMenu thsdona2 = this.m_THSDona;
			if (thsdona2 != null)
			{
				thsdona2.DisableRadialMenuImmediate();
			}
			if (this.m_THSDonaGroup != null)
			{
				this.m_THSDonaGroup.blocksRaycasts = false;
				this.m_THSDonaGroup.interactable = false;
			}
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00018CE4 File Offset: 0x00016EE4
		private void UpdatePanelAndCursor()
		{
			if (this.enUso)
			{
				if (this.m_canShowConfigGeneralMod != null)
				{
					this.m_canShowConfigGeneralMod.valor.valor = false;
				}
				if (this.m_canHideCursor != null)
				{
					this.m_canHideCursor.valor.valor = false;
					return;
				}
			}
			else
			{
				if (this.m_canShowConfigGeneralMod != null)
				{
					this.m_canShowConfigGeneralMod.valor.valor = true;
				}
				if (this.m_canHideCursor != null)
				{
					this.m_canHideCursor.valor.valor = true;
				}
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00018D5E File Offset: 0x00016F5E
		public void EmulateAccept()
		{
			this.OnAceptarClicked();
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00018D66 File Offset: 0x00016F66
		public void EmulateGoBack()
		{
			this.OnGoBackClicked();
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00018D6E File Offset: 0x00016F6E
		private void OnAceptarClicked()
		{
			if (this.enUso)
			{
				THSDonaController.OnEventoSimpleHandler onAceptar = this.m_CurrentUserData.onAceptar;
				if (onAceptar == null)
				{
					return;
				}
				onAceptar(this.m_CurrentUserData, this);
			}
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00018D94 File Offset: 0x00016F94
		private void OnGoBackClicked()
		{
			if (this.enUso)
			{
				THSDonaController.OnEventoSimpleHandler onGoBack = this.m_CurrentUserData.onGoBack;
				if (onGoBack == null)
				{
					return;
				}
				onGoBack(this.m_CurrentUserData, this);
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00018DBC File Offset: 0x00016FBC
		private void OnRadialButtonClicked(string obj)
		{
			if (this.enUso)
			{
				THSDonaController.CurrentUserData currentUserData = this.m_CurrentUserData;
				bool flag = currentUserData.radialsSelectedSet.Contains(obj);
				currentUserData.radialsSelectedSet.Remove(obj);
				for (int i = currentUserData.radialsSelected.Count - 1; i >= 0; i--)
				{
					if (currentUserData.radialsSelected[i] == obj)
					{
						currentUserData.radialsSelected.RemoveAt(i);
					}
				}
				if (!flag)
				{
					currentUserData.radialsSelected.Add(obj);
					currentUserData.radialsSelectedSet.Add(obj);
				}
				for (int j = 0; j < currentUserData.radialItemsData.Count; j++)
				{
					THSDonaController.RadialItemData radialItemData = currentUserData.radialItemsData[j];
					if (radialItemData.key == obj)
					{
						THSDonaController.OnEventoDeBotonSelectionHandler onSelectedStateChanged = radialItemData.onSelectedStateChanged;
						if (onSelectedStateChanged != null)
						{
							onSelectedStateChanged(currentUserData, currentUserData.radialsSelectedSet.Contains(obj), this, radialItemData);
						}
						THSDonaController.OnEventoDeBotonSimpleHandler onClicked = radialItemData.onClicked;
						if (onClicked != null)
						{
							onClicked(currentUserData, this, radialItemData);
						}
					}
				}
				THSDonaController.OnEventoConKeyAndSelectionHandler onRadialSelectedStateChanged = currentUserData.onRadialSelectedStateChanged;
				if (onRadialSelectedStateChanged != null)
				{
					onRadialSelectedStateChanged(currentUserData, obj, currentUserData.radialsSelectedSet.Contains(obj), this);
				}
				THSDonaController.OnEventoConKeyHandler onRadialClicked = currentUserData.onRadialClicked;
				if (onRadialClicked == null)
				{
					return;
				}
				onRadialClicked(currentUserData, obj, this);
			}
		}

		// Token: 0x04000293 RID: 659
		private static THSDonaController m_THSDonaController;

		// Token: 0x04000294 RID: 660
		[SerializeField]
		private CanvasGroup m_controlsGroup;

		// Token: 0x04000295 RID: 661
		[SerializeField]
		private Button m_aceptarButton;

		// Token: 0x04000296 RID: 662
		[SerializeField]
		private Button m_goBackButton;

		// Token: 0x04000297 RID: 663
		private UltimateRadialMenu m_THSDona;

		// Token: 0x04000298 RID: 664
		[SerializeField]
		private THSDonaController.CurrentUserData m_CurrentUserData;

		// Token: 0x04000299 RID: 665
		[SerializeField]
		private ModificadorDeBool m_canShowConfigGeneralMod;

		// Token: 0x0400029A RID: 666
		[SerializeField]
		private ModificadorDeBool m_canHideCursor;

		// Token: 0x0400029B RID: 667
		private CanvasGroup m_THSDonaGroup;

		// Token: 0x0400029C RID: 668
		private int? m_radialEntered;

		// Token: 0x020001AA RID: 426
		// (Invoke) Token: 0x06000B92 RID: 2962
		public delegate void OnEventoSimpleHandler(THSDonaController.CurrentUserData currentUserData, THSDonaController sender);

		// Token: 0x020001AB RID: 427
		// (Invoke) Token: 0x06000B96 RID: 2966
		public delegate void OnEventoConKeyHandler(THSDonaController.CurrentUserData currentUserData, string key, THSDonaController sender);

		// Token: 0x020001AC RID: 428
		// (Invoke) Token: 0x06000B9A RID: 2970
		public delegate void OnEventoConKeyAndSelectionHandler(THSDonaController.CurrentUserData currentUserData, string key, bool selected, THSDonaController sender);

		// Token: 0x020001AD RID: 429
		// (Invoke) Token: 0x06000B9E RID: 2974
		public delegate void OnEventoDeBotonSimpleHandler(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender);

		// Token: 0x020001AE RID: 430
		// (Invoke) Token: 0x06000BA2 RID: 2978
		public delegate void OnEventoDeBotonSelectionHandler(THSDonaController.CurrentUserData currentUserData, bool isSelected, THSDonaController dona, THSDonaController.RadialItemData sender);

		// Token: 0x020001AF RID: 431
		[Serializable]
		public class CurrentUserData
		{
			// Token: 0x04000562 RID: 1378
			public Component user;

			// Token: 0x04000563 RID: 1379
			public string aceptarText = string.Empty;

			// Token: 0x04000564 RID: 1380
			public List<THSDonaController.RadialItemData> radialItemsData = new List<THSDonaController.RadialItemData>();

			// Token: 0x04000565 RID: 1381
			public THSDonaController.OnEventoSimpleHandler onShowed;

			// Token: 0x04000566 RID: 1382
			public THSDonaController.OnEventoSimpleHandler onClosed;

			// Token: 0x04000567 RID: 1383
			public THSDonaController.OnEventoSimpleHandler onAceptar;

			// Token: 0x04000568 RID: 1384
			public THSDonaController.OnEventoSimpleHandler onGoBack;

			// Token: 0x04000569 RID: 1385
			public THSDonaController.OnEventoConKeyHandler onRadialClicked;

			// Token: 0x0400056A RID: 1386
			public THSDonaController.OnEventoConKeyAndSelectionHandler onRadialSelectedStateChanged;

			// Token: 0x0400056B RID: 1387
			public List<string> radialsSelected = new List<string>();

			// Token: 0x0400056C RID: 1388
			public HashSet<string> radialsSelectedSet = new HashSet<string>();

			// Token: 0x0400056D RID: 1389
			public THSDonaController.CurrentUserData.Config config = new THSDonaController.CurrentUserData.Config();

			// Token: 0x020001DB RID: 475
			[Serializable]
			public class Config
			{
				// Token: 0x040005D3 RID: 1491
				public bool usaAceptarBoton;

				// Token: 0x040005D4 RID: 1492
				public bool usaGoBackBoton = true;
			}
		}

		// Token: 0x020001B0 RID: 432
		[Serializable]
		public class RadialItemData
		{
			// Token: 0x0400056E RID: 1390
			public int id = -1;

			// Token: 0x0400056F RID: 1391
			public string key;

			// Token: 0x04000570 RID: 1392
			public string text;

			// Token: 0x04000571 RID: 1393
			public bool grayOut;

			// Token: 0x04000572 RID: 1394
			public bool hidden;

			// Token: 0x04000573 RID: 1395
			public THSDonaController.OnEventoDeBotonSimpleHandler onClicked;

			// Token: 0x04000574 RID: 1396
			public THSDonaController.OnEventoDeBotonSelectionHandler onSelectedStateChanged;
		}
	}
}
