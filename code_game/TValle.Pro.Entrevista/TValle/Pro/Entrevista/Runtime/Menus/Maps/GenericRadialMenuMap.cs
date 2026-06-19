using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus.Maps
{
	// Token: 0x020000AC RID: 172
	[CreateAssetMenu(fileName = "GenericRadialMenuMap", menuName = "Objetos/Activities/GenericRadialMenuMap")]
	public class GenericRadialMenuMap : RadialMenuMap, IRadialMenuMap
	{
		// Token: 0x06000661 RID: 1633 RVA: 0x00025569 File Offset: 0x00023769
		public virtual void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionClicked;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0002557F File Offset: 0x0002377F
		public virtual void OnEventoDeBotonSelectionHandler(THSDonaController.CurrentUserData currentUserData, bool selected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionSelectionChanged;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00025596 File Offset: 0x00023796
		public virtual void OnAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onAceptar;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x000255AB File Offset: 0x000237AB
		public virtual void OnGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onGoBack;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x000255C0 File Offset: 0x000237C0
		public virtual void OnShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onShowed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x000255D5 File Offset: 0x000237D5
		public virtual void OnClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onClosed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x040003E1 RID: 993
		public List<RadialMenuMap> subMenus = new List<RadialMenuMap>();

		// Token: 0x040003E2 RID: 994
		public bool forzeGreyOut;

		// Token: 0x040003E3 RID: 995
		public string defaultText;

		// Token: 0x040003E4 RID: 996
		[CoolArrayItem]
		public List<GenericOpcionDeTHSDona.TextDeLocal> textos = new List<GenericOpcionDeTHSDona.TextDeLocal>();

		// Token: 0x040003E5 RID: 997
		public OnCheckGreyOutEvent onCheckGreyOutEvent = new OnCheckGreyOutEvent();

		// Token: 0x040003E6 RID: 998
		public OnCheckDescriptionOverridedEvent OnCheckDescriptionOverridedEvent = new OnCheckDescriptionOverridedEvent();

		// Token: 0x040003E7 RID: 999
		public OnClickItemOpcionDeTHSDonaEvent onOpcionClicked = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x040003E8 RID: 1000
		public OnClickItemOpcionDeTHSDonaEvent onOpcionSelectionChanged = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x040003E9 RID: 1001
		public OnInteractDeTHSDonaEvent onAceptar = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003EA RID: 1002
		public OnInteractDeTHSDonaEvent onGoBack = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003EB RID: 1003
		public OnInteractDeTHSDonaEvent onShowed = new OnInteractDeTHSDonaEvent();

		// Token: 0x040003EC RID: 1004
		public OnInteractDeTHSDonaEvent onClosed = new OnInteractDeTHSDonaEvent();
	}
}
