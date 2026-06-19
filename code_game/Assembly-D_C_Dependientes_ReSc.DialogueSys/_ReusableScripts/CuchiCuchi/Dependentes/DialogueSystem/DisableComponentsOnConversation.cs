using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000F RID: 15
	[Obsolete("usar activables", true)]
	public sealed class DisableComponentsOnConversation : OnConversationBase
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00003C1E File Offset: 0x00001E1E
		protected override Transform ObtenerCurrentActor()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003C25 File Offset: 0x00001E25
		protected override void OnConversationComienza(Transform currentActor, Transform currentConversant)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003C2C File Offset: 0x00001E2C
		protected override void OnConversationTermina(Transform currentActor, Transform currentConversant)
		{
			throw new NotImplementedException();
		}
	}
}
