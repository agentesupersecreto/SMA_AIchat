using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000E RID: 14
	[Obsolete("usar activables", true)]
	public class DesactivarComponentsOnConversation : OnConversationBase
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00003BB8 File Offset: 0x00001DB8
		protected void Awake()
		{
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003BE4 File Offset: 0x00001DE4
		protected override void OnConversationComienza(Transform currentActor, Transform currentConversant)
		{
			this.desactivarComponentsOn.OnComienza();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003BF1 File Offset: 0x00001DF1
		protected override void OnConversationTermina(Transform currentActor, Transform currentConversant)
		{
			this.desactivarComponentsOn.OnTermina();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003BFE File Offset: 0x00001DFE
		protected override Transform ObtenerCurrentActor()
		{
			return this.m_character.transform;
		}

		// Token: 0x0400002A RID: 42
		public DesactivarComponentsOn desactivarComponentsOn = new DesactivarComponentsOn();

		// Token: 0x0400002B RID: 43
		private Character m_character;
	}
}
