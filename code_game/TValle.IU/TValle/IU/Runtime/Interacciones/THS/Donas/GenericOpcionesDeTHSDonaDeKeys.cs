using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E0 RID: 224
	public abstract class GenericOpcionesDeTHSDonaDeKeys<TKey> : GenericOpcionesDeTHSDonaDeColleccion where TKey : IEquatable<TKey>
	{
		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x000180FA File Offset: 0x000162FA
		public IReadOnlyList<TKey> selectedKeys
		{
			get
			{
				return this.m_selectedKeys;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x00018102 File Offset: 0x00016302
		public override int count
		{
			get
			{
				return this.m_dibujando.Count;
			}
		}

		// Token: 0x060006A9 RID: 1705
		protected abstract void LoadKeys(HashSetList<TKey> resultado);

		// Token: 0x060006AA RID: 1706
		protected abstract string TextDeKey(TKey key);

		// Token: 0x060006AB RID: 1707
		protected abstract TKey KeyDeItemKey(string key, int index);

		// Token: 0x060006AC RID: 1708 RVA: 0x0001810F File Offset: 0x0001630F
		protected sealed override void OnLoadingItems(LoaderDeTHSDona caller)
		{
			this.LoadKeys(this.m_dibujando);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001811D File Offset: 0x0001631D
		protected override void OnDonaClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.m_dibujando.Clear();
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001812A File Offset: 0x0001632A
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.m_selectedKeys.Clear();
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00018138 File Offset: 0x00016338
		protected override void OnItemSelectedStateChanged(THSDonaController.CurrentUserData currentUserData, bool isSelected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			this.m_selectedKeys.Clear();
			for (int i = 0; i < base.selected.Count; i++)
			{
				THSDonaController.RadialItemData radialItemData = base.selected[i];
				this.m_selectedKeys.Add(this.KeyDeItemKey(radialItemData.key, radialItemData.id));
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00018190 File Offset: 0x00016390
		protected sealed override bool PuedeDibujarIndex(int index)
		{
			return true;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00018193 File Offset: 0x00016393
		protected override bool IndexEsGreyOut(int index)
		{
			return false;
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00018196 File Offset: 0x00016396
		protected sealed override string TextDeIndex(int index)
		{
			return this.TextDeKey(this.m_dibujando[index]);
		}

		// Token: 0x04000289 RID: 649
		[SerializeField]
		private List<TKey> m_selectedKeys = new List<TKey>();

		// Token: 0x0400028A RID: 650
		protected HashSetList<TKey> m_dibujando = new HashSetList<TKey>();
	}
}
