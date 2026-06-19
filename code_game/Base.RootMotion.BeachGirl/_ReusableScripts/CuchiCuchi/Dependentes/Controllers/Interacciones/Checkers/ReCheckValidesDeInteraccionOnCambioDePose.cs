using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers
{
	// Token: 0x020000F7 RID: 247
	[RequireComponent(typeof(IInteraccionesDeCharacter))]
	public class ReCheckValidesDeInteraccionOnCambioDePose : CustomMonobehaviour
	{
		// Token: 0x0600093B RID: 2363 RVA: 0x0002A13C File Offset: 0x0002833C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_AnimController = this.GetComponentEnRoot(false);
			this.m_IInteraccionesDeCharacter = base.GetComponent<IInteraccionesDeCharacter>();
			if (this.m_AnimController == null)
			{
				throw new ArgumentNullException("m_AnimController", "m_AnimController null reference.");
			}
			if (this.m_IInteraccionesDeCharacter == null)
			{
				throw new ArgumentNullException("m_IInteraccionesDeCharacter", "m_IInteraccionesDeCharacter null reference.");
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0002A19E File Offset: 0x0002839E
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_AnimController.poseChanged += this.M_AnimController_poseChanged;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0002A1BD File Offset: 0x000283BD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_AnimController != null)
			{
				this.m_AnimController.poseChanged -= this.M_AnimController_poseChanged;
			}
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0002A1EC File Offset: 0x000283EC
		private void M_AnimController_poseChanged(AnimController obj)
		{
			for (int i = 0; i < this.m_IInteraccionesDeCharacter.interaccionesBases.Count; i++)
			{
				InteraccionDeCharacter interaccionDeCharacter = this.m_IInteraccionesDeCharacter.interaccionesBases[i];
				if ((interaccionDeCharacter.instancia.ejecutandose || interaccionDeCharacter.instancia.algunaEstaEjecutandose) && !this.m_IInteraccionesDeCharacter.EsValidaParaCurrentAnimControllerBase(interaccionDeCharacter))
				{
					interaccionDeCharacter.instancia.Detener(false);
				}
			}
		}

		// Token: 0x040005C6 RID: 1478
		private AnimController m_AnimController;

		// Token: 0x040005C7 RID: 1479
		private IInteraccionesDeCharacter m_IInteraccionesDeCharacter;
	}
}
