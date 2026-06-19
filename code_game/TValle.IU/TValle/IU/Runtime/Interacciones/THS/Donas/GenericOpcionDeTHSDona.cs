using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000DD RID: 221
	public class GenericOpcionDeTHSDona : AplicableBehaviour, IModeloDeTHSDonaProductorDeItemInfo, IClickableSelectableTHSDonaItem, IGreyableTHSDonaItem
	{
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x000178AA File Offset: 0x00015AAA
		OnCheckGreyOutEvent IGreyableTHSDonaItem.onCheckGreyOutEvent
		{
			get
			{
				return this.onCheckGreyOutEvent;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x000178B2 File Offset: 0x00015AB2
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionClicked
		{
			get
			{
				return this.onOpcionClicked;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x000178BA File Offset: 0x00015ABA
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionSelectionChanged
		{
			get
			{
				return this.onOpcionSelectionChanged;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x000178C2 File Offset: 0x00015AC2
		public int count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x000178C8 File Offset: 0x00015AC8
		public List<THSDonaController.RadialItemData> ObtenerModelos(out THSDonaController.OnEventoSimpleHandler onShowed, out THSDonaController.OnEventoSimpleHandler onClosed, out THSDonaController.OnEventoSimpleHandler onAceptar, out THSDonaController.OnEventoSimpleHandler onGoBack, LoaderDeTHSDona caller)
		{
			string text = this.defaultText;
			GenericOpcionDeTHSDona.TextDeLocal textDeLocal = this.textos.FirstOrDefault((GenericOpcionDeTHSDona.TextDeLocal t) => t.local == Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id);
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
			List<THSDonaController.RadialItemData> list = new List<THSDonaController.RadialItemData>();
			list.Add(new THSDonaController.RadialItemData
			{
				key = base.GetInstanceID().ToString(),
				text = this.m_DescriptionOverridedEventArgs.description,
				onClicked = new THSDonaController.OnEventoDeBotonSimpleHandler(this.OnClicked),
				onSelectedStateChanged = new THSDonaController.OnEventoDeBotonSelectionHandler(this.OnEventoDeBotonSelectionHandler),
				grayOut = (this.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut),
				hidden = ((this.forzeGreyOut || this.m_EsGreyOutEventArgs.esGreyOut) && this.m_EsGreyOutEventArgs.greyedOutEsInvisible)
			});
			onAceptar = new THSDonaController.OnEventoSimpleHandler(this.OnAceptar);
			onGoBack = new THSDonaController.OnEventoSimpleHandler(this.OnGoBack);
			onShowed = new THSDonaController.OnEventoSimpleHandler(this.OnShowed);
			onClosed = new THSDonaController.OnEventoSimpleHandler(this.OnClosed);
			return list;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00017A42 File Offset: 0x00015C42
		protected virtual void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionClicked;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00017A58 File Offset: 0x00015C58
		protected virtual void OnEventoDeBotonSelectionHandler(THSDonaController.CurrentUserData currentUserData, bool selected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionSelectionChanged;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00017A6F File Offset: 0x00015C6F
		protected virtual void OnAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onAceptar;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00017A84 File Offset: 0x00015C84
		protected virtual void OnGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onGoBack;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00017A99 File Offset: 0x00015C99
		protected virtual void OnShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onShowed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00017AAE File Offset: 0x00015CAE
		protected virtual void OnClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onClosed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0400026F RID: 623
		public bool forzeGreyOut;

		// Token: 0x04000270 RID: 624
		public string defaultText;

		// Token: 0x04000271 RID: 625
		[CoolArrayItem]
		public List<GenericOpcionDeTHSDona.TextDeLocal> textos = new List<GenericOpcionDeTHSDona.TextDeLocal>();

		// Token: 0x04000272 RID: 626
		public OnCheckGreyOutEvent onCheckGreyOutEvent = new OnCheckGreyOutEvent();

		// Token: 0x04000273 RID: 627
		public OnCheckDescriptionOverridedEvent OnCheckDescriptionOverridedEvent = new OnCheckDescriptionOverridedEvent();

		// Token: 0x04000274 RID: 628
		public OnClickItemOpcionDeTHSDonaEvent onOpcionClicked = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x04000275 RID: 629
		public OnClickItemOpcionDeTHSDonaEvent onOpcionSelectionChanged = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x04000276 RID: 630
		public OnInteractDeTHSDonaEvent onAceptar = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000277 RID: 631
		public OnInteractDeTHSDonaEvent onGoBack = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000278 RID: 632
		public OnInteractDeTHSDonaEvent onShowed = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000279 RID: 633
		public OnInteractDeTHSDonaEvent onClosed = new OnInteractDeTHSDonaEvent();

		// Token: 0x0400027A RID: 634
		[NonSerialized]
		private EsGreyOutEventArgs m_EsGreyOutEventArgs = new EsGreyOutEventArgs();

		// Token: 0x0400027B RID: 635
		[NonSerialized]
		private DescriptionOverridedEventArgs m_DescriptionOverridedEventArgs = new DescriptionOverridedEventArgs();

		// Token: 0x020001A6 RID: 422
		[Serializable]
		public class TextDeLocal
		{
			// Token: 0x0400055B RID: 1371
			public Localizacion local;

			// Token: 0x0400055C RID: 1372
			public string text;
		}
	}
}
