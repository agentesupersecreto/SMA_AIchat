using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Clases;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica
{
	// Token: 0x0200006E RID: 110
	[CreateAssetMenu(fileName = "SujetoAlteradoresPersonalidadFemeninos", menuName = "Objetos/Genetica/Sujeto Alteradores Personalidad Femeninos")]
	public class SujetoAlteradoresPersonalidadFemeninos : AplicableScriptable, ISujeto, ISujetoConjuntoDeGenesInyectable
	{
		// Token: 0x06000509 RID: 1289 RVA: 0x000122EE File Offset: 0x000104EE
		void ISujetoConjuntoDeGenesInyectable.InyectarConjuntos(IConjuntoDeGenes[] inyeccion)
		{
			this.m_Conjuntos = inyeccion;
			this.m_conjuntoPorNombre = null;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x000122FE File Offset: 0x000104FE
		public IReadOnlyList<IConjuntoDeGenes> conjuntos
		{
			get
			{
				return this.m_Conjuntos;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x00012306 File Offset: 0x00010506
		public IReadOnlyDictionary<string, IConjuntoDeGenes> conjuntoPorNombre
		{
			get
			{
				if (this.m_conjuntoPorNombre == null)
				{
					this.m_conjuntoPorNombre = this.m_Conjuntos.ToDictionary((IConjuntoDeGenes c) => c.conjuntoName);
				}
				return this.m_conjuntoPorNombre;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x00012346 File Offset: 0x00010546
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0001234E File Offset: 0x0001054E
		[Obsolete("", true)]
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

		// Token: 0x0600050E RID: 1294 RVA: 0x0001235C File Offset: 0x0001055C
		[Obsolete("", true)]
		public void ResetFitnes()
		{
			this.m_fitnes = 0f;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00012369 File Offset: 0x00010569
		public void FixSymetria(float mod = 1f)
		{
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0001236B File Offset: 0x0001056B
		public void Codificar(IReadOnlyDictionary<object, GeneItem> cadena)
		{
			this.@base.PrepareAlteradoresDicc();
			DecodificadorDeGenes.Codificar(this.@base.preparedAlteradoresDicc, cadena);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00012389 File Offset: 0x00010589
		public void Decodificar(IDictionary<object, GeneItem> cadenaResultado)
		{
			DecodificadorDeGenes.Decodificar(this.@base.ObtenerAlteradorModificadores(), cadenaResultado);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001239C File Offset: 0x0001059C
		public IReadOnlyDictionary<string, IReadOnlyDictionary<int, GeneItem>> Decodificar1()
		{
			return DecodificadorDeGenes.DecodificarV2(this.@base.ObtenerAlteradorModificadores());
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000123AE File Offset: 0x000105AE
		public IReadOnlyDictionary<object, GeneItem> Decodificar2()
		{
			return DecodificadorDeGenes.Decodificar(this.@base.ObtenerAlteradorModificadores());
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000123C0 File Offset: 0x000105C0
		public void Randomizar(ISujeto source, int nivelDeSource, TipoDeRandomizadoParaSujeto tipo)
		{
			SujetoAlteradoresPersonalidadFemeninos sujetoAlteradoresPersonalidadFemeninos = source as SujetoAlteradoresPersonalidadFemeninos;
			if (sujetoAlteradoresPersonalidadFemeninos == null)
			{
				Debug.LogError("source debe ser de tipo " + typeof(SujetoAlteradoresPersonalidadFemeninos).Name, this);
				return;
			}
			sujetoAlteradoresPersonalidadFemeninos.@base.PrepareAlteradoresDicc();
			this.@base.Randomizar(sujetoAlteradoresPersonalidadFemeninos.@base.preparedAlteradoresDicc, tipo);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001241F File Offset: 0x0001061F
		public void Destruir()
		{
			if (this.@base != null && !TValleEditorTools.IsPersistent(this.@base))
			{
				Object.Destroy(this.@base);
			}
			if (!TValleEditorTools.IsPersistent(this))
			{
				Object.Destroy(this);
			}
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00012468 File Offset: 0x00010668
		string ISujeto.get_name()
		{
			return base.name;
		}

		// Token: 0x04000239 RID: 569
		[SerializeField]
		[SerializeReference]
		private IConjuntoDeGenes[] m_Conjuntos = ConjuntosDePersonalidad.conjuntosCopia;

		// Token: 0x0400023A RID: 570
		private Dictionary<string, IConjuntoDeGenes> m_conjuntoPorNombre;

		// Token: 0x0400023B RID: 571
		public MapaDeAlteracionesPersonalidadFemeninaBase @base;

		// Token: 0x0400023C RID: 572
		[SerializeField]
		[Range(0f, 1f)]
		[Obsolete("", true)]
		private float m_fitnes;
	}
}
