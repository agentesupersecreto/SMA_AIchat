using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus
{
	// Token: 0x020000A7 RID: 167
	public class SlaveOpcionDeTHSDona : AplicableBehaviour, IModeloDeTHSDonaProductorDeItemInfo, IClickableSelectableTHSDonaItem, IGreyableTHSDonaItem
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00024F1C File Offset: 0x0002311C
		OnCheckGreyOutEvent IGreyableTHSDonaItem.onCheckGreyOutEvent
		{
			get
			{
				return this.onCheckGreyOutEvent;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00024F24 File Offset: 0x00023124
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionClicked
		{
			get
			{
				return this.onOpcionClicked;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00024F2C File Offset: 0x0002312C
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionSelectionChanged
		{
			get
			{
				return this.onOpcionSelectionChanged;
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00024F34 File Offset: 0x00023134
		public void SetMaster(GenericRadialMenuMap master)
		{
			if (master == null)
			{
				throw new ArgumentNullException("master", "master null reference.");
			}
			if (this.m_master != null)
			{
				throw new InvalidOperationException();
			}
			this.m_master = master;
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00024F6A File Offset: 0x0002316A
		public int count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00024F70 File Offset: 0x00023170
		public List<THSDonaController.RadialItemData> ObtenerModelos(out THSDonaController.OnEventoSimpleHandler onShowed, out THSDonaController.OnEventoSimpleHandler onClosed, out THSDonaController.OnEventoSimpleHandler onAceptar, out THSDonaController.OnEventoSimpleHandler onGoBack, LoaderDeTHSDona caller)
		{
			string text = this.m_master.defaultText;
			GenericOpcionDeTHSDona.TextDeLocal textDeLocal = this.m_master.textos.FirstOrDefault((GenericOpcionDeTHSDona.TextDeLocal t) => t.local == Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id);
			if (textDeLocal != null)
			{
				text = textDeLocal.text;
			}
			this.m_EsGreyOutEventArgs.esGreyOut = false;
			this.m_EsGreyOutEventArgs.greyedOutEsInvisible = false;
			this.m_DescriptionOverridedEventArgs.description = text;
			OnCheckGreyOutEvent onCheckGreyOutEvent = this.onCheckGreyOutEvent;
			if (onCheckGreyOutEvent != null)
			{
				onCheckGreyOutEvent.Invoke(this.m_EsGreyOutEventArgs, this);
			}
			OnCheckDescriptionOverridedEvent onCheckDescriptionOverridedEvent = this.OnCheckDescriptionOverridedEvent;
			if (onCheckDescriptionOverridedEvent != null)
			{
				onCheckDescriptionOverridedEvent.Invoke(this.m_DescriptionOverridedEventArgs, this);
			}
			OnCheckGreyOutEvent onCheckGreyOutEvent2 = this.m_master.onCheckGreyOutEvent;
			if (onCheckGreyOutEvent2 != null)
			{
				onCheckGreyOutEvent2.Invoke(this.m_EsGreyOutEventArgs, this);
			}
			OnCheckDescriptionOverridedEvent onCheckDescriptionOverridedEvent2 = this.m_master.OnCheckDescriptionOverridedEvent;
			if (onCheckDescriptionOverridedEvent2 != null)
			{
				onCheckDescriptionOverridedEvent2.Invoke(this.m_DescriptionOverridedEventArgs, this);
			}
			List<THSDonaController.RadialItemData> list = new List<THSDonaController.RadialItemData>();
			list.Add(new THSDonaController.RadialItemData
			{
				key = base.GetInstanceID().ToString(),
				text = this.m_DescriptionOverridedEventArgs.description,
				onClicked = new THSDonaController.OnEventoDeBotonSimpleHandler(this.OnClicked),
				onSelectedStateChanged = new THSDonaController.OnEventoDeBotonSelectionHandler(this.OnEventoDeBotonSelectionHandler),
				grayOut = (this.m_master.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut),
				hidden = ((this.m_master.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut) && this.m_EsGreyOutEventArgs.greyedOutEsInvisible)
			});
			onAceptar = new THSDonaController.OnEventoSimpleHandler(this.OnAceptar);
			onGoBack = new THSDonaController.OnEventoSimpleHandler(this.OnGoBack);
			onShowed = new THSDonaController.OnEventoSimpleHandler(this.OnShowed);
			onClosed = new THSDonaController.OnEventoSimpleHandler(this.OnClosed);
			return list;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00025138 File Offset: 0x00023338
		protected virtual void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionClicked;
			if (onClickItemOpcionDeTHSDonaEvent != null)
			{
				onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
			}
			this.m_master.OnClicked(currentUserData, dona, sender);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0002515D File Offset: 0x0002335D
		protected virtual void OnEventoDeBotonSelectionHandler(THSDonaController.CurrentUserData currentUserData, bool selected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionSelectionChanged;
			if (onClickItemOpcionDeTHSDonaEvent != null)
			{
				onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
			}
			this.m_master.OnEventoDeBotonSelectionHandler(currentUserData, selected, dona, sender);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00025185 File Offset: 0x00023385
		protected virtual void OnAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onAceptar;
			if (onInteractDeTHSDonaEvent != null)
			{
				onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
			}
			this.m_master.OnAceptar(currentUserData, sender);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000251A8 File Offset: 0x000233A8
		protected virtual void OnGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onGoBack;
			if (onInteractDeTHSDonaEvent != null)
			{
				onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
			}
			this.m_master.OnGoBack(currentUserData, sender);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000251CB File Offset: 0x000233CB
		protected virtual void OnShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onShowed;
			if (onInteractDeTHSDonaEvent != null)
			{
				onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
			}
			this.m_master.OnShowed(currentUserData, sender);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x000251EE File Offset: 0x000233EE
		protected virtual void OnClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onClosed;
			if (onInteractDeTHSDonaEvent != null)
			{
				onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
			}
			this.m_master.OnClosed(currentUserData, sender);
		}

		// Token: 0x040003CF RID: 975
		[ReadOnlyUI]
		[SerializeField]
		private GenericRadialMenuMap m_master;

		// Token: 0x040003D0 RID: 976
		public OnCheckGreyOutEvent onCheckGreyOutEvent = new OnCheckGreyOutEvent();

		// Token: 0x040003D1 RID: 977
		public OnCheckDescriptionOverridedEvent OnCheckDescriptionOverridedEvent = new OnCheckDescriptionOverridedEvent();

		// Token: 0x040003D2 RID: 978
		public OnClickItemOpcionDeTHSDonaEvent onOpcionClicked = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x040003D3 RID: 979
		public OnClickItemOpcionDeTHSDonaEvent onOpcionSelectionChanged = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x040003D4 RID: 980
		public OnInteractDeTHSDonaEvent onAceptar = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003D5 RID: 981
		public OnInteractDeTHSDonaEvent onGoBack = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003D6 RID: 982
		public OnInteractDeTHSDonaEvent onShowed = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003D7 RID: 983
		public OnInteractDeTHSDonaEvent onClosed = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003D8 RID: 984
		[NonSerialized]
		private EsGreyOutEventArgs m_EsGreyOutEventArgs = new EsGreyOutEventArgs();

		// Token: 0x040003D9 RID: 985
		[NonSerialized]
		private DescriptionOverridedEventArgs m_DescriptionOverridedEventArgs = new DescriptionOverridedEventArgs();
	}
}
