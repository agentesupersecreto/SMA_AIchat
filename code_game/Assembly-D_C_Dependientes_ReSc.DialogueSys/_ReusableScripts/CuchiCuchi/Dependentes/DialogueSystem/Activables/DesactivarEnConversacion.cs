using System;
using Assets._ReusableScripts.Miscellaneous.Activables;
using PixelCrushers.DialogueSystem;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Activables
{
	// Token: 0x02000075 RID: 117
	public class DesactivarEnConversacion : ActivarEn
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x00014AD2 File Offset: 0x00012CD2
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.invertir = true;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00014AE1 File Offset: 0x00012CE1
		protected override bool PuedeActivar()
		{
			return DialogueManager.IsConversationActive;
		}
	}
}
