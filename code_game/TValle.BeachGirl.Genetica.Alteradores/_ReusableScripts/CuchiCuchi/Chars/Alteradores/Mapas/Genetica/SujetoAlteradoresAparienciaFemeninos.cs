using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Clases;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica
{
	// Token: 0x0200006D RID: 109
	[CreateAssetMenu(fileName = "SujetoAlteradoresAparienciaFemeninos", menuName = "Objetos/Genetica/Sujeto Alteradores Apariencia Femeninos")]
	public class SujetoAlteradoresAparienciaFemeninos : AplicableScriptable, ISujeto, ISujetoConjuntoDeGenesInyectable
	{
		// Token: 0x060004FA RID: 1274 RVA: 0x000120B2 File Offset: 0x000102B2
		void ISujetoConjuntoDeGenesInyectable.InyectarConjuntos(IConjuntoDeGenes[] inyeccion)
		{
			this.m_Conjuntos = inyeccion;
			this.m_conjuntoPorNombre = null;
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x000120C2 File Offset: 0x000102C2
		public IReadOnlyList<IConjuntoDeGenes> conjuntos
		{
			get
			{
				return this.m_Conjuntos;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x000120CA File Offset: 0x000102CA
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

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0001210A File Offset: 0x0001030A
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x00012112 File Offset: 0x00010312
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

		// Token: 0x060004FF RID: 1279 RVA: 0x00012120 File Offset: 0x00010320
		[Obsolete("", true)]
		public void ResetFitnes()
		{
			this.m_fitnes = 0f;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00012130 File Offset: 0x00010330
		public void FixSymetria(float mod = 1f)
		{
			IReadOnlyList<ModificadoresDeAlterador> readOnlyList = this.@base.ObtenerAlteradorModificadores();
			foreach (ModificadoresDeAlterador modificadoresDeAlterador in readOnlyList)
			{
				string alteradorNombre = modificadoresDeAlterador.alteradorName;
				string otroName = DiccionarioDeNombresDeAlteradores<DiccionarioDeNombresDeAlteradoresFemeninos>.ParDe(alteradorNombre);
				if (!string.IsNullOrEmpty(otroName))
				{
					ModificadoresDeAlterador modificadoresDeAlterador2 = readOnlyList.FirstOrDefault((ModificadoresDeAlterador m) => m.alteradorName == alteradorNombre);
					ModificadoresDeAlterador modificadoresDeAlterador3 = readOnlyList.FirstOrDefault((ModificadoresDeAlterador m) => m.alteradorName == otroName);
					if (modificadoresDeAlterador2 != null && modificadoresDeAlterador3 != null)
					{
						modificadoresDeAlterador2.FixSymetria(modificadoresDeAlterador3, mod);
					}
				}
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000121E8 File Offset: 0x000103E8
		public void Codificar(IReadOnlyDictionary<object, GeneItem> cadena)
		{
			this.@base.PrepareAlteradoresDicc();
			DecodificadorDeGenes.Codificar(this.@base.preparedAlteradoresDicc, cadena);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00012206 File Offset: 0x00010406
		public void Decodificar(IDictionary<object, GeneItem> cadenaResultado)
		{
			DecodificadorDeGenes.Decodificar(this.@base.ObtenerAlteradorModificadores(), cadenaResultado);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00012219 File Offset: 0x00010419
		public IReadOnlyDictionary<string, IReadOnlyDictionary<int, GeneItem>> Decodificar1()
		{
			return DecodificadorDeGenes.DecodificarV2(this.@base.ObtenerAlteradorModificadores());
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0001222B File Offset: 0x0001042B
		public IReadOnlyDictionary<object, GeneItem> Decodificar2()
		{
			return DecodificadorDeGenes.Decodificar(this.@base.ObtenerAlteradorModificadores());
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0001223D File Offset: 0x0001043D
		public virtual void Destruir()
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

		// Token: 0x06000506 RID: 1286 RVA: 0x00012274 File Offset: 0x00010474
		public void Randomizar(ISujeto source, int nivelDeSource, TipoDeRandomizadoParaSujeto tipo)
		{
			SujetoAlteradoresAparienciaFemeninos sujetoAlteradoresAparienciaFemeninos = source as SujetoAlteradoresAparienciaFemeninos;
			if (sujetoAlteradoresAparienciaFemeninos == null)
			{
				Debug.LogError("source debe ser de tipo " + typeof(SujetoAlteradoresAparienciaFemeninos).Name, this);
				return;
			}
			sujetoAlteradoresAparienciaFemeninos.@base.PrepareAlteradoresDicc();
			this.@base.Randomizar(sujetoAlteradoresAparienciaFemeninos.@base.preparedAlteradoresDicc, tipo);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000122E6 File Offset: 0x000104E6
		string ISujeto.get_name()
		{
			return base.name;
		}

		// Token: 0x04000235 RID: 565
		[SerializeField]
		[SerializeReference]
		private IConjuntoDeGenes[] m_Conjuntos = ConjuntosDeAparienciaFisica.conjuntosCopia;

		// Token: 0x04000236 RID: 566
		private Dictionary<string, IConjuntoDeGenes> m_conjuntoPorNombre;

		// Token: 0x04000237 RID: 567
		public MapaDeAlteracionesAparienciaFemeninaBase @base;

		// Token: 0x04000238 RID: 568
		[Obsolete("", true)]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_fitnes;
	}
}
