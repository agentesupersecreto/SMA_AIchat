using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa
{
	// Token: 0x02000380 RID: 896
	[RequireComponent(typeof(GuiaDeRopaInteractable))]
	public class EstimulosDeGuiaDeRopaInteractable : CustomMonobehaviour
	{
		// Token: 0x0600136C RID: 4972 RVA: 0x00054EAC File Offset: 0x000530AC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_GuiaDeRopaInteractable = base.GetComponent<GuiaDeRopaInteractable>();
			this.m_EstimulosPorQuitarPrendasDeRopa = this.GetComponentEnRoot(false);
			this.m_own = this.GetComponentEnRoot(false);
			if (this.m_EstimulosPorQuitarPrendasDeRopa == null)
			{
				throw new ArgumentNullException("m_EstimulosPorQuitarPrendasDeRopa", "m_EstimulosPorQuitarPrendasDeRopa null reference.");
			}
			if (this.m_own == null)
			{
				throw new ArgumentNullException("m_own", "m_own null reference.");
			}
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x00054F21 File Offset: 0x00053121
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_GuiaDeRopaInteractable.piezaChanged += this.M_GuiaDeRopaInteractable_piezaChanged;
			this.m_GuiaDeRopaInteractable.weigthChanged += this.M_GuiaDeRopaInteractable_weigthChanged;
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x00054F58 File Offset: 0x00053158
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_GuiaDeRopaInteractable != null)
			{
				this.m_GuiaDeRopaInteractable.piezaChanged -= this.M_GuiaDeRopaInteractable_piezaChanged;
				this.m_GuiaDeRopaInteractable.weigthChanged -= this.M_GuiaDeRopaInteractable_weigthChanged;
			}
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x00054FA8 File Offset: 0x000531A8
		private void M_GuiaDeRopaInteractable_weigthChanged(float last, float current, bool siendoAgarrada, GuiaVisualInteractable sender)
		{
			GuiaDeRopaInteractable guiaDeRopaInteractable = (GuiaDeRopaInteractable)sender;
			bool flag;
			if (sender == null)
			{
				flag = null != null;
			}
			else
			{
				AgarranteObjeto currentAgarradoPor = sender.currentAgarradoPor;
				flag = ((currentAgarradoPor != null) ? currentAgarradoPor.character : null) != null;
			}
			if (!flag)
			{
				return;
			}
			if (this.m_coolDownDeGeneracionDeEstimulo.isOn)
			{
				return;
			}
			if (!siendoAgarrada)
			{
				return;
			}
			if (last >= 0.1f || current < 0.1f)
			{
				return;
			}
			SiendoDesvestidoFrameData siendoDesvestidoFrameData = new SiendoDesvestidoFrameData(sender.currentAgarradoPor.character as Character, guiaDeRopaInteractable.interactableCon.dataDeRopa.stringId, this.m_own, guiaDeRopaInteractable.interactableCon, guiaDeRopaInteractable.currentInteraccionExponiendoFlags, true, true);
			this.m_EstimulosPorQuitarPrendasDeRopa.conjuntoDeRopaLoader.InyectData(ref siendoDesvestidoFrameData);
			this.m_coolDownDeGeneracionDeEstimulo.ApplyNext(2f);
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x00055064 File Offset: 0x00053264
		private void M_GuiaDeRopaInteractable_piezaChanged(AgarranteObjeto agarradoPor, MapaDeRopa.RopaData.Interacciones interaccion, PiezaDeRopaBase siendoRemovida, GuiaDeRopaInteractable sender)
		{
			if (((agarradoPor != null) ? agarradoPor.character : null) == null)
			{
				return;
			}
			SiendoDesvestidoFrameData siendoDesvestidoFrameData = new SiendoDesvestidoFrameData(agarradoPor.character as Character, siendoRemovida.dataDeRopa.stringId, this.m_own, siendoRemovida, sender.currentInteraccionExponiendoFlags, false, true);
			this.m_EstimulosPorQuitarPrendasDeRopa.conjuntoDeRopaLoader.InyectData(ref siendoDesvestidoFrameData);
		}

		// Token: 0x0400104C RID: 4172
		private GuiaDeRopaInteractable m_GuiaDeRopaInteractable;

		// Token: 0x0400104D RID: 4173
		private CoolDown m_coolDownDeGeneracionDeEstimulo = new CoolDown();

		// Token: 0x0400104E RID: 4174
		private EstimulosPorQuitarPrendasDeRopa m_EstimulosPorQuitarPrendasDeRopa;

		// Token: 0x0400104F RID: 4175
		private Character m_own;
	}
}
