using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x0200039A RID: 922
	public abstract class ReactorPadreSinLogica : ReactorPadre
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool puedeReaccionarANullos
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x00057818 File Offset: 0x00055A18
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
			this.padreConfig.reaccionarPropioSiAlgunHijoReacciona = false;
			this.baseConfig.unIntentoDeReaccionPorFrame = false;
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x00004252 File Offset: 0x00002452
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			return false;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x00056790 File Offset: 0x00054990
		public sealed override bool ReactorPadrePuedeReaccionar(ReactorPadre padre, object arg, out bool negarTodos)
		{
			negarTodos = false;
			return true;
		}
	}
}
