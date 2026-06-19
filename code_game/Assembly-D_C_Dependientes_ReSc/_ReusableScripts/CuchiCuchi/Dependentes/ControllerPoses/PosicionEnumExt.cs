using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses
{
	// Token: 0x02000212 RID: 530
	public static class PosicionEnumExt
	{
		// Token: 0x06000D5D RID: 3421 RVA: 0x0003BFA5 File Offset: 0x0003A1A5
		[Obsolete]
		public static TipoDePose Parse(this Posicion pos)
		{
			switch (pos)
			{
			case Posicion.ninguna:
				return TipoDePose.dePieRigida;
			case Posicion.doggyTesting:
			case Posicion.doggyManosSuelo:
				return TipoDePose.doggy_ApoyoManosRodillas;
			case Posicion.dePieManosLibres:
				return TipoDePose.dePieRigida;
			case Posicion.sentadaManosLibres:
				return TipoDePose.sentadaRigida;
			default:
				throw new ArgumentOutOfRangeException(pos.ToString());
			}
		}
	}
}
