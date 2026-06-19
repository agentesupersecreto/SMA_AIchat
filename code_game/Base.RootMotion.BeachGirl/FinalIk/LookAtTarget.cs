using System;
using UnityEngine;

namespace Assets.FinalIk
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class LookAtTarget
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002AFB File Offset: 0x00000CFB
		public LookAtTarget.Tipo tipo
		{
			get
			{
				return this.m_Tipo;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002B03 File Offset: 0x00000D03
		public Transform transform
		{
			get
			{
				return this.m_Transform;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002B0B File Offset: 0x00000D0B
		public Vector3 vector
		{
			get
			{
				return this.m_vector;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002B13 File Offset: 0x00000D13
		public Vector3 posicionGlobal
		{
			get
			{
				return this.m_posicionGlobal;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002B1C File Offset: 0x00000D1C
		public bool esValido
		{
			get
			{
				switch (this.m_Tipo)
				{
				case LookAtTarget.Tipo.None:
					return false;
				case LookAtTarget.Tipo.transform:
				case LookAtTarget.Tipo.posicionLocal:
					return this.m_Transform != null;
				case LookAtTarget.Tipo.posicionGlobal:
					return true;
				default:
					throw new ArgumentOutOfRangeException(this.m_Tipo.ToString());
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002B6F File Offset: 0x00000D6F
		public void Clear()
		{
			this.ClearTarget();
			this.config.lookAtVelocityMod = 1f;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002B87 File Offset: 0x00000D87
		private void ClearTarget()
		{
			this.m_Transform = null;
			this.m_Tipo = LookAtTarget.Tipo.None;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002B97 File Offset: 0x00000D97
		public void Set(Transform trasnform)
		{
			this.ClearTarget();
			if (trasnform == null)
			{
				throw new ArgumentNullException("trasnform", "trasnform null reference.");
			}
			this.m_Transform = trasnform;
			this.m_Tipo = LookAtTarget.Tipo.transform;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002BC6 File Offset: 0x00000DC6
		public void Set(Vector3 posicionGlobal)
		{
			this.ClearTarget();
			this.m_Tipo = LookAtTarget.Tipo.posicionGlobal;
			this.m_vector = posicionGlobal;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002BDC File Offset: 0x00000DDC
		public void Set(Transform trasnform, Vector3 posicionLocal)
		{
			this.ClearTarget();
			if (trasnform == null)
			{
				throw new ArgumentNullException("trasnform", "trasnform null reference.");
			}
			this.m_Tipo = LookAtTarget.Tipo.posicionLocal;
			this.m_vector = posicionLocal;
			this.m_Transform = trasnform;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002C14 File Offset: 0x00000E14
		public void CopyFrom(LookAtTarget other)
		{
			if (other == this)
			{
				throw new InvalidOperationException();
			}
			this.ClearTarget();
			this.config.CopyFrom(other.config);
			this.m_vector = other.m_vector;
			this.m_Transform = other.m_Transform;
			this.m_Tipo = other.m_Tipo;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002C68 File Offset: 0x00000E68
		public void Update()
		{
			try
			{
				if (this.config.puedeActualizarce)
				{
					switch (this.m_Tipo)
					{
					case LookAtTarget.Tipo.None:
						throw new InvalidOperationException();
					case LookAtTarget.Tipo.transform:
						this.m_posicionGlobal = this.m_Transform.position;
						break;
					case LookAtTarget.Tipo.posicionGlobal:
						this.m_posicionGlobal = this.m_vector;
						break;
					case LookAtTarget.Tipo.posicionLocal:
						this.m_posicionGlobal = this.m_Transform.TransformPoint(this.m_vector);
						break;
					default:
						throw new ArgumentOutOfRangeException(this.m_Tipo.ToString());
					}
				}
			}
			finally
			{
				bool flag = this.debugDraw;
			}
		}

		// Token: 0x04000001 RID: 1
		public bool debugDraw;

		// Token: 0x04000002 RID: 2
		public LookAtTarget.Config config = new LookAtTarget.Config();

		// Token: 0x04000003 RID: 3
		[SerializeField]
		private Vector3 m_posicionGlobal;

		// Token: 0x04000004 RID: 4
		[SerializeField]
		private Vector3 m_vector;

		// Token: 0x04000005 RID: 5
		[SerializeField]
		private Transform m_Transform;

		// Token: 0x04000006 RID: 6
		[SerializeField]
		private LookAtTarget.Tipo m_Tipo;

		// Token: 0x02000110 RID: 272
		[Serializable]
		public class Config
		{
			// Token: 0x06000A88 RID: 2696 RVA: 0x0002F145 File Offset: 0x0002D345
			public void CopyFrom(LookAtTarget.Config other)
			{
				if (other == this)
				{
					throw new InvalidOperationException();
				}
				this.puedeActualizarce = other.puedeActualizarce;
				this.usarMaxAngleDeVision = other.usarMaxAngleDeVision;
				this.lookAtVelocityMod = other.lookAtVelocityMod;
			}

			// Token: 0x04000671 RID: 1649
			public bool puedeActualizarce = true;

			// Token: 0x04000672 RID: 1650
			public bool usarMaxAngleDeVision = true;

			// Token: 0x04000673 RID: 1651
			public float lookAtVelocityMod = 1f;
		}

		// Token: 0x02000111 RID: 273
		public enum Tipo
		{
			// Token: 0x04000675 RID: 1653
			None,
			// Token: 0x04000676 RID: 1654
			transform,
			// Token: 0x04000677 RID: 1655
			posicionGlobal,
			// Token: 0x04000678 RID: 1656
			posicionLocal
		}
	}
}
