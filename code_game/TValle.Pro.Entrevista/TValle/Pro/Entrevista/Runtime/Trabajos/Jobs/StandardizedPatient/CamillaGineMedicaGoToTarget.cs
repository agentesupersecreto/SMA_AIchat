using System;
using Assets.TValle.BeachGirl.Runtime.GoTo;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000063 RID: 99
	public class CamillaGineMedicaGoToTarget : SillaGoToTarget
	{
		// Token: 0x0600049F RID: 1183 RVA: 0x0001BA46 File Offset: 0x00019C46
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CamillaMedica = base.GetComponentInParent<CamillaGineMedica>();
			if (this.m_CamillaMedica == null)
			{
				throw new ArgumentNullException("m_CamillaMedica", "m_CamillaMedica null reference.");
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001BA78 File Offset: 0x00019C78
		protected override void OnUsing(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character)
		{
			float num = base.transform.lossyScale.Escala() / character.escala;
			float num2 = MathfExtension.InverseLerpConMedio(0.7099046f, 1f, 1.428566f, num);
			Vector3 vector = MathfExtension.LerpConMedio(CamillaGineMedicaGoToTarget.medLocalPosToCenter, CamillaGineMedicaGoToTarget.altaLocalPosToCenter, CamillaGineMedicaGoToTarget.muyAltaLocalPosToCenter, num2, 1f, 1f);
			this.m_SillaGenerica.ForceLocalPivotPosition(new Vector3?(this.m_SillaGenerica.pivot.InverseTransformPoint(this.m_CamillaMedica.transform.TransformPoint(vector))));
			base.OnUsing(navegable, teleportable, character);
		}

		// Token: 0x04000289 RID: 649
		private const float medCamillaScale = 0.7099046f;

		// Token: 0x0400028A RID: 650
		private static readonly Vector3 medLocalPosToCenter = new Vector3(0f, 0f, 1.131138f);

		// Token: 0x0400028B RID: 651
		private const float altaCamillaScale = 1f;

		// Token: 0x0400028C RID: 652
		private static readonly Vector3 altaLocalPosToCenter = new Vector3(0f, 0f, 1.014f);

		// Token: 0x0400028D RID: 653
		private const float muyAltaCamillaScale = 1.428566f;

		// Token: 0x0400028E RID: 654
		private static readonly Vector3 muyAltaLocalPosToCenter = new Vector3(0f, 0f, 0.9275035f);

		// Token: 0x0400028F RID: 655
		private CamillaGineMedica m_CamillaMedica;
	}
}
