using System;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class ConjuntoEspecificoGenerico : IConjuntoDeGenes
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x00010666 File Offset: 0x0000E866
		public ConjuntoEspecificoGenerico(string nombreDeConjunto)
		{
			if (string.IsNullOrWhiteSpace(nombreDeConjunto))
			{
				throw new NotSupportedException();
			}
			this.m_nombreDeConjunto = nombreDeConjunto;
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00010683 File Offset: 0x0000E883
		public string conjuntoName
		{
			get
			{
				return this.m_nombreDeConjunto;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0001068B File Offset: 0x0000E88B
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x00010693 File Offset: 0x0000E893
		public float fitnes
		{
			get
			{
				return this.m_fitnes;
			}
			set
			{
				this.m_fitnes = Mathf.Clamp01(value);
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000106A1 File Offset: 0x0000E8A1
		public bool GenePertenece(object identificador)
		{
			return ConjuntosDeAparienciaFisica.ContieneIdentificador(this.m_nombreDeConjunto, identificador);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000106AF File Offset: 0x0000E8AF
		public void ResetFitnes()
		{
			this.m_fitnes = 0f;
		}

		// Token: 0x040001FA RID: 506
		[SerializeField]
		[ReadOnlyUI]
		private string m_nombreDeConjunto;

		// Token: 0x040001FB RID: 507
		[SerializeField]
		[Range(0f, 1f)]
		private float m_fitnes;
	}
}
