using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000DF RID: 223
	public abstract class GenericOpcionesDeTHSDonaDeEnumerable<TEnum> : GenericOpcionesDeTHSDonaDeColleccion where TEnum : Enum
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x00017F0A File Offset: 0x0001610A
		public static IReadOnlyList<TEnum> valores
		{
			get
			{
				return GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Valores;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x00017F11 File Offset: 0x00016111
		public static IReadOnlyList<int> intValores
		{
			get
			{
				return GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_IntValores;
			}
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00017F18 File Offset: 0x00016118
		static GenericOpcionesDeTHSDonaDeEnumerable()
		{
			foreach (object obj in typeof(TEnum).GetEnumValoresObject())
			{
				TEnum tenum = (TEnum)((object)obj);
				GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Valores.Add(tenum);
			}
			foreach (int num in typeof(TEnum).GetEnumValoresInt())
			{
				GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_IntValores.Add(num);
			}
			foreach (string text in typeof(TEnum).GetEnumValoresNombres())
			{
				GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Nombres.Add(text);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x00018038 File Offset: 0x00016238
		public override int count
		{
			get
			{
				return GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Valores.Count;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x00018044 File Offset: 0x00016244
		public IReadOnlyList<TEnum> selectedEnums
		{
			get
			{
				return this.m_selectedEnums;
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001804C File Offset: 0x0001624C
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			this.m_selectedEnums.Clear();
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001805C File Offset: 0x0001625C
		protected override void OnItemSelectedStateChanged(THSDonaController.CurrentUserData currentUserData, bool isSelected, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			this.m_selectedEnums.Clear();
			for (int i = 0; i < base.selected.Count; i++)
			{
				THSDonaController.RadialItemData radialItemData = base.selected[i];
				this.m_selectedEnums.Add(GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Valores[radialItemData.id]);
			}
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000180B2 File Offset: 0x000162B2
		protected override bool PuedeDibujarIndex(int index)
		{
			return true;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x000180B5 File Offset: 0x000162B5
		protected override bool IndexEsGreyOut(int index)
		{
			return false;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000180B8 File Offset: 0x000162B8
		protected override string TextDeIndex(int index)
		{
			TEnum tenum = GenericOpcionesDeTHSDonaDeEnumerable<TEnum>.m_Valores[index];
			return tenum.ToString();
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x000180DE File Offset: 0x000162DE
		protected override string KeyDeIndex(int index)
		{
			return this.TextDeIndex(index);
		}

		// Token: 0x04000285 RID: 645
		private static List<int> m_IntValores = new List<int>();

		// Token: 0x04000286 RID: 646
		private static List<string> m_Nombres = new List<string>();

		// Token: 0x04000287 RID: 647
		private static List<TEnum> m_Valores = new List<TEnum>();

		// Token: 0x04000288 RID: 648
		[SerializeField]
		private List<TEnum> m_selectedEnums = new List<TEnum>();
	}
}
