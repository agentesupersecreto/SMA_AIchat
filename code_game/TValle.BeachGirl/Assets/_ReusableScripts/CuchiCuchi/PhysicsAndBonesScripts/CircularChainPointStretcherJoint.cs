using System;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000EE RID: 238
	public class CircularChainPointStretcherJoint : ChainPointStretcherJoint
	{
		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x0002026C File Offset: 0x0001E46C
		public int puntoID
		{
			get
			{
				return this.m_puntoID;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00020274 File Offset: 0x0001E474
		public BoneStretchedChain parent8PointChain
		{
			get
			{
				return this.m_circularChain;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x0002027C File Offset: 0x0001E47C
		public JointDrivesAdmin.Modificador driveFixModificadores
		{
			get
			{
				return this.m_modificador;
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00020284 File Offset: 0x0001E484
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_circularChain = this.parentChain as BoneStretchedChain;
			if (this.m_circularChain == null)
			{
				throw new ArgumentNullException("m_circularChain", "m_circularChain null reference.");
			}
			this.m_puntoID = this.m_circularChain.ObtenerPunto(this);
			this.m_defaultApertura = this.m_circularChain.ObtenerApertura(this.m_puntoID);
			this.m_defaultProfundidad = this.m_circularChain.ObtenerProfundidad(this.m_puntoID);
			this.m_modificador = base.jointDrivesAdmin.AñadirModificador(123);
			this.m_outLocalDirecition = base.transform.InverseTransformDirection(base.otherBody.transform.position - this.m_circularChain.centroDePuntos.position).normalized;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00020358 File Offset: 0x0001E558
		public void AbrirUnPoquito(float acceleracion)
		{
			Vector3 vector = base.transform.TransformDirection(this.m_outLocalDirecition);
			base.otherBody.AddForce(vector * acceleracion, ForceMode.Acceleration);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0002038C File Offset: 0x0001E58C
		public void UpdateDrives()
		{
			float num;
			float num2;
			this.m_circularChain.ObtenerAperturaYProfundidad(this.m_puntoID, out num, out num2);
			num2 = Mathf.Abs(num2);
			this.UpdateDrives(num, num2, this.m_defaultApertura);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x000203C4 File Offset: 0x0001E5C4
		public void UpdateDrives(float currentApertura, float currentProfundidad, float minApertura)
		{
			if (this.driveFixConfiguracion.unidad <= 0f)
			{
				throw new InvalidOperationException();
			}
			try
			{
				float num = currentApertura - minApertura;
				float num2 = currentProfundidad - this.m_defaultProfundidad;
				num = ((num < 0f) ? 0f : num);
				num2 = ((num2 < 0f) ? 0f : num2);
				float num3 = num / this.driveFixConfiguracion.unidad;
				float num4 = num2 / this.driveFixConfiguracion.unidad;
				float num5 = 1f + num3 * (this.driveFixConfiguracion.modPorUnidadDeApertura - 1f);
				float num6 = 1f + num4 * (this.driveFixConfiguracion.modPorUnidadDeProfundidad - 1f);
				this.driveFixModificadores.z = Mathf.Pow(num5, this.driveFixConfiguracion.expPorUnidadDeApertura) / num6;
				base.jointDrivesAdmin.FixDrivers();
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x0400054E RID: 1358
		[SerializeField]
		[ReadOnlyUI]
		private BoneStretchedChain m_circularChain;

		// Token: 0x0400054F RID: 1359
		private Vector3 m_outLocalDirecition;

		// Token: 0x04000550 RID: 1360
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultProfundidad;

		// Token: 0x04000551 RID: 1361
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultApertura;

		// Token: 0x04000552 RID: 1362
		[SerializeField]
		[ReadOnlyUI]
		private int m_puntoID;

		// Token: 0x04000553 RID: 1363
		[NonSerialized]
		private JointDrivesAdmin.Modificador m_modificador;

		// Token: 0x04000554 RID: 1364
		public CircularChainPointStretcherJoint.DriveFixConfiguracion driveFixConfiguracion = new CircularChainPointStretcherJoint.DriveFixConfiguracion();

		// Token: 0x020001C5 RID: 453
		[Serializable]
		public class DriveFixConfiguracion
		{
			// Token: 0x04000A1C RID: 2588
			[Tooltip("tamaño de la unidad a trabajar")]
			public float unidad = 0.01f;

			// Token: 0x04000A1D RID: 2589
			[Range(0f, 10f)]
			[Tooltip("modificara apertura drive")]
			public float modPorUnidadDeApertura = 1.001f;

			// Token: 0x04000A1E RID: 2590
			[Range(0f, 1000f)]
			[Tooltip("modificara apertura drive")]
			public float expPorUnidadDeApertura = 1000f;

			// Token: 0x04000A1F RID: 2591
			[Range(0f, 10f)]
			[Tooltip("modificara apertura drive TAMBIEN negativamente")]
			public float modPorUnidadDeProfundidad = 1f;
		}
	}
}
