using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E0 RID: 224
	public static class IInteraccionesDeCharacterEXT
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x00026448 File Offset: 0x00024648
		public static bool Conflictuan(this IInteraccion a, IInteraccion b)
		{
			IReadOnlyList<InteraccionEffectorParInfo> effectorsInteractions = a.datosDeParesDeEfecctors.effectorsInteractions;
			IReadOnlyList<InteraccionEffectorParInfo> effectorsInteractions2 = a.datosDeParesDeEfecctors.effectorsInteractions;
			bool conflicto = false;
			effectorsInteractions.ColisionarContraReadOnly(effectorsInteractions2, delegate(InteraccionEffectorParInfo a, InteraccionEffectorParInfo b)
			{
				conflicto |= a.activado && b.activado && a.fullBodyBipedEffector == b.fullBodyBipedEffector;
			});
			return conflicto;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00026494 File Offset: 0x00024694
		public static bool ConflictuaConAlgunaEjecutandose(this IInteraccionesDeCharacter inters, IInteraccion nonExecuting)
		{
			bool flag;
			try
			{
				inters.GetEjecutandose(nonExecuting.interactionLayer, IInteraccionesDeCharacterEXT.m_ejecutandoseTEMP);
				for (int i = 0; i < IInteraccionesDeCharacterEXT.m_ejecutandoseTEMP.Count; i++)
				{
					InteraccionDeCharacter interaccionDeCharacter = IInteraccionesDeCharacterEXT.m_ejecutandoseTEMP[i];
					if (!(((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null) == null) && nonExecuting.Conflictuan(interaccionDeCharacter.instancia))
					{
						return true;
					}
				}
				flag = false;
			}
			finally
			{
				IInteraccionesDeCharacterEXT.m_ejecutandoseTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0400057A RID: 1402
		private static IList<InteraccionDeCharacter> m_ejecutandoseTEMP = new List<InteraccionDeCharacter>();
	}
}
