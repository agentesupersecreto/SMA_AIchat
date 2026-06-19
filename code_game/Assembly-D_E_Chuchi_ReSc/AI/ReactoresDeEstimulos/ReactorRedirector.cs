using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003AE RID: 942
	public sealed class ReactorRedirector : ReactorSegundario
	{
		// Token: 0x060014A8 RID: 5288 RVA: 0x00058C76 File Offset: 0x00056E76
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0f;
			this.baseConfig.probabilidadPorSegundo = 100f;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x00056790 File Offset: 0x00054990
		public override bool ReactorPadrePuedeReaccionar(ReactorPadre padre, object arg, out bool negarTodos)
		{
			negarTodos = false;
			return true;
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x00058C9E File Offset: 0x00056E9E
		protected override bool ArgumentoEsValido(object arg)
		{
			return this.target != null;
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificador(object arg)
		{
			return 1f;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float ProbabilidadPorSegundoModificador(object arg)
		{
			return 1f;
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x00058CAC File Offset: 0x00056EAC
		protected override bool ReaccionarArgumento(object arg)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x00058CB4 File Offset: 0x00056EB4
		public override bool Reaccionar(object arg)
		{
			bool flag = false;
			this.OnArgumentoReaccionando(arg);
			bool flag2;
			try
			{
				if (base.PuedeReaccionar(arg))
				{
					flag = this.target.Reaccionar(arg);
					flag2 = flag;
				}
				else
				{
					flag2 = flag;
				}
			}
			finally
			{
				this.OnArgumentoReaccionado(arg, flag);
			}
			return flag2;
		}

		// Token: 0x040010DE RID: 4318
		[Header("Redireccionando A:")]
		public ReactorSegundario target;
	}
}
