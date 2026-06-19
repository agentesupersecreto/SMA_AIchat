using System;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B0 RID: 176
	public sealed class LenguaColliders : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000E0F9 File Offset: 0x0000C2F9
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeDynamicColliders);
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000081F8 File Offset: 0x000063F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000E104 File Offset: 0x0000C304
		public void Init()
		{
			this.m_GuiasParaTongueHelper = this.GetComponentEnRoot(false);
			if (this.m_GuiasParaTongueHelper == null)
			{
				throw new ArgumentNullException("m_GuiasParaTongueHelper", "m_GuiasParaTongueHelper null reference.");
			}
			this.m_baseCollider = base.transform.CreateChild("LenguaColliderBase").gameObject.AddComponent<BoxCollider>();
			this.m_middleCollider = base.transform.CreateChild("LenguaColliderMedio").gameObject.AddComponent<BoxCollider>();
			this.m_tipCollider = base.transform.CreateChild("LenguaColliderPunta").gameObject.AddComponent<BoxCollider>();
			base.Initialize();
			base.ManualStart();
			this.UpdateColliders();
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0000E1AE File Offset: 0x0000C3AE
		public override void OnUpdateEvent1()
		{
			this.UpdateColliders();
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000E1B8 File Offset: 0x0000C3B8
		public void UpdateColliders()
		{
			Transform transform = this.m_baseCollider.transform;
			Transform transform2 = this.m_middleCollider.transform;
			Transform transform3 = this.m_tipCollider.transform;
			Vector3 position = this.m_GuiasParaTongueHelper.guias.l002.position;
			Vector3 position2 = this.m_GuiasParaTongueHelper.guias.r002.position;
			Vector3 position3 = this.m_GuiasParaTongueHelper.guias.l001.position;
			Vector3 position4 = this.m_GuiasParaTongueHelper.guias.r001.position;
			Vector3 position5 = this.m_GuiasParaTongueHelper.guias.l.position;
			Vector3 position6 = this.m_GuiasParaTongueHelper.guias.r.position;
			Vector3 position7 = this.m_GuiasParaTongueHelper.guias.middle.position;
			Vector3 position8 = this.m_GuiasParaTongueHelper.guias.middle001.position;
			Vector3 position9 = this.m_GuiasParaTongueHelper.guias.middle002.position;
			Vector3 vector = (position + position2) / 2f;
			Vector3 vector2 = position9 - vector;
			Vector3 normalized = vector2.normalized;
			float magnitude = vector2.magnitude;
			Vector3 vector3 = position2 - vector;
			Vector3 normalized2 = vector3.normalized;
			float magnitude2 = vector3.magnitude;
			transform3.position = vector;
			transform3.rotation = Quaternion.LookRotation(normalized, Vector3.Cross(normalized, normalized2));
			this.m_tipCollider.size = new Vector3(magnitude2 * 2f, magnitude * 2f, magnitude * 2f) * 0.75f;
			Vector3 vector4 = (position3 + position4) / 2f;
			Vector3 vector5 = position8 - vector4;
			Vector3 normalized3 = vector5.normalized;
			float magnitude3 = vector5.magnitude;
			float magnitude4 = (position4 - vector4).magnitude;
			transform2.position = vector4;
			transform2.rotation = Quaternion.LookRotation(vector - vector4, normalized3);
			this.m_middleCollider.size = new Vector3(magnitude4 * 2f, magnitude3 * 2f, (vector - vector4).magnitude * 2f) * 0.75f;
			Vector3 vector6 = (position5 + position6) / 2f;
			Vector3 vector7 = position7 - vector6;
			Vector3 normalized4 = vector7.normalized;
			float magnitude5 = vector7.magnitude;
			float magnitude6 = (position6 - vector6).magnitude;
			transform.position = vector6;
			transform.rotation = Quaternion.LookRotation(vector4 - vector6, normalized4);
			this.m_baseCollider.size = new Vector3(magnitude6 * 2f, magnitude5 * 2f, (vector4 - vector6).magnitude * 2f) * 0.75f;
		}

		// Token: 0x040002C9 RID: 713
		private GuiasParaTongueHelper m_GuiasParaTongueHelper;

		// Token: 0x040002CA RID: 714
		private BoxCollider m_baseCollider;

		// Token: 0x040002CB RID: 715
		private BoxCollider m_middleCollider;

		// Token: 0x040002CC RID: 716
		private BoxCollider m_tipCollider;
	}
}
