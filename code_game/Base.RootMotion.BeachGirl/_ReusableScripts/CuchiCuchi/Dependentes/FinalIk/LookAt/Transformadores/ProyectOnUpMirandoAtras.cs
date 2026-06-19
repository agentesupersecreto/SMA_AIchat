using System;
using Assets.TValle.BeachGirl.Runtime.IK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt.Transformadores
{
	// Token: 0x02000096 RID: 150
	public sealed class ProyectOnUpMirandoAtras : CustomUpdatedMonobehaviourBase, ILookAtIKTargetTransformer
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0001D7D5 File Offset: 0x0001B9D5
		public int order
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_char = this.GetComponentEnRoot(false);
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001D808 File Offset: 0x0001BA08
		public Vector3 Transformar(Vector3 position, Quaternion rotation, Vector3 targetPosition)
		{
			if (this.upOffSetMod < 0f)
			{
				this.upOffSetMod = 0f;
			}
			float num = this.upOffSetMod - 1f;
			this.estadisticas.Actualizar(rotation, targetPosition - position);
			Vector3 vector = rotation * Vector3.up;
			float escala = this.m_char.escala;
			Vector3 vector2 = vector * (num * escala);
			Vector3 vector3 = position + vector2;
			Vector3 vector4 = Math3d.ProjectPointOnPlane(vector, vector3, targetPosition);
			float num2 = 1f - Mathf.Clamp01(this.estadisticas.verticalModAprox.InPow(this.verticalMods.power) * this.verticalMods.weight);
			float num3 = 1f - Mathf.Clamp01(this.estadisticas.haciaAdelanteModAprox.InPow(this.haciaAdelanteMods.power) * this.haciaAdelanteMods.weight);
			if (this.haciaArribaAdelanteMods.weight > 0f)
			{
				num3 += Mathf.Clamp01(this.estadisticas.haciaArribaMod.InPow(this.haciaArribaAdelanteMods.power) * this.haciaArribaAdelanteMods.weight);
				num3 = Mathf.Clamp01(num3);
			}
			float num4 = 1f - Mathf.Clamp01(this.estadisticas.haciaArribaMod.InPow(this.haciaArribaMods.power) * this.haciaArribaMods.weight);
			Vector3 vector5 = Vector3.Slerp(targetPosition, vector4, this.weight * num4 * num2 * num3);
			bool flag = this.debugDraw;
			return vector5;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0001DA5B File Offset: 0x0001BC5B
		bool ILookAtIKTargetTransformer.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x04000419 RID: 1049
		[SerializeField]
		private int m_order = 3;

		// Token: 0x0400041A RID: 1050
		public bool debugDraw;

		// Token: 0x0400041B RID: 1051
		public bool activar = true;

		// Token: 0x0400041C RID: 1052
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400041D RID: 1053
		[Range(0f, 2f)]
		public float upOffSetMod = 1.015f;

		// Token: 0x0400041E RID: 1054
		public OrientacionMod haciaAdelanteMods = new OrientacionMod
		{
			power = 1f,
			weight = 1f
		};

		// Token: 0x0400041F RID: 1055
		public OrientacionMod verticalMods = new OrientacionMod
		{
			power = 30f,
			weight = 0.15f
		};

		// Token: 0x04000420 RID: 1056
		public OrientacionMod haciaArribaMods = new OrientacionMod
		{
			power = 5.5f,
			weight = 0.25f
		};

		// Token: 0x04000421 RID: 1057
		public OrientacionMod haciaArribaAdelanteMods = new OrientacionMod
		{
			power = 1f,
			weight = 0f
		};

		// Token: 0x04000422 RID: 1058
		public LookAtEstadisticas estadisticas;

		// Token: 0x04000423 RID: 1059
		private ICharacter m_char;
	}
}
