using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias.AI
{
	// Token: 0x0200000A RID: 10
	[MemoriaRelatedBehaviour]
	public class MemoriaDeRegistroDeCambiosDeEmocionUnicos : CustomMonobehaviour
	{
		// Token: 0x06000044 RID: 68 RVA: 0x000036ED File Offset: 0x000018ED
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoria = this.GetComponentEnRoot(false);
			if (this.m_memoria == null)
			{
				throw new ArgumentNullException("m_memoria", "m_memoria null reference.");
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003720 File Offset: 0x00001920
		public void RegistrarCambioDeEmocion(ReaccionHumana reaccion, string idDeCambioUnico)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, reaccion.ToString(), idDeCambioUnico);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000373B File Offset: 0x0000193B
		public bool EstaRegistrardoCambioDeEmocion(ReaccionHumana reaccion, string idDeCambioUnico)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, reaccion.ToString(), idDeCambioUnico);
		}

		// Token: 0x04000017 RID: 23
		private MemoriaDeCharacterGeneralTemporal m_memoria;
	}
}
