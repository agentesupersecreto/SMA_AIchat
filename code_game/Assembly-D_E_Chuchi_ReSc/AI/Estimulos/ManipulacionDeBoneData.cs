using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003EE RID: 1006
	[Serializable]
	public struct ManipulacionDeBoneData
	{
		// Token: 0x060015F9 RID: 5625 RVA: 0x0005BE94 File Offset: 0x0005A094
		public ManipulacionDeBoneData(Character PorCharacter, Transform Estimulado, bool FueConsentido, bool ForzandoMovimientoDeBone, ParteDelCuerpoHumano Manipulando)
		{
			if (PorCharacter == null)
			{
				throw new ArgumentNullException("PorCharacter", "PorCharacter null reference.");
			}
			if (Estimulado == null)
			{
				throw new ArgumentNullException("Estimulado", "Estimulado null reference.");
			}
			this.m_manipulando = Manipulando;
			this.m_ForzandoMovimientoDeBone = ForzandoMovimientoDeBone;
			this.m_FueConsentido = FueConsentido;
			this.m_transformEstimulado = Estimulado;
			this.m_por = PorCharacter;
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x0005BEF8 File Offset: 0x0005A0F8
		public Character por
		{
			get
			{
				return this.m_por;
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x060015FB RID: 5627 RVA: 0x0005BF00 File Offset: 0x0005A100
		public Transform transformEstimulado
		{
			get
			{
				return this.m_transformEstimulado;
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x0005BF08 File Offset: 0x0005A108
		public ParteDelCuerpoHumano manipulando
		{
			get
			{
				return this.m_manipulando;
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x060015FD RID: 5629 RVA: 0x0005BF10 File Offset: 0x0005A110
		public bool forzandoMovimientoDeBone
		{
			get
			{
				return this.m_ForzandoMovimientoDeBone;
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x0005BF18 File Offset: 0x0005A118
		public bool fueConsentido
		{
			get
			{
				return this.m_FueConsentido;
			}
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0005BF20 File Offset: 0x0005A120
		public static bool TryObtenerCharacter(Object por, out Character result)
		{
			Character character = por as Character;
			if (character != null)
			{
				result = character;
				return true;
			}
			result = por.GetComponentEnRoot(false);
			if (result != null)
			{
				return true;
			}
			Debug.LogWarning(por.GetType().Name + " no es compatible para añadir a EstimuledBy", por);
			result = null;
			return false;
		}

		// Token: 0x0400117A RID: 4474
		[ReadOnlyUI]
		[SerializeField]
		private bool m_ForzandoMovimientoDeBone;

		// Token: 0x0400117B RID: 4475
		[ReadOnlyUI]
		[SerializeField]
		private bool m_FueConsentido;

		// Token: 0x0400117C RID: 4476
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_transformEstimulado;

		// Token: 0x0400117D RID: 4477
		[ReadOnlyUI]
		[SerializeField]
		private Character m_por;

		// Token: 0x0400117E RID: 4478
		[ReadOnlyUI]
		[SerializeField]
		private ParteDelCuerpoHumano m_manipulando;
	}
}
