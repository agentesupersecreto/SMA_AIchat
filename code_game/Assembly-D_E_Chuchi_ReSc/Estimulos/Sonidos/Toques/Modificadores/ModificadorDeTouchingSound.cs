using System;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B1 RID: 689
	[RequireComponent(typeof(IReproductorDeSonidoDeToques))]
	public abstract class ModificadorDeTouchingSound : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000F7D RID: 3965 RVA: 0x00046DA0 File Offset: 0x00044FA0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Registrandor = base.GetComponent<IReproductorDeSonidoDeToques>();
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00046DB4 File Offset: 0x00044FB4
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Registrandor.registrandoToque += this.onRegistrando;
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00046DD3 File Offset: 0x00044FD3
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Registrandor != null)
			{
				this.m_Registrandor.registrandoToque -= this.onRegistrando;
			}
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00046DFB File Offset: 0x00044FFB
		private void onRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			this.OnRegistrando(toque, other, ref mods, ref abortarArg, sender);
			mods.volumen *= this.volomenModificadorGeneral;
			mods.pitch *= this.pitchModificadorGeneral;
		}

		// Token: 0x06000F81 RID: 3969
		protected abstract void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender);

		// Token: 0x06000F82 RID: 3970 RVA: 0x00046E2C File Offset: 0x0004502C
		public static float LerpAlMedio(float valueToMin, float valueToMedio, float valueToMax, float min, float medio, float max, float outPower, float inPower, float currentValue)
		{
			float num = MathfExtension.InverseLerpConMedio(valueToMin, valueToMedio, valueToMax, currentValue);
			num = num.OutPow(outPower);
			num = num.InPow(inPower);
			return MathfExtension.LerpConMedio(min, medio, max, num);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00046E64 File Offset: 0x00045064
		public static float Lerp(float valueToMin, float valueToMax, float min, float max, float outPower, float inPower, float currentValue)
		{
			float num = Mathf.InverseLerp(valueToMin, valueToMax, currentValue);
			num = num.OutPow(outPower);
			num = num.InPow(inPower);
			return Mathf.Lerp(min, max, num);
		}

		// Token: 0x04000CD4 RID: 3284
		private IReproductorDeSonidoDeToques m_Registrandor;

		// Token: 0x04000CD5 RID: 3285
		[Range(0f, 1f)]
		public float volomenModificadorGeneral = 1f;

		// Token: 0x04000CD6 RID: 3286
		[Range(0f, 1f)]
		public float pitchModificadorGeneral = 1f;
	}
}
