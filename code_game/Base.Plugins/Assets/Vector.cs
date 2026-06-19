using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016D RID: 365
	[Serializable]
	public struct Vector
	{
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x00024D56 File Offset: 0x00022F56
		public Vector3 originalVector
		{
			get
			{
				return this.m_originalVector;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00024D5E File Offset: 0x00022F5E
		public Transform referencia
		{
			get
			{
				return this.m_referencia;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x00024D66 File Offset: 0x00022F66
		public Vector.TipoDeVector tipo
		{
			get
			{
				return this.m_TipoDeVector;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x00024D70 File Offset: 0x00022F70
		public bool isValid
		{
			get
			{
				switch (this.m_TipoDeVector)
				{
				case Vector.TipoDeVector.None:
					return false;
				case Vector.TipoDeVector.punto:
					switch (this.m_TipoDeEspacio)
					{
					case Vector.TipoDeEspacio.None:
						return false;
					case Vector.TipoDeEspacio.global:
						return true;
					case Vector.TipoDeEspacio.local:
						return this.m_referencia != null;
					default:
						throw new ArgumentOutOfRangeException(this.m_TipoDeEspacio.ToString());
					}
					break;
				case Vector.TipoDeVector.normal:
					switch (this.m_TipoDeEspacio)
					{
					case Vector.TipoDeEspacio.None:
						return false;
					case Vector.TipoDeEspacio.global:
						return true;
					case Vector.TipoDeEspacio.local:
						return this.m_referencia != null;
					default:
						throw new ArgumentOutOfRangeException(this.m_TipoDeEspacio.ToString());
					}
					break;
				default:
					throw new ArgumentOutOfRangeException(this.m_TipoDeVector.ToString());
				}
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00024E3C File Offset: 0x0002303C
		public Vector3 ObtenerVectorGlobal()
		{
			if (!this.isValid)
			{
				return this.m_originalVector;
			}
			switch (this.m_TipoDeVector)
			{
			case Vector.TipoDeVector.None:
				throw new InvalidOperationException();
			case Vector.TipoDeVector.punto:
				switch (this.m_TipoDeEspacio)
				{
				case Vector.TipoDeEspacio.None:
					throw new InvalidOperationException();
				case Vector.TipoDeEspacio.global:
					return this.m_vector;
				case Vector.TipoDeEspacio.local:
					return this.m_referencia.TransformPoint(this.m_vector);
				default:
					throw new ArgumentOutOfRangeException(this.m_TipoDeEspacio.ToString());
				}
				break;
			case Vector.TipoDeVector.normal:
				switch (this.m_TipoDeEspacio)
				{
				case Vector.TipoDeEspacio.None:
					throw new InvalidOperationException();
				case Vector.TipoDeEspacio.global:
					return this.m_vector;
				case Vector.TipoDeEspacio.local:
					return this.m_referencia.TransformDirection(this.m_vector);
				default:
					throw new ArgumentOutOfRangeException(this.m_TipoDeEspacio.ToString());
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_TipoDeVector.ToString());
			}
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00024F34 File Offset: 0x00023134
		private void SetTipo(Vector.TipoDeVector tipoVector)
		{
			if (tipoVector == Vector.TipoDeVector.None)
			{
				throw new InvalidOperationException();
			}
			this.m_TipoDeVector = tipoVector;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00024F46 File Offset: 0x00023146
		public void Poblar(Vector.TipoDeVector tipoVector, Vector3 vectorGlobal)
		{
			this.Poblar(tipoVector, vectorGlobal, null);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00024F54 File Offset: 0x00023154
		public void Poblar(Vector.TipoDeVector tipoVector, Vector3 vectorGlobal, Transform referencia)
		{
			this.SetTipo(tipoVector);
			this.m_referencia = referencia;
			this.m_originalVector = vectorGlobal;
			this.m_TipoDeEspacio = (this.m_referencia ? Vector.TipoDeEspacio.local : Vector.TipoDeEspacio.global);
			switch (this.m_TipoDeEspacio)
			{
			case Vector.TipoDeEspacio.None:
				throw new InvalidCastException();
			case Vector.TipoDeEspacio.global:
				this.m_vector = vectorGlobal;
				return;
			case Vector.TipoDeEspacio.local:
				switch (this.m_TipoDeVector)
				{
				case Vector.TipoDeVector.None:
					throw new InvalidOperationException();
				case Vector.TipoDeVector.punto:
					this.m_vector = this.m_referencia.InverseTransformPoint(vectorGlobal);
					return;
				case Vector.TipoDeVector.normal:
					this.m_vector = this.m_referencia.InverseTransformDirection(vectorGlobal);
					return;
				default:
					throw new ArgumentOutOfRangeException(this.m_TipoDeVector.ToString());
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_TipoDeEspacio.ToString());
			}
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0002502C File Offset: 0x0002322C
		public void Clear()
		{
			this.m_referencia = null;
			this.m_TipoDeVector = Vector.TipoDeVector.None;
			this.m_TipoDeEspacio = Vector.TipoDeEspacio.None;
			this.m_originalVector = (this.m_vector = Vector3.zero);
		}

		// Token: 0x04000364 RID: 868
		[ReadOnlyUI]
		[SerializeField]
		private Vector.TipoDeVector m_TipoDeVector;

		// Token: 0x04000365 RID: 869
		[ReadOnlyUI]
		[SerializeField]
		private Vector.TipoDeEspacio m_TipoDeEspacio;

		// Token: 0x04000366 RID: 870
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_referencia;

		// Token: 0x04000367 RID: 871
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_vector;

		// Token: 0x04000368 RID: 872
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_originalVector;

		// Token: 0x020001DC RID: 476
		public enum TipoDeEspacio
		{
			// Token: 0x04000475 RID: 1141
			None,
			// Token: 0x04000476 RID: 1142
			global,
			// Token: 0x04000477 RID: 1143
			local
		}

		// Token: 0x020001DD RID: 477
		public enum TipoDeVector
		{
			// Token: 0x04000479 RID: 1145
			None,
			// Token: 0x0400047A RID: 1146
			punto,
			// Token: 0x0400047B RID: 1147
			normal
		}
	}
}
