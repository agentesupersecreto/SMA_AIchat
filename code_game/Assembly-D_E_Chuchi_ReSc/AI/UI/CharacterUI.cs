using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000363 RID: 867
	public abstract class CharacterUI : CustomMonobehaviour
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060012F6 RID: 4854 RVA: 0x000522E0 File Offset: 0x000504E0
		public Character current
		{
			get
			{
				return this.m_current;
			}
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000522E8 File Offset: 0x000504E8
		public void ChangeTo(Character character)
		{
			this.m_character = character;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000522F1 File Offset: 0x000504F1
		protected virtual void LateUpdate()
		{
			if (this.m_character != this.m_current)
			{
				if (this.m_character == null)
				{
					this.Clear();
					return;
				}
				this.Clear();
				this.Change();
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x00052327 File Offset: 0x00050527
		private void Clear()
		{
			this.m_current = null;
			this.OnCleared();
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00052336 File Offset: 0x00050536
		private void Change()
		{
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_current = this.m_character;
			this.OnChanged();
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnCleared()
		{
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnChanged()
		{
		}

		// Token: 0x04000FD0 RID: 4048
		public Sexo sexo;

		// Token: 0x04000FD1 RID: 4049
		private Character m_character;

		// Token: 0x04000FD2 RID: 4050
		[SerializeField]
		[ReadOnlyUI]
		private Character m_current;
	}
}
