using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI.Abstract;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x0200004E RID: 78
	public class OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoPrev : OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogo
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0000C4F5 File Offset: 0x0000A6F5
		protected override OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo tipo
		{
			get
			{
				return OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo.prev;
			}
		}
	}
}
