using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000DE RID: 222
	public abstract class GenericOpcionesDeTHSDonaDeColleccion : AplicableBehaviour, IModeloDeTHSDonaProductorDeItemInfo, IClickableSelectableTHSDonaItem
	{
		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00017B50 File Offset: 0x00015D50
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionClicked
		{
			get
			{
				return this.onOpcionClicked;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00017B58 File Offset: 0x00015D58
		OnClickItemOpcionDeTHSDonaEvent IClickableSelectableTHSDonaItem.onOpcionSelectionChanged
		{
			get
			{
				return this.onOpcionSelectionChanged;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000683 RID: 1667
		public abstract int count { get; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00017B60 File Offset: 0x00015D60
		public IReadOnlyList<int> selectedIndices
		{
			get
			{
				return this.m_selectedIndices;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00017B68 File Offset: 0x00015D68
		public IReadOnlyList<THSDonaController.RadialItemData> selected
		{
			get
			{
				return this.m_selected;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x00017B70 File Offset: 0x00015D70
		public IReadOnlyCollection<int> selectedIndicesSet
		{
			get
			{
				return this.m_selectedIndicesSet;
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00017B78 File Offset: 0x00015D78
		public List<THSDonaController.RadialItemData> ObtenerModelos(out THSDonaController.OnEventoSimpleHandler onShowed, out THSDonaController.OnEventoSimpleHandler onClosed, out THSDonaController.OnEventoSimpleHandler onAceptar, out THSDonaController.OnEventoSimpleHandler onGoBack, LoaderDeTHSDona caller)
		{
			this.OnLoadingItems(caller);
			List<THSDonaController.RadialItemData> list3;
			try
			{
				List<int> list = new List<int>();
				for (int i = 0; i < this.count; i++)
				{
					if (this.PuedeDibujarIndex(i))
					{
						list.Add(i);
					}
				}
				List<THSDonaController.RadialItemData> list2 = new List<THSDonaController.RadialItemData>(list.Count);
				foreach (int num in list)
				{
					bool flag = this.IndexEsGreyOut(num);
					THSDonaController.RadialItemData radialItemData = new THSDonaController.RadialItemData
					{
						grayOut = flag,
						hidden = false,
						text = this.TextDeIndex(num),
						id = num,
						key = this.KeyDeIndex(num),
						onClicked = new THSDonaController.OnEventoDeBotonSimpleHandler(this.OnClicked),
						onSelectedStateChanged = new THSDonaController.OnEventoDeBotonSelectionHandler(this.OnSelectedStateChanged)
					};
					list2.Add(radialItemData);
				}
				onAceptar = new THSDonaController.OnEventoSimpleHandler(this.OnAceptar);
				onGoBack = new THSDonaController.OnEventoSimpleHandler(this.OnGoBack);
				onShowed = new THSDonaController.OnEventoSimpleHandler(this.OnShowed);
				onClosed = new THSDonaController.OnEventoSimpleHandler(this.OnClosed);
				list3 = list2;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				onAceptar = null;
				onGoBack = null;
				onShowed = null;
				onClosed = null;
				list3 = new List<THSDonaController.RadialItemData>();
			}
			finally
			{
				this.OnLoadedItems(caller);
			}
			return list3;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00017D10 File Offset: 0x00015F10
		private void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			this.OnItemClicked(currentUserData, dona, sender);
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionClicked;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00017D30 File Offset: 0x00015F30
		private void OnSelectedStateChanged(THSDonaController.CurrentUserData currentUserData, bool isSelected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			this.m_selected.Clear();
			this.m_selected.AddRange(currentUserData.radialItemsData.Where((THSDonaController.RadialItemData item) => currentUserData.radialsSelectedSet.Contains(item.key)));
			IEnumerable<int> enumerable = this.m_selected.Select((THSDonaController.RadialItemData item) => item.id);
			this.m_selectedIndices.Clear();
			this.m_selectedIndices.AddRange(enumerable);
			this.m_selectedIndicesSet.Clear();
			this.m_selectedIndicesSet.UnionWith(enumerable);
			this.OnItemSelectedStateChanged(currentUserData, isSelected, dona, sender);
			OnClickItemOpcionDeTHSDonaEvent onClickItemOpcionDeTHSDonaEvent = this.onOpcionSelectionChanged;
			if (onClickItemOpcionDeTHSDonaEvent == null)
			{
				return;
			}
			onClickItemOpcionDeTHSDonaEvent.Invoke(currentUserData, dona, sender, this);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00017DFF File Offset: 0x00015FFF
		private void OnAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.OnUserAceptar(currentUserData, sender);
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onAceptar;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00017E1C File Offset: 0x0001601C
		private void OnGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.OnUserGoBack(currentUserData, sender);
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onGoBack;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00017E39 File Offset: 0x00016039
		private void OnShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.m_selectedIndices.Clear();
			this.m_selectedIndicesSet.Clear();
			this.m_selected.Clear();
			this.OnDonaShowed(currentUserData, sender);
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onShowed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00017E77 File Offset: 0x00016077
		private void OnClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.OnDonaClosed(currentUserData, sender);
			OnInteractDeTHSDonaEvent onInteractDeTHSDonaEvent = this.onShowed;
			if (onInteractDeTHSDonaEvent == null)
			{
				return;
			}
			onInteractDeTHSDonaEvent.Invoke(currentUserData, sender, this);
		}

		// Token: 0x0600068E RID: 1678
		protected abstract void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender);

		// Token: 0x0600068F RID: 1679
		protected abstract void OnItemSelectedStateChanged(THSDonaController.CurrentUserData currentUserData, bool selected, THSDonaController dona, THSDonaController.RadialItemData sender);

		// Token: 0x06000690 RID: 1680
		protected abstract void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender);

		// Token: 0x06000691 RID: 1681
		protected abstract void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender);

		// Token: 0x06000692 RID: 1682
		protected abstract void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender);

		// Token: 0x06000693 RID: 1683
		protected abstract void OnDonaClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender);

		// Token: 0x06000694 RID: 1684
		protected abstract bool PuedeDibujarIndex(int index);

		// Token: 0x06000695 RID: 1685
		protected abstract bool IndexEsGreyOut(int index);

		// Token: 0x06000696 RID: 1686
		protected abstract string TextDeIndex(int index);

		// Token: 0x06000697 RID: 1687
		protected abstract string KeyDeIndex(int index);

		// Token: 0x06000698 RID: 1688
		protected abstract void OnLoadingItems(LoaderDeTHSDona caller);

		// Token: 0x06000699 RID: 1689
		protected abstract void OnLoadedItems(LoaderDeTHSDona caller);

		// Token: 0x0400027C RID: 636
		public OnClickItemOpcionDeTHSDonaEvent onOpcionClicked = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x0400027D RID: 637
		public OnClickItemOpcionDeTHSDonaEvent onOpcionSelectionChanged = new OnClickItemOpcionDeTHSDonaEvent();

		// Token: 0x0400027E RID: 638
		public OnInteractDeTHSDonaEvent onAceptar = new OnInteractDeTHSDonaEvent();

		// Token: 0x0400027F RID: 639
		public OnInteractDeTHSDonaEvent onGoBack = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000280 RID: 640
		public OnInteractDeTHSDonaEvent onShowed = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000281 RID: 641
		public OnInteractDeTHSDonaEvent onClosed = new OnInteractDeTHSDonaEvent();

		// Token: 0x04000282 RID: 642
		[SerializeField]
		private List<int> m_selectedIndices = new List<int>();

		// Token: 0x04000283 RID: 643
		[SerializeField]
		private List<THSDonaController.RadialItemData> m_selected = new List<THSDonaController.RadialItemData>();

		// Token: 0x04000284 RID: 644
		private HashSet<int> m_selectedIndicesSet = new HashSet<int>();
	}
}
