using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Memoria
{
	// Token: 0x020001DC RID: 476
	[MemoriaRelatedBehaviour]
	public class MemoriaDeRegistroDePeticionesDeGuiarPose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000B5F RID: 2911 RVA: 0x00037C36 File Offset: 0x00035E36
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoria = this.GetComponentEnRoot(false);
			if (this.m_memoria == null)
			{
				throw new ArgumentNullException("m_memoria", "m_memoria null reference.");
			}
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00037C6C File Offset: 0x00035E6C
		public void RegistrarGuiarPoseNegadaPorParte(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesGuiarPoseNegadaPorParte";
			int num = (int)parte;
			MemoriaDeCharacterBase.RegistrarCantidadPlus(memoria, text, num.ToString());
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00037C94 File Offset: 0x00035E94
		public void BorrarGuiarPoseNegadaPorParte(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesGuiarPoseNegadaPorParte";
			int num = (int)parte;
			MemoriaDeCharacterBase.Borrar(memoria, text, num.ToString());
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x00037CBC File Offset: 0x00035EBC
		public bool EstaRegistrardaGuiarPoseNegadaPorParte(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesGuiarPoseNegadaPorParte";
			int num = (int)parte;
			return MemoriaDeCharacterBase.CantidadFueRegistrada(memoria, text, num.ToString());
		}

		// Token: 0x04000888 RID: 2184
		private const string guiarPoseNegadaPorParte = "PeticionesGuiarPoseNegadaPorParte";

		// Token: 0x04000889 RID: 2185
		private MemoriaDeCharacterGeneralTemporal m_memoria;
	}
}
