using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000337 RID: 823
	[Serializable]
	public abstract class ModificadorPorCambiosEnCalculos<T> where T : struct
	{
		// Token: 0x060014B0 RID: 5296 RVA: 0x000629C6 File Offset: 0x00060BC6
		public ModificadorPorCambiosEnCalculos(Func<T, T, bool> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer", "comparer null reference.");
			}
			this.m_comparer = comparer;
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x00062A05 File Offset: 0x00060C05
		public void Init(CustomMonobehaviour owner)
		{
			this.m_firstTime = true;
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			owner.onDisabled += this.Owner_onDisabled;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00062A39 File Offset: 0x00060C39
		private void Owner_onDisabled(object obj)
		{
			this.m_firstTime = true;
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x060014B3 RID: 5299 RVA: 0x00062A42 File Offset: 0x00060C42
		public float currentMod
		{
			get
			{
				if (!this.activado)
				{
					return 1f;
				}
				return this.m_currentMod;
			}
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x00062A58 File Offset: 0x00060C58
		public void OnCheckingCalculo(T current)
		{
			this.m_checking = current;
			this.m_currentMod = ((this.m_firstTime || this.m_comparer(this.m_last, this.m_checking)) ? this.onEqualsMod : this.onChangedModV3);
			if (this.m_currentMod == 0f)
			{
				this.m_currentMod = 1E-05f;
			}
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00062AB9 File Offset: 0x00060CB9
		public void OnBarked()
		{
			this.m_last = this.m_checking;
			this.m_firstTime = false;
		}

		// Token: 0x04000EC7 RID: 3783
		public bool activado = true;

		// Token: 0x04000EC8 RID: 3784
		private Func<T, T, bool> m_comparer;

		// Token: 0x04000EC9 RID: 3785
		public float onEqualsMod = 1f;

		// Token: 0x04000ECA RID: 3786
		public float onChangedModV3 = 1.2599f;

		// Token: 0x04000ECB RID: 3787
		[NonSerialized]
		private bool m_firstTime;

		// Token: 0x04000ECC RID: 3788
		[SerializeField]
		[ReadOnlyUI]
		private T m_last;

		// Token: 0x04000ECD RID: 3789
		[SerializeField]
		[ReadOnlyUI]
		private T m_checking;

		// Token: 0x04000ECE RID: 3790
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentMod;
	}
}
