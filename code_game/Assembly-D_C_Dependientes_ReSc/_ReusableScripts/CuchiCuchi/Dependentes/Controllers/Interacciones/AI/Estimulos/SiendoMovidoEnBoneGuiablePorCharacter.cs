using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E5 RID: 485
	public abstract class SiendoMovidoEnBoneGuiablePorCharacter : SiendoMovidoEnBonesPorCharacter<BoneGuiable>
	{
		// Token: 0x06000B9D RID: 2973 RVA: 0x00038444 File Offset: 0x00036644
		protected SiendoMovidoEnBoneGuiablePorCharacter(BoneGuiable estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0003844E File Offset: 0x0003664E
		protected override float CalculeVelocidadRelativaEmulada()
		{
			return base.estimulado.CalculeVelocidadRelativaEmulada();
		}
	}
}
