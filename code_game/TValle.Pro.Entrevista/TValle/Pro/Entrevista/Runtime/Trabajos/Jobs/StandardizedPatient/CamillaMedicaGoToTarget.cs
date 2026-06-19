using System;
using Assets.TValle.BeachGirl.Runtime.GoTo;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000066 RID: 102
	public class CamillaMedicaGoToTarget : SillaGoToTarget
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x0001BD82 File Offset: 0x00019F82
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CamillaMedica = base.GetComponentInParent<CamillaMedica>();
			if (this.m_CamillaMedica == null)
			{
				throw new ArgumentNullException("m_CamillaMedica", "m_CamillaMedica null reference.");
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001BDB4 File Offset: 0x00019FB4
		protected override void OnUsing(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character)
		{
			float num = base.transform.lossyScale.Escala() / character.escala;
			float num2 = MathfExtension.InverseLerpConMedio(0.7099046f, 1f, 1.428566f, num);
			Vector3 vector = MathfExtension.LerpConMedio(CamillaMedicaGoToTarget.medLocalPosToCenter, CamillaMedicaGoToTarget.altaLocalPosToCenter, CamillaMedicaGoToTarget.muyAltaLocalPosToCenter, num2, 1f, 1f);
			Vector3 vector2 = new Vector3(vector.x, vector.y, 0f);
			Vector3 vector3 = this.m_CamillaMedica.transform.TransformPoint(vector2);
			this.m_SillaGenerica.pivot.position = vector3;
			this.m_SillaGenerica.ForceLocalPivotPosition(new Vector3?(this.m_SillaGenerica.pivot.InverseTransformPoint(this.m_CamillaMedica.transform.TransformPoint(vector))));
			base.OnUsing(navegable, teleportable, character);
		}

		// Token: 0x04000294 RID: 660
		private const float medCamillaScale = 0.7099046f;

		// Token: 0x04000295 RID: 661
		private static readonly Vector3 medLocalPosToCenter = new Vector3(0.4451303f, 0f, 0.483164f);

		// Token: 0x04000296 RID: 662
		private const float altaCamillaScale = 1f;

		// Token: 0x04000297 RID: 663
		private static readonly Vector3 altaLocalPosToCenter = new Vector3(0.1450001f, 0f, 0.4450002f);

		// Token: 0x04000298 RID: 664
		private const float muyAltaCamillaScale = 1.428566f;

		// Token: 0x04000299 RID: 665
		private static readonly Vector3 muyAltaLocalPosToCenter = new Vector3(-0.05600018f, 0f, 0.4200018f);

		// Token: 0x0400029A RID: 666
		private CamillaMedica m_CamillaMedica;
	}
}
