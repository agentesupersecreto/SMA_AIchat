using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x02000005 RID: 5
	[RequireComponent(typeof(PanelUsable))]
	public class UsePanelOnTAB : CustomMonobehaviour
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002520 File Offset: 0x00000720
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PanelUsable = base.GetComponent<PanelUsable>();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002534 File Offset: 0x00000734
		private void Update()
		{
			if (!Singleton<PlayerInputProxy>.instance.virtualesUI.tab)
			{
				return;
			}
			if (!this.m_PanelUsable.PanelOfModel.isShowing)
			{
				PanelUsable panelUsable = this.m_PanelUsable;
				MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
				Transform transform;
				if (current == null)
				{
					transform = null;
				}
				else
				{
					Character character = current.character;
					if (character == null)
					{
						transform = null;
					}
					else
					{
						Animator bodyAnimator = character.bodyAnimator;
						transform = ((bodyAnimator != null) ? bodyAnimator.transform : null);
					}
				}
				panelUsable.OnUsado(transform);
				return;
			}
			CerrableAttribute cerrableAttribute = Attribute.GetCustomAttribute(this.m_PanelUsable.PanelOfModel.GetLastDrawModel().GetType(), typeof(CerrableAttribute)) as CerrableAttribute;
			CerrableAttribute.Accion valueOrDefault = ((cerrableAttribute != null) ? new CerrableAttribute.Accion?(cerrableAttribute.accion) : null).GetValueOrDefault(CerrableAttribute.Accion.destruir);
			if (valueOrDefault == CerrableAttribute.Accion.destruir)
			{
				this.m_PanelUsable.PanelOfModel.Clear();
				return;
			}
			if (valueOrDefault != CerrableAttribute.Accion.ocultar)
			{
				throw new ArgumentOutOfRangeException(valueOrDefault.ToString());
			}
			this.m_PanelUsable.PanelOfModel.Hide();
		}

		// Token: 0x0400000B RID: 11
		private PanelUsable m_PanelUsable;
	}
}
