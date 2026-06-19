using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020003F9 RID: 1017
	public class ModificadorDeTouchingSoundSegunConfig : ModificadorDeTouchingSound
	{
		// Token: 0x06001638 RID: 5688 RVA: 0x0005CB87 File Offset: 0x0005AD87
		protected override void OnRegistrando(EstimuloTactil toque, SonidoProductor other, ref SonidoMods mods, ref ReproductorDeSonidos.AbortarArg abortarArg, object sender)
		{
			mods.volumen *= Singleton<ConfiguracionGeneralDeAudio>.instance.skinTouch * this.calibrationDEBUG;
		}

		// Token: 0x040011A8 RID: 4520
		public float calibrationDEBUG = 1f;
	}
}
