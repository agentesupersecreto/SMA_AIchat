using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x0200036C RID: 876
	public class CharacterUISetter : MonoBehaviour
	{
		// Token: 0x06001312 RID: 4882 RVA: 0x00052D73 File Offset: 0x00050F73
		protected void Awake()
		{
			base.GetComponentsInChildren<CharacterUI>(this.m_UIs);
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x00052D84 File Offset: 0x00050F84
		private void Update()
		{
			Character current = TargetChar.current;
			Character current2 = MainChar.current;
			if (this.m_currentFem != current)
			{
				for (int i = 0; i < this.m_UIs.Count; i++)
				{
					CharacterUI characterUI = this.m_UIs[i];
					if (characterUI.sexo == Sexo.femenino)
					{
						characterUI.ChangeTo(current);
					}
				}
				this.m_currentFem = current;
			}
			if (this.m_currentMale != current2)
			{
				for (int j = 0; j < this.m_UIs.Count; j++)
				{
					CharacterUI characterUI2 = this.m_UIs[j];
					if (characterUI2.sexo == Sexo.masculino)
					{
						characterUI2.ChangeTo(current2);
					}
				}
				this.m_currentMale = current2;
			}
		}

		// Token: 0x04000FFC RID: 4092
		private List<CharacterUI> m_UIs = new List<CharacterUI>();

		// Token: 0x04000FFD RID: 4093
		private Character m_currentFem;

		// Token: 0x04000FFE RID: 4094
		private Character m_currentMale;
	}
}
