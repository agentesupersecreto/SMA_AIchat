using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Memoria
{
	// Token: 0x0200005D RID: 93
	[MemoriaRelatedBehaviour]
	public class MemoriaDeRegistroDeCanI : CustomMonobehaviour
	{
		// Token: 0x060002C2 RID: 706 RVA: 0x0000E4F6 File Offset: 0x0000C6F6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoria = this.GetComponentEnRoot(false);
			if (this.m_memoria == null)
			{
				throw new ArgumentNullException("m_memoria", "m_memoria null reference.");
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000E529 File Offset: 0x0000C729
		[Obsolete("", true)]
		public void RegistrarCaressNegada(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "caressNegada", parte.ToString());
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000E548 File Offset: 0x0000C748
		[Obsolete("", true)]
		public void BorrarCaressNegada(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase.Borrar(this.m_memoria, "caressNegada", parte.ToString());
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000E567 File Offset: 0x0000C767
		[Obsolete("", true)]
		public bool EstaRegistradaCaressNegada(ParteDelCuerpoHumano parte)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "caressNegada", parte.ToString());
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000E586 File Offset: 0x0000C786
		[Obsolete("", true)]
		public void RegistrarCaressAceptada(ParteDelCuerpoHumano parte)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "caressAceptada", parte.ToString());
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000E5A5 File Offset: 0x0000C7A5
		[Obsolete("", true)]
		public bool EstaRegistrardaCaressAceptada(ParteDelCuerpoHumano parte)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "caressAceptada", parte.ToString());
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000E5C4 File Offset: 0x0000C7C4
		[Obsolete("", true)]
		public void RegistrarCaressOffset(IEnumerable<ParteDelCuerpoHumano> partes, float offset)
		{
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				MemoriaDeCharacterBase.Registrar(this.m_memoria, "caressOffset", parteDelCuerpoHumano.ToString(), offset);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000E624 File Offset: 0x0000C824
		[Obsolete("", true)]
		public float ObtenerCaressOffsetRegistrado(IEnumerable<ParteDelCuerpoHumano> partes)
		{
			int num = 0;
			float num2 = 0f;
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				float num3 = MemoriaDeCharacterBase.LeerFloat(this.m_memoria, "caressOffset", parteDelCuerpoHumano.ToString(), -1f);
				if (num3 >= 0f)
				{
					num2 += num3;
					num++;
				}
			}
			if (num <= 0)
			{
				return -1f;
			}
			return num2 / (float)num;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		public void RegistrarEstimuloffset(IEnumerable<ParteDelCuerpoHumano> partes, TipoDeEstimulo tipoDeEstimulo, int tipoDeEstimuloEspecifico, float offset)
		{
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				MemoriaDeCharacterBase.Registrar(this.m_memoria, string.Join("_", new object[]
				{
					(int)tipoDeEstimulo,
					tipoDeEstimuloEspecifico,
					"_Offset"
				}), parteDelCuerpoHumano.ToString(), offset);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000E73C File Offset: 0x0000C93C
		public float ObtenerEstimuloOffsetRegistrado(IEnumerable<ParteDelCuerpoHumano> partes, TipoDeEstimulo tipoDeEstimulo, int tipoDeEstimuloEspecifico)
		{
			int num = 0;
			float num2 = 0f;
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				float num3 = MemoriaDeCharacterBase.LeerFloat(this.m_memoria, string.Join("_", new object[]
				{
					(int)tipoDeEstimulo,
					tipoDeEstimuloEspecifico,
					"_Offset"
				}), parteDelCuerpoHumano.ToString(), -1f);
				if (num3 >= 0f)
				{
					num2 += num3;
					num++;
				}
			}
			if (num <= 0)
			{
				return -1f;
			}
			return num2 / (float)num;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000E7F0 File Offset: 0x0000C9F0
		[Obsolete("", true)]
		public void RegistrarCaressPreguntada(ParteDelCuerpoHumano parte)
		{
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000E7F2 File Offset: 0x0000C9F2
		[Obsolete("", true)]
		public bool EstaRegistrardaCaressPreguntada(ParteDelCuerpoHumano parte)
		{
			throw new NotSupportedException();
		}

		// Token: 0x04000128 RID: 296
		[Obsolete("", true)]
		private const string caressOffset = "caressOffset";

		// Token: 0x04000129 RID: 297
		[Obsolete("", true)]
		private const string caressNegada = "caressNegada";

		// Token: 0x0400012A RID: 298
		[Obsolete("", true)]
		private const string caressAceptada = "caressAceptada";

		// Token: 0x0400012B RID: 299
		private const string Offset_KEY = "_Offset";

		// Token: 0x0400012C RID: 300
		private const string Negada_KEY = "_Negada";

		// Token: 0x0400012D RID: 301
		private const string Aceptada_KEY = "_Aceptada";

		// Token: 0x0400012E RID: 302
		private MemoriaDeCharacterGeneralTemporal m_memoria;
	}
}
