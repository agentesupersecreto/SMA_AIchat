using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000B RID: 11
	public class CharacterPuedeConversar : CustomMonobehaviour, ICharacterPuedeConversar
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002F60 File Offset: 0x00001160
		public ModificableDeBool puedeConversarModificable
		{
			get
			{
				return this.m_puedeConversarModificable;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002F68 File Offset: 0x00001168
		public bool puedeConversar
		{
			get
			{
				return this.m_puedeConversarModificable.And(true);
			}
		}

		// Token: 0x0400001A RID: 26
		[SerializeField]
		private ModificableDeBool m_puedeConversarModificable = new ModificableDeBool(true);
	}
}
