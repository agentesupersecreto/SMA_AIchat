using System;
using System.Collections.Generic;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Systemas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Guias
{
	// Token: 0x020000A4 RID: 164
	public class CollecionDeGuiasSlaveChildOf : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x00010411 File Offset: 0x0000E611
		public IReadOnlyDictionary<string, Object> guiasPorNombreDeSlave
		{
			get
			{
				return this.m_guiasPorNombre;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x00010419 File Offset: 0x0000E619
		public IReadOnlyDictionary<string, Object> guiasPorNombreDeMaestro
		{
			get
			{
				return this.m_guiasPorNombreDeMaestro;
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00010421 File Offset: 0x0000E621
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00010429 File Offset: 0x0000E629
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00010434 File Offset: 0x0000E634
		[Obsolete("", true)]
		private void Instance_completedCalled(SystemaParaGuiasChildOf obj)
		{
			for (int i = 0; i < this.m_guiasPorNombre.serializedValues.Count; i++)
			{
				Transform transform = (Transform)this.m_guiasPorNombre.serializedValues[i];
				this.m_estadoDeGuias[transform].Update(transform, true);
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00010488 File Offset: 0x0000E688
		public void Add(string slaveName, string masterName, Transform guiaTransform)
		{
			try
			{
				this.m_guiasPorNombre.Add(slaveName, guiaTransform);
				this.m_guiasPorNombreDeMaestro.Add(masterName, guiaTransform);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x000104C4 File Offset: 0x0000E6C4
		[Obsolete("", true)]
		public bool Chaged(Transform guia)
		{
			CollecionDeGuiasSlaveChildOf.Estado estado;
			if (!this.m_estadoDeGuias.TryGetValue(guia, out estado))
			{
				throw new NotSupportedException();
			}
			return estado.chaged;
		}

		// Token: 0x040002FC RID: 764
		[SerializeField]
		private StringKeyUnityValueDictionary m_guiasPorNombre = new StringKeyUnityValueDictionary();

		// Token: 0x040002FD RID: 765
		[SerializeField]
		private StringKeyUnityValueDictionary m_guiasPorNombreDeMaestro = new StringKeyUnityValueDictionary();

		// Token: 0x040002FE RID: 766
		[Obsolete("", true)]
		private Dictionary<Transform, CollecionDeGuiasSlaveChildOf.Estado> m_estadoDeGuias = new Dictionary<Transform, CollecionDeGuiasSlaveChildOf.Estado>();

		// Token: 0x02000193 RID: 403
		[Obsolete("", true)]
		private class Estado
		{
			// Token: 0x06000EDD RID: 3805 RVA: 0x000328C4 File Offset: 0x00030AC4
			public void Update(Transform target, bool updateValues)
			{
				Vector3 localPosition = target.localPosition;
				Quaternion localRotation = target.localRotation;
				Vector3 localScale = target.localScale;
				try
				{
					if (!ExtendedMonoBehaviour.AlmostEqual(this.pos, localPosition, 0.001f))
					{
						this.chaged = true;
					}
					else if (!ExtendedMonoBehaviour.AlmostEqual(this.rot, localRotation, 0.1f))
					{
						this.chaged = true;
					}
					else if (!ExtendedMonoBehaviour.AlmostEqual(this.scal, localScale, 0.001f))
					{
						this.chaged = true;
					}
					else
					{
						this.chaged = false;
					}
				}
				finally
				{
					if (updateValues)
					{
						this.pos = localPosition;
						this.rot = localRotation;
						this.scal = localScale;
					}
				}
			}

			// Token: 0x040008E4 RID: 2276
			public Vector3 pos;

			// Token: 0x040008E5 RID: 2277
			public Quaternion rot;

			// Token: 0x040008E6 RID: 2278
			public Vector3 scal;

			// Token: 0x040008E7 RID: 2279
			public bool chaged;
		}
	}
}
