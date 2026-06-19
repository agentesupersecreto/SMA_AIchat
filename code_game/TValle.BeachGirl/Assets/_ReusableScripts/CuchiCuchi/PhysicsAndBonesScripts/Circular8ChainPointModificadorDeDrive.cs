using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FF RID: 255
	[Obsolete]
	[RequireComponent(typeof(CircularChainPointStretcherJoint))]
	public class Circular8ChainPointModificadorDeDrive : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x000248B8 File Offset: 0x00022AB8
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x000248C0 File Offset: 0x00022AC0
		public new GlobalUpdater.UpdateType updateEvent2
		{
			get
			{
				return this.m_UpdateEvent2;
			}
			set
			{
				this.m_UpdateEvent2 = value;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x000248C9 File Offset: 0x00022AC9
		public sealed override int updateEvent2Index
		{
			get
			{
				return (int)this.m_UpdateEvent2;
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x000248D1 File Offset: 0x00022AD1
		public JointDrivesAdmin.Modificador driveModificadores
		{
			get
			{
				return this.m_modificador;
			}
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x000248DC File Offset: 0x00022ADC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_point = base.GetComponent<CircularChainPointStretcherJoint>();
			if (this.m_point == null)
			{
				throw new ArgumentNullException("m_point", "m_point null reference.");
			}
			this.m_circularChain = this.m_point.parentChain as Circular8BoneChain;
			if (this.m_circularChain == null)
			{
				throw new ArgumentNullException("m_circularChain", "m_circularChain null reference.");
			}
			this.m_puntoEnum = this.m_circularChain.ObtenerPuntoEnum(this.m_point);
			this.m_defaultApertura = this.m_circularChain.ObtenerApertura(this.m_puntoEnum);
			this.m_defaultProfundidad = this.m_circularChain.ObtenerProfundidad(this.m_puntoEnum);
			this.m_modificador = this.m_point.jointDrivesAdmin.AñadirModificador(base.GetInstanceID());
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x000249AE File Offset: 0x00022BAE
		public override void OnUpdateEvent2()
		{
			base.OnUpdateEvent2();
			this.UpdateDrive();
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000249BC File Offset: 0x00022BBC
		public void UpdateDrive()
		{
			float num;
			float num2;
			this.m_circularChain.ObtenerAperturaYProfundidad(this.m_puntoEnum, out num, out num2);
			num2 = Mathf.Abs(num2);
			this.UpdateDrive(num, num2, this.m_defaultApertura, this.m_defaultProfundidad);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x000249FC File Offset: 0x00022BFC
		public void UpdateDrive(float currentApertura, float currentProfundidad, float minApertura, float minProfundidad)
		{
			if (this.configuracion.unidad <= 0f)
			{
				throw new InvalidOperationException();
			}
			float num = currentApertura - minApertura;
			float num2 = currentProfundidad - minProfundidad;
			num = ((num < 0f) ? 0f : num);
			num2 = ((num2 < 0f) ? 0f : num2);
			float num3 = num / this.configuracion.unidad;
			float num4 = num2 / this.configuracion.unidad;
			float num5 = 1f + num3 * this.configuracion.modPorUnidadDeApertura;
			float num6 = 1f + num4 * this.configuracion.modPorUnidadDeProfundidad;
			this.driveModificadores.z = Mathf.Pow(num5, this.configuracion.expPorUnidadDeApertura) * num6;
			this.m_point.jointDrivesAdmin.FixDrivers();
		}

		// Token: 0x040005DB RID: 1499
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent2 = GlobalUpdater.UpdateType.fixedUpdate2;

		// Token: 0x040005DC RID: 1500
		[SerializeField]
		[ReadOnlyUI]
		private Circular8BoneChain m_circularChain;

		// Token: 0x040005DD RID: 1501
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultProfundidad;

		// Token: 0x040005DE RID: 1502
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultApertura;

		// Token: 0x040005DF RID: 1503
		[SerializeField]
		[ReadOnlyUI]
		private Circular8BoneChain.Punto m_puntoEnum;

		// Token: 0x040005E0 RID: 1504
		private JointDrivesAdmin.Modificador m_modificador;

		// Token: 0x040005E1 RID: 1505
		private CircularChainPointStretcherJoint m_point;

		// Token: 0x040005E2 RID: 1506
		public Circular8ChainPointModificadorDeDrive.Configuracion configuracion = new Circular8ChainPointModificadorDeDrive.Configuracion();

		// Token: 0x020001E2 RID: 482
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A8E RID: 2702
			[Tooltip("tamaño de la unidad a trabajar")]
			public float unidad = 0.01f;

			// Token: 0x04000A8F RID: 2703
			[Range(0f, 10f)]
			[Tooltip("modificara apertura drive")]
			public float modPorUnidadDeApertura = 1.01f;

			// Token: 0x04000A90 RID: 2704
			[Range(0f, 10f)]
			[Tooltip("modificara apertura drive")]
			public float expPorUnidadDeApertura = 1.5f;

			// Token: 0x04000A91 RID: 2705
			[Range(0f, 10f)]
			[Tooltip("modificara apertura drive TAMBIEN")]
			public float modPorUnidadDeProfundidad = 1.005f;
		}
	}
}
