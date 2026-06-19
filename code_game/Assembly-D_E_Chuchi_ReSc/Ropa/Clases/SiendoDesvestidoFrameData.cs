using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.Clases
{
	// Token: 0x0200014C RID: 332
	[Serializable]
	public struct SiendoDesvestidoFrameData
	{
		// Token: 0x06000786 RID: 1926 RVA: 0x00023824 File Offset: 0x00021A24
		public SiendoDesvestidoFrameData(Character porCharacter, string PiezaID, Character own, PiezaDeRopaBase pieza, bool esParcial, bool SoloUnaVez)
		{
			if (own == null)
			{
				throw new ArgumentNullException("own", "own null reference.");
			}
			if (pieza.skinnedMeshRenderer == null)
			{
				throw new ArgumentNullException("pieza.skinnedMeshRenderer", "pieza.skinnedMeshRenderer null reference.");
			}
			if (porCharacter == null)
			{
				throw new ArgumentNullException("porCharacter", "porCharacter null reference.");
			}
			if (string.IsNullOrWhiteSpace(PiezaID))
			{
				throw new InvalidOperationException();
			}
			this.m_por = porCharacter;
			this.m_piezaID = PiezaID;
			this.m_puntoLocalDePiezaDesdeRoot = own.rootBoneTransform.InverseTransformPoint(pieza.skinnedMeshRenderer.bounds.center);
			this.flagToFail = false;
			this.partesExpuestas = RopaCubre.None;
			this.parcial = esParcial;
			this.soloUnaVez = SoloUnaVez;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000238E1 File Offset: 0x00021AE1
		public SiendoDesvestidoFrameData(Character porCharacter, string PiezaID, Character own, PiezaDeRopaBase pieza, RopaCubre PartesExpuestas, bool esParcial, bool SoloUnaVez)
		{
			this = new SiendoDesvestidoFrameData(porCharacter, PiezaID, own, pieza, esParcial, SoloUnaVez);
			this.partesExpuestas = PartesExpuestas;
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x000238FA File Offset: 0x00021AFA
		public Character por
		{
			get
			{
				return this.m_por;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x00023902 File Offset: 0x00021B02
		public string piezaID
		{
			get
			{
				return this.m_piezaID;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0002390A File Offset: 0x00021B0A
		public Vector3 puntoLocalDePiezaDesdeRoot
		{
			get
			{
				return this.m_puntoLocalDePiezaDesdeRoot;
			}
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00023914 File Offset: 0x00021B14
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

		// Token: 0x040005FF RID: 1535
		public RopaCubre partesExpuestas;

		// Token: 0x04000600 RID: 1536
		public bool flagToFail;

		// Token: 0x04000601 RID: 1537
		public bool parcial;

		// Token: 0x04000602 RID: 1538
		public bool soloUnaVez;

		// Token: 0x04000603 RID: 1539
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_puntoLocalDePiezaDesdeRoot;

		// Token: 0x04000604 RID: 1540
		[ReadOnlyUI]
		[SerializeField]
		private Character m_por;

		// Token: 0x04000605 RID: 1541
		[ReadOnlyUI]
		[SerializeField]
		private string m_piezaID;
	}
}
