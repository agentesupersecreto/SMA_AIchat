using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores
{
	// Token: 0x0200018A RID: 394
	public class RecorridoLinearDePenetradorVirtual : RecorridoLinearDePenetradorBase
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00029529 File Offset: 0x00027729
		public override Penetrador penetrador
		{
			get
			{
				return this.m_Penis;
			}
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00029411 File Offset: 0x00027611
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00029531 File Offset: 0x00027731
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_PuntosGuiasRecorridoLinear.updatingCurvas += this.M_PuntosGuiasRecorridoLinear_updatingCurvas;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00029550 File Offset: 0x00027750
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PuntosGuiasRecorridoLinear != null)
			{
				this.m_PuntosGuiasRecorridoLinear.updatingCurvas -= this.M_PuntosGuiasRecorridoLinear_updatingCurvas;
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0002957E File Offset: 0x0002777E
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_Penis = null;
			while (this.m_Penis == null)
			{
				yield return null;
				this.m_Penis = this.GetComponentEnRoot(false);
			}
			this.m_character = this.m_Penis.GetRootOwner() as AnimatorCharacter;
			this.m_PuntosGuiasRecorridoLinear.puntos = this.m_Penis.partesEnOrden.Select((PenisPart p) => p.physicBone.transform.CloneTransform(null, false)).ToList<Transform>();
			this.m_PuntosGuiasRecorridoLinear.puntos.Add(this.m_Penis.tipPhysics.CloneTransform(null, false));
			this.m_PuntosGuiasRecorridoLinear.puntos.ForEach(delegate(Transform p)
			{
				p.parent = base.transform;
			});
			yield break;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00029590 File Offset: 0x00027790
		private void M_PuntosGuiasRecorridoLinear_updatingCurvas()
		{
			Transform puntoBaseTransform = this.m_Penis.penisLinearChain.puntoBaseTransform;
			Quaternion quaternion = this.m_Penis.skinSurfaceTransform.rotation * this.m_character.armatureOrientationOffSet;
			base.transform.SetPositionAndRotation(puntoBaseTransform.position, quaternion);
			this.m_currentLocalForward = Vector3.SmoothDamp(this.m_currentLocalForward, this.localForward, ref this.currentVelocity, this.timeToChange);
			Vector3 normalized = base.transform.TransformDirection(this.m_currentLocalForward).normalized;
			float num = Mathf.Lerp(this.m_Penis.worldScale, this.m_Penis.worldScaleIgnorandoEreccion, this.ignorarEreccionWeigth);
			Quaternion quaternion2 = Quaternion.LookRotation(normalized, base.transform.up);
			for (int i = 0; i < this.m_PuntosGuiasRecorridoLinear.puntos.Count; i++)
			{
				Transform transform = this.m_PuntosGuiasRecorridoLinear.puntos[i];
				bool flag = i.IsLastIndex(this.m_PuntosGuiasRecorridoLinear.puntos.Count);
				transform.SetPositionAndRotation(base.transform.position + normalized * (0.02f * num * ((float)i + (flag ? 1f : 0f))), quaternion2);
			}
		}

		// Token: 0x0400072B RID: 1835
		[ReadOnlyUI]
		[SerializeField]
		protected Penis m_Penis;

		// Token: 0x0400072C RID: 1836
		public Vector3 localForward = Vector3.forward;

		// Token: 0x0400072D RID: 1837
		public float timeToChange = 0.25f;

		// Token: 0x0400072E RID: 1838
		public float ignorarEreccionWeigth = 1f;

		// Token: 0x0400072F RID: 1839
		[ReadOnlyUI]
		[SerializeField]
		protected Vector3 m_currentLocalForward;

		// Token: 0x04000730 RID: 1840
		private AnimatorCharacter m_character;

		// Token: 0x04000731 RID: 1841
		private Vector3 currentVelocity;
	}
}
