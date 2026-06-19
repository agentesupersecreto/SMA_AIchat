using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E1 RID: 225
	public static class IInteraccionesDeCharacterFemeninoEXT
	{
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x00026528 File Offset: 0x00024728
		public static int maxPriID
		{
			get
			{
				if (IInteraccionesDeCharacterFemeninoEXT.m_maxPriID == null)
				{
					IInteraccionesDeCharacterFemeninoEXT.m_maxPriID = new int?(typeof(InteraccionPrimariaName).MaxEnumValue());
				}
				return IInteraccionesDeCharacterFemeninoEXT.m_maxPriID.Value;
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00026559 File Offset: 0x00024759
		public static int GetInteractionID(this InteraccionSegundariaName segundaria)
		{
			return (int)(IInteraccionesDeCharacterFemeninoEXT.maxPriID + 1 + segundaria);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00026564 File Offset: 0x00024764
		public static int GetInteractionID(this InteraccionPrimariaName pri)
		{
			return (int)pri;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00026567 File Offset: 0x00024767
		public static InteraccionSegundariaName GetInteractionSegundariaName(this int segundariaID)
		{
			return (InteraccionSegundariaName)(segundariaID - 1 - IInteraccionesDeCharacterFemeninoEXT.maxPriID);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00026572 File Offset: 0x00024772
		public static InteraccionPrimariaName GetInteractionPrimariaName(this int priID)
		{
			return (InteraccionPrimariaName)priID;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00026578 File Offset: 0x00024778
		public static InteraccionPrimariaName ObtenerCurrentCustom(this IInteraccionesDeCharacterFemenino interacciones, out bool ejecutandose)
		{
			InteraccionPrimariaName interaccionPrimariaName;
			try
			{
				interacciones.ObtenerEjecutandosePrimaria(IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose);
				for (int i = 0; i < IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose.Count; i++)
				{
					InteraccionDeCharacter interaccionDeCharacter = IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose[i];
					bool flag = interaccionDeCharacter.id == InteraccionPrimariaName.customA.GetInteractionID();
					bool flag2 = interaccionDeCharacter.id == InteraccionPrimariaName.customB.GetInteractionID();
					if (flag || flag2)
					{
						if (flag)
						{
							ejecutandose = true;
							return InteraccionPrimariaName.customA;
						}
						if (flag2)
						{
							ejecutandose = true;
							return InteraccionPrimariaName.customB;
						}
					}
				}
				ejecutandose = false;
				interaccionPrimariaName = InteraccionPrimariaName.customA;
			}
			finally
			{
				IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose.Clear();
			}
			return interaccionPrimariaName;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00026610 File Offset: 0x00024810
		public static InteraccionPrimariaName ObtenerNextCustom(this IInteraccionesDeCharacterFemenino interacciones)
		{
			InteraccionPrimariaName interaccionPrimariaName;
			bool flag;
			interacciones.ObtenerNextCustom(out interaccionPrimariaName, out flag);
			return interaccionPrimariaName;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00026628 File Offset: 0x00024828
		public static void ObtenerNextCustom(this IInteraccionesDeCharacterFemenino interacciones, out InteraccionPrimariaName nextCustom, out bool puedeUsarseTransicion)
		{
			try
			{
				interacciones.ObtenerEjecutandosePrimaria(IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose);
				InteraccionPrimariaName? interaccionPrimariaName = null;
				for (int i = IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose.Count - 1; i >= 0; i--)
				{
					InteraccionDeCharacter interaccionDeCharacter = IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose[i];
					bool flag = interaccionDeCharacter.id == InteraccionPrimariaName.customA.GetInteractionID();
					bool flag2 = interaccionDeCharacter.id == InteraccionPrimariaName.customB.GetInteractionID();
					if (flag || flag2)
					{
						if (flag)
						{
							interaccionPrimariaName = new InteraccionPrimariaName?(InteraccionPrimariaName.customA);
							break;
						}
						if (flag2)
						{
							interaccionPrimariaName = new InteraccionPrimariaName?(InteraccionPrimariaName.customB);
							break;
						}
					}
				}
				if (interaccionPrimariaName == null)
				{
					puedeUsarseTransicion = false;
					nextCustom = InteraccionPrimariaName.customA;
				}
				else if (interaccionPrimariaName.Value == InteraccionPrimariaName.customA)
				{
					puedeUsarseTransicion = true;
					nextCustom = InteraccionPrimariaName.customB;
				}
				else
				{
					if (interaccionPrimariaName.Value != InteraccionPrimariaName.customB)
					{
						throw new ArgumentOutOfRangeException();
					}
					puedeUsarseTransicion = true;
					nextCustom = InteraccionPrimariaName.customA;
				}
			}
			finally
			{
				IInteraccionesDeCharacterFemeninoEXT.m_TempResultEjecutandose.Clear();
			}
		}

		// Token: 0x0400057B RID: 1403
		private static int? m_maxPriID;

		// Token: 0x0400057C RID: 1404
		private static List<InteraccionDeCharacter> m_TempResultEjecutandose = new List<InteraccionDeCharacter>();
	}
}
