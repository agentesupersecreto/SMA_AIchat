using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia
{
	// Token: 0x020000C3 RID: 195
	public class SimpleWallet : CustomMonobehaviour
	{
		// Token: 0x14000047 RID: 71
		// (add) Token: 0x0600076B RID: 1899 RVA: 0x00029F90 File Offset: 0x00028190
		// (remove) Token: 0x0600076C RID: 1900 RVA: 0x00029FC8 File Offset: 0x000281C8
		public event Action<string, float, string> onChanged;

		// Token: 0x0600076D RID: 1901 RVA: 0x00029FFD File Offset: 0x000281FD
		public float Current(string id)
		{
			return CharacterWallet.Current(id, this.m_wallet);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0002A00B File Offset: 0x0002820B
		public void Change(string id, float value, string senderHumanRedableName)
		{
			CharacterWallet.Change(id, value, senderHumanRedableName, this.m_wallet, this.m_historial, this);
			if (value != 0f)
			{
				Action<string, float, string> action = this.onChanged;
				if (action == null)
				{
					return;
				}
				action(id, value, senderHumanRedableName);
			}
		}

		// Token: 0x0400043E RID: 1086
		[SerializeField]
		private StringKeyFloatValueDictionary m_wallet = new StringKeyFloatValueDictionary();

		// Token: 0x0400043F RID: 1087
		[SerializeField]
		private List<CharacterWallet.Transacion> m_historial = new List<CharacterWallet.Transacion>();
	}
}
