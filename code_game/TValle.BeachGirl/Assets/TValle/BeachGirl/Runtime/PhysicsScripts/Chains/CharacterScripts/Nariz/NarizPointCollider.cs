using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Mapas.Runtime;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.VertexPoints.SkinningShaping.SystemasLocales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Nariz
{
	// Token: 0x02000082 RID: 130
	public class NarizPointCollider : BodyPartCollider
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000A605 File Offset: 0x00008805
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI2);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0000A60E File Offset: 0x0000880E
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000A616 File Offset: 0x00008816
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000A61D File Offset: 0x0000881D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000A628 File Offset: 0x00008828
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_guiaNameForward = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.nariz_F;
			this.m_guiaNameL = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.nariz_L;
			this.m_guiaNameR = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.nariz_R;
			Animator bodyAnimator = this.GetRoot().bodyAnimator;
			Renderer renderer = MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerRenderer(bodyAnimator, MapaSingleton<MapaSingletonDeMainSkins>.instance.body);
			this.m_guias = renderer.GetComponentInChildren<SysLocSkinShapeVertexTransforms>();
			if (this.m_guias == null)
			{
				throw new ArgumentNullException("m_guias", "m_guias null reference.");
			}
			this.m_collider = base.transform.CreateChild(base.name + "_Collider").GetComponentNotNull<CapsuleCollider>();
			if (this.configuracion.material != null)
			{
				this.m_collider.sharedMaterial = this.configuracion.material;
			}
			this.m_collider.radius = this.configuracion.initialRadius;
			this.m_misColliders = new HashSet<Collider> { this.m_collider };
			base.initColliders();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000A73C File Offset: 0x0000893C
		public override void OnUpdateEvent1()
		{
			if (!this.m_guias.initiated)
			{
				return;
			}
			Transform transform;
			if (!this.m_guias.transPorNombre.TryGetValue(this.m_guiaNameForward, out transform))
			{
				throw new InvalidOperationException();
			}
			Transform transform2;
			if (!this.m_guias.transPorNombre.TryGetValue(this.m_guiaNameL, out transform2))
			{
				throw new InvalidOperationException();
			}
			Transform transform3;
			if (!this.m_guias.transPorNombre.TryGetValue(this.m_guiaNameR, out transform3))
			{
				throw new InvalidOperationException();
			}
			Vector3 position = transform2.position;
			Vector3 position2 = transform3.position;
			Vector3 position3 = transform.position;
			Vector3 vector = (position + position2) / 2f;
			Vector3 vector2 = position - vector;
			Vector3 vector3 = position3 - vector;
			float magnitude = vector2.magnitude;
			float magnitude2 = vector3.magnitude;
			int num;
			float num2;
			float num3;
			if (magnitude2 >= magnitude)
			{
				num = 2;
				num2 = magnitude;
				num3 = magnitude2 * 2f;
			}
			else
			{
				num = 0;
				num2 = magnitude2;
				num3 = magnitude * 2f;
			}
			Transform transform4 = this.m_collider.transform;
			float num4 = transform4.lossyScale.Escala();
			this.m_collider.center = transform4.InverseTransformPoint(vector);
			this.m_collider.direction = num;
			this.m_collider.radius = num2 / num4;
			this.m_collider.height = num3 / num4;
			transform4.rotation = Quaternion.LookRotation(position3 - vector, base.transform.up);
		}

		// Token: 0x04000203 RID: 515
		private CapsuleCollider m_collider;

		// Token: 0x04000204 RID: 516
		private HashSet<Collider> m_misColliders;

		// Token: 0x04000205 RID: 517
		public NarizPointCollider.Configuracion configuracion = new NarizPointCollider.Configuracion();

		// Token: 0x04000206 RID: 518
		[SerializeField]
		[ReadOnlyUI]
		private string m_guiaNameForward;

		// Token: 0x04000207 RID: 519
		[SerializeField]
		[ReadOnlyUI]
		private string m_guiaNameL;

		// Token: 0x04000208 RID: 520
		[SerializeField]
		[ReadOnlyUI]
		private string m_guiaNameR;

		// Token: 0x04000209 RID: 521
		private SysLocSkinShapeVertexTransforms m_guias;

		// Token: 0x02000177 RID: 375
		[Serializable]
		public class Configuracion
		{
			// Token: 0x0400088E RID: 2190
			public PhysicMaterial material;

			// Token: 0x0400088F RID: 2191
			public float initialRadius = 0.0075f;

			// Token: 0x04000890 RID: 2192
			public float initialHeight = 0.0085f;
		}
	}
}
