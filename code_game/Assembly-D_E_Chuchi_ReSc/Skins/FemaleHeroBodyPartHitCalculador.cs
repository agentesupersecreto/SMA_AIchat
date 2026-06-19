using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins.Scriptables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000051 RID: 81
	public sealed class FemaleHeroBodyPartHitCalculador : Singleton<FemaleHeroBodyPartHitCalculador>
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00008493 File Offset: 0x00006693
		public FemaleHeroBodyPartHitCalculador.HitSkins hitSkins
		{
			get
			{
				return this.m_HitSkins;
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000849B File Offset: 0x0000669B
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				text = "Check si Partes y Skins son compatibles",
				playTimeVisible = false
			};
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000084B4 File Offset: 0x000066B4
		public override void Aplicar2()
		{
			base.Aplicar2();
			Dictionary<Vector3, List<SkinnedMeshRenderer>> dictionary = new Dictionary<Vector3, List<SkinnedMeshRenderer>>(FemaleHeroBodyPartHitCalculador.PartsBase.Comparer.@default);
			HashSet<Vector3> hashSet = new HashSet<Vector3>(FemaleHeroBodyPartHitCalculador.PartsBase.Comparer.@default);
			MeshFilter[] componentsInChildren = this.m_BodyParts.prefab.GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				foreach (Vector3 vector in componentsInChildren[i].sharedMesh.vertices)
				{
					hashSet.Add(vector);
				}
			}
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_HitSkins.prefab.GetComponentsInChildren<SkinnedMeshRenderer>())
			{
				foreach (Vector3 vector2 in skinnedMeshRenderer.sharedMesh.vertices)
				{
					List<SkinnedMeshRenderer> list;
					if (!dictionary.TryGetValue(vector2, out list))
					{
						list = new List<SkinnedMeshRenderer>();
						dictionary.Add(vector2, list);
					}
					list.Add(skinnedMeshRenderer);
				}
			}
			HashSet<SkinnedMeshRenderer> hashSet2 = new HashSet<SkinnedMeshRenderer>();
			foreach (KeyValuePair<Vector3, List<SkinnedMeshRenderer>> keyValuePair in dictionary)
			{
				if (!hashSet.Contains(keyValuePair.Key))
				{
					Debug.LogError("vertex No existe en body partes " + keyValuePair.Key.ToString(), this);
					Vector3 vector3 = Vector3.zero;
					float num = float.MaxValue;
					foreach (Vector3 vector4 in hashSet)
					{
						float num2 = Vector3.Distance(vector4, keyValuePair.Key);
						if (num2 < num)
						{
							num = num2;
							vector3 = vector4;
						}
					}
					Debug.LogError("vertex mas cercano " + vector3.ToString() + ". a distancia: " + num.ToString(), this);
					for (int k = 0; k < keyValuePair.Value.Count; k++)
					{
						hashSet2.Add(keyValuePair.Value[k]);
					}
				}
			}
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in hashSet2)
			{
				Debug.LogError("Hit skin: " + skinnedMeshRenderer2.name + ". no es compatible con body partes", this);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000876C File Offset: 0x0000696C
		protected override void InitData(bool esEditorTime)
		{
			if (esEditorTime)
			{
				return;
			}
			this.m_BodyParts.OnInit();
			this.m_HitSkins.OnInit(this.m_BodyParts);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00008790 File Offset: 0x00006990
		public HitPartEnum ObtenerParteEnumDeHitPart(string Name)
		{
			HitPartEnum partEnum;
			try
			{
				partEnum = this.m_HitSkins.partsDic[Name].partEnum;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("ObtenerParteEnumDeHitPart: no se encontro " + typeof(HitPartEnum).Name + " de " + Name);
				throw ex;
			}
			return partEnum;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000087EC File Offset: 0x000069EC
		private BodyPartEnum ObtenerBodyPartDeTriangulo(HitPartEnum hitPart, int triangleIndex, Collider own, out bool encontrado)
		{
			return this.ObtenerBodyPartDeTriangulo(this.m_HitSkins.enumPartsDic[(int)hitPart], triangleIndex, own, out encontrado);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000880C File Offset: 0x00006A0C
		private BodyPartEnum ObtenerBodyPartDeTriangulo(FemaleHeroBodyPartHitCalculador.HitPart hitPart, int triangleIndex, Collider own, out bool encontrado)
		{
			BodyPartEnum bodyPartEnum = this.DefaultResult(hitPart.partEnum);
			if (!hitPart.triangles.ContieneIndex(triangleIndex))
			{
				Debug.LogError("Indice Fuera de Range: " + triangleIndex.ToString() + ", en collider: " + own.name);
				encontrado = false;
				return bodyPartEnum;
			}
			int num = triangleIndex * 3;
			int num2;
			int num3;
			int num4;
			try
			{
				num2 = hitPart.triangles[num];
				num3 = hitPart.triangles[num + 1];
				num4 = hitPart.triangles[num + 2];
			}
			catch (Exception ex)
			{
				Debug.LogError("Indice Fuera de Range: " + triangleIndex.ToString() + ", en collider: " + own.name);
				throw ex;
			}
			Vector3 vector = hitPart.vertices[num2];
			Vector3 vector2 = hitPart.vertices[num3];
			Vector3 vector3 = hitPart.vertices[num4];
			FemaleHeroBodyPartHitCalculador.PartesDeVertice<BodyPartEnum> partesDeVertice;
			if (!this.m_BodyParts.verticesDic.TryGetValue(vector, out partesDeVertice))
			{
				encontrado = false;
				return bodyPartEnum;
			}
			FemaleHeroBodyPartHitCalculador.PartesDeVertice<BodyPartEnum> partesDeVertice2;
			if (!this.m_BodyParts.verticesDic.TryGetValue(vector2, out partesDeVertice2))
			{
				encontrado = false;
				return bodyPartEnum;
			}
			FemaleHeroBodyPartHitCalculador.PartesDeVertice<BodyPartEnum> partesDeVertice3;
			if (!this.m_BodyParts.verticesDic.TryGetValue(vector3, out partesDeVertice3))
			{
				encontrado = false;
				return bodyPartEnum;
			}
			FemaleHeroBodyPartHitCalculador.PartGenericBase<BodyPartEnum> partGenericBase = partesDeVertice.ObtenerRepetido(partesDeVertice2, partesDeVertice3);
			if (partGenericBase == null)
			{
				encontrado = false;
				return bodyPartEnum;
			}
			encontrado = true;
			bodyPartEnum = partGenericBase.partEnum;
			if (this.debug)
			{
				MonoBehaviour.print("***parte: " + partGenericBase.partEnum.ToString());
			}
			return bodyPartEnum;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00008988 File Offset: 0x00006B88
		public bool CalcularParteImpactada(HitPartEnum hitPart, RaycastHit hit, out BodyPartEnum result)
		{
			result = this.DefaultResult(hitPart);
			if (hit.collider == null)
			{
				return false;
			}
			bool flag2;
			try
			{
				bool flag;
				BodyPartEnum bodyPartEnum = this.ObtenerBodyPartDeTriangulo(hitPart, hit.triangleIndex, hit.collider, out flag);
				if (!flag)
				{
					flag2 = false;
				}
				else
				{
					result = bodyPartEnum;
					flag2 = true;
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(ex.Message);
				throw ex;
			}
			return flag2;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000089F4 File Offset: 0x00006BF4
		public bool CalcularPartesImpactadas(HitPartEnum hitPart, Collider collider, RaycastHit colliderHit, IList<BodyPartEnum> result)
		{
			MeshCollider meshCollider = collider as MeshCollider;
			if (meshCollider == null)
			{
				Debug.LogWarning("solo se puede CalcularPartesImpactadas de  MeshColliders.");
				return false;
			}
			if (meshCollider.convex)
			{
				throw new InvalidOperationException("no se puede calcular la parte impactada de un MeshCollider convexo");
			}
			if (colliderHit.collider != collider)
			{
				throw new InvalidOperationException("no se puede calcular la parte impactada sin un hit de collider: " + collider.name);
			}
			bool flag;
			try
			{
				if (colliderHit.collider == null)
				{
					Debug.LogWarning("RaycastHit defectuosa, se devolvera false, collider: " + collider.name + ", hit part enum: " + hitPart.ToString());
					flag = false;
				}
				else
				{
					bool flag2;
					BodyPartEnum bodyPartEnum = this.ObtenerBodyPartDeTriangulo(hitPart, colliderHit.triangleIndex, colliderHit.collider, out flag2);
					result.Add(bodyPartEnum);
					flag = true;
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(ex.Message);
				throw ex;
			}
			finally
			{
				if (result.Count == 0)
				{
					BodyPartEnum bodyPartEnum2 = this.DefaultResult(hitPart);
					result.Add(bodyPartEnum2);
				}
			}
			return flag;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00008AFC File Offset: 0x00006CFC
		public BodyPartEnum DefaultResult(HitPartEnum hitPart)
		{
			switch (hitPart)
			{
			case HitPartEnum.torzo:
				return BodyPartEnum.pecho;
			case HitPartEnum.brazo_L:
				return BodyPartEnum.brazo_L;
			case HitPartEnum.brazo_R:
				return BodyPartEnum.brazo_R;
			case HitPartEnum.anteBrazo_L:
				return BodyPartEnum.anteBrazo_R;
			case HitPartEnum.anteBrazo_R:
				return BodyPartEnum.anteBrazo_R;
			case HitPartEnum.seno000_L:
				return BodyPartEnum.seno_L;
			case HitPartEnum.seno000_R:
				return BodyPartEnum.seno_R;
			case HitPartEnum.seno001_L:
				return BodyPartEnum.pezon_L;
			case HitPartEnum.seno001_R:
				return BodyPartEnum.pezon_R;
			case HitPartEnum.nalga_L:
				return BodyPartEnum.nalga_L;
			case HitPartEnum.nalga_R:
				return BodyPartEnum.nalga_R;
			case HitPartEnum.canilla_L:
				return BodyPartEnum.canilla_L;
			case HitPartEnum.canilla_R:
				return BodyPartEnum.canilla_R;
			case HitPartEnum.mano_L:
				return BodyPartEnum.mano_L;
			case HitPartEnum.mano_R:
				return BodyPartEnum.mano_R;
			case HitPartEnum.pie_L:
				return BodyPartEnum.pie_L;
			case HitPartEnum.pie_R:
				return BodyPartEnum.pie_R;
			case HitPartEnum.lengua:
				return BodyPartEnum.lengua;
			case HitPartEnum.cabeza:
				return BodyPartEnum.cabeza;
			case HitPartEnum.pierna_L:
				return BodyPartEnum.pierna_L;
			case HitPartEnum.pierna_R:
				return BodyPartEnum.pierna_R;
			}
			throw new ArgumentOutOfRangeException(hitPart.ToString());
		}

		// Token: 0x0400011E RID: 286
		[SerializeField]
		private FemaleHeroBodyPartHitCalculador.BodyParts m_BodyParts;

		// Token: 0x0400011F RID: 287
		[SerializeField]
		private FemaleHeroBodyPartHitCalculador.HitSkins m_HitSkins;

		// Token: 0x04000120 RID: 288
		public bool debug;

		// Token: 0x02000052 RID: 82
		public abstract class PartsBase
		{
			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000266 RID: 614 RVA: 0x00008BC5 File Offset: 0x00006DC5
			public GameObject prefab
			{
				get
				{
					return this.m_PartsPrefab;
				}
			}

			// Token: 0x06000267 RID: 615 RVA: 0x00008BCD File Offset: 0x00006DCD
			public virtual void OnInit()
			{
				if (this.m_PartsPrefab == null)
				{
					throw new ArgumentNullException("m_BodyPartsPrefab", "m_BodyPartsPrefab null reference.");
				}
			}

			// Token: 0x06000268 RID: 616 RVA: 0x00008BED File Offset: 0x00006DED
			protected virtual void AddToBodyPart(FemaleHeroBodyPartHitCalculador.PartBase part, string name)
			{
				this.InitParte(part, name);
			}

			// Token: 0x06000269 RID: 617
			protected abstract void InitParte(FemaleHeroBodyPartHitCalculador.PartBase part, string name);

			// Token: 0x04000121 RID: 289
			[SerializeField]
			protected GameObject m_PartsPrefab;

			// Token: 0x02000053 RID: 83
			public class Comparer : IEqualityComparer<Vector3>
			{
				// Token: 0x0600026B RID: 619 RVA: 0x00008BF7 File Offset: 0x00006DF7
				public bool Equals(Vector3 a, Vector3 b)
				{
					return a == b;
				}

				// Token: 0x0600026C RID: 620 RVA: 0x00008C00 File Offset: 0x00006E00
				public int GetHashCode(Vector3 a)
				{
					return a.GetHashCode();
				}

				// Token: 0x04000122 RID: 290
				public static readonly FemaleHeroBodyPartHitCalculador.PartsBase.Comparer @default = new FemaleHeroBodyPartHitCalculador.PartsBase.Comparer();
			}
		}

		// Token: 0x02000054 RID: 84
		public abstract class PartsGenericBase<Tpar, Tpart, Tenum> : FemaleHeroBodyPartHitCalculador.PartsBase where Tpar : FemaleHeroBodyPartHitCalculador.ParBase<Tpart> where Tpart : FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum>
		{
			// Token: 0x0600026F RID: 623
			protected abstract int Convertir(Tenum enu);

			// Token: 0x06000270 RID: 624 RVA: 0x00008C1B File Offset: 0x00006E1B
			protected virtual void AddToBodyPart(Tpar par, BoneNameIndexPar namePar)
			{
				this.AddToBodyPart(par.l, namePar.l);
				this.AddToBodyPart(par.r, namePar.r);
			}

			// Token: 0x06000271 RID: 625 RVA: 0x00008C58 File Offset: 0x00006E58
			protected override void AddToBodyPart(FemaleHeroBodyPartHitCalculador.PartBase part, string name)
			{
				base.AddToBodyPart(part, name);
				try
				{
					Tpart tpart = (Tpart)((object)part);
					this.AddToVertices(tpart);
					try
					{
						this.enumPartsDic.Add(this.Convertir(tpart.partEnum), tpart);
					}
					catch (Exception ex)
					{
						string text = "Exception agregando parte a deccionario, parte repetida : ";
						Tenum partEnum = tpart.partEnum;
						Debug.LogWarning(text + ((partEnum != null) ? partEnum.ToString() : null));
						throw ex;
					}
					try
					{
						this.partsDic.Add(name, tpart);
					}
					catch (Exception ex2)
					{
						Debug.LogWarning("Exception agregando parte a deccionario, parte repetida : " + name);
						throw ex2;
					}
				}
				catch (Exception ex3)
				{
					Debug.LogWarning("Exception en AddToBodyPart: " + ex3.Message);
					throw ex3;
				}
			}

			// Token: 0x06000272 RID: 626 RVA: 0x00008D38 File Offset: 0x00006F38
			protected virtual void AddToBodyPart(FemaleHeroBodyPartHitCalculador.PartBase part, MapaDeHitParts.SingleWithMainBone name)
			{
				this.AddToBodyPart(part, name.name);
			}

			// Token: 0x06000273 RID: 627 RVA: 0x00008D47 File Offset: 0x00006F47
			protected virtual void AddToBodyPart(FemaleHeroBodyPartHitCalculador.ParHitPart par, MapaDeHitParts.ParWithMainBone namePar)
			{
				this.AddToBodyPart(par.l, namePar.l);
				this.AddToBodyPart(par.r, namePar.r);
			}

			// Token: 0x06000274 RID: 628 RVA: 0x00008D70 File Offset: 0x00006F70
			protected void AddToVertices(FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum> part)
			{
				foreach (Vector3 vector in part.vertices)
				{
					FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum> partesDeVertice;
					if (!this.verticesDic.TryGetValue(vector, out partesDeVertice))
					{
						partesDeVertice = new FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum>(vector);
						this.verticesDic.Add(vector, partesDeVertice);
					}
					partesDeVertice.AddParte(part);
				}
			}

			// Token: 0x04000123 RID: 291
			public Dictionary<int, Tpart> enumPartsDic = new Dictionary<int, Tpart>();

			// Token: 0x04000124 RID: 292
			public Dictionary<string, Tpart> partsDic = new Dictionary<string, Tpart>();

			// Token: 0x04000125 RID: 293
			public Dictionary<Vector3, FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum>> verticesDic = new Dictionary<Vector3, FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum>>(FemaleHeroBodyPartHitCalculador.PartsBase.Comparer.@default);
		}

		// Token: 0x02000055 RID: 85
		[Serializable]
		public class BodyParts : FemaleHeroBodyPartHitCalculador.PartsGenericBase<FemaleHeroBodyPartHitCalculador.ParBodyPart, FemaleHeroBodyPartHitCalculador.BodyPart, BodyPartEnum>
		{
			// Token: 0x06000276 RID: 630 RVA: 0x00008DF4 File Offset: 0x00006FF4
			public override void OnInit()
			{
				base.OnInit();
				List<MeshFilter> list = new List<MeshFilter>(70);
				this.m_PartsPrefab.GetComponentsInChildren<MeshFilter>(true, list);
				this.m_rendersDic = new Dictionary<string, MeshFilter>(list.Count);
				list.ForEach(delegate(MeshFilter r)
				{
					this.m_rendersDic.Add(r.name, r);
				});
				if (this.m_mapa == null)
				{
					throw new ArgumentNullException("m_mapa", "m_mapa null reference.");
				}
				this.AddToBodyPart(this.partes.cabeza, this.m_mapa.cabeza.cabeza);
				this.AddToBodyPart(this.partes.cuello, this.m_mapa.cabeza.cuello);
				this.AddToBodyPart(this.partes.mandibula, this.m_mapa.cabeza.mandibula);
				this.AddToBodyPart(this.partes.boca, this.m_mapa.cabeza.boca);
				this.AddToBodyPart(this.partes.bocaInterno, this.m_mapa.cabeza.bocaInterno);
				this.AddToBodyPart(this.partes.nariz, this.m_mapa.cabeza.nariz);
				this.AddToBodyPart(this.partes.mejillas, this.m_mapa.cabeza.mejillas);
				this.AddToBodyPart(this.partes.ojos, this.m_mapa.cabeza.ojos);
				this.AddToBodyPart(this.partes.ojosInterno, this.m_mapa.cabeza.ojosInterno);
				this.AddToBodyPart(this.partes.cejas, this.m_mapa.cabeza.cejas);
				this.AddToBodyPart(this.partes.cienes, this.m_mapa.cabeza.cienes);
				this.AddToBodyPart(this.partes.frente, this.m_mapa.cabeza.frente);
				this.AddToBodyPart(this.partes.pecho, this.m_mapa.cuerpo.pecho);
				this.AddToBodyPart(this.partes.espalda, this.m_mapa.cuerpo.espalda);
				this.AddToBodyPart(this.partes.hombros, this.m_mapa.cuerpo.hombros);
				this.AddToBodyPart(this.partes.axilas, this.m_mapa.cuerpo.axilas);
				this.AddToBodyPart(this.partes.brazos, this.m_mapa.cuerpo.brazos);
				this.AddToBodyPart(this.partes.anteBrazos, this.m_mapa.cuerpo.anteBrazos);
				this.AddToBodyPart(this.partes.manos, this.m_mapa.cuerpo.manos);
				this.AddToBodyPart(this.partes.senos, this.m_mapa.cuerpo.senos);
				this.AddToBodyPart(this.partes.pezones, this.m_mapa.cuerpo.pezones);
				this.AddToBodyPart(this.partes.abdomen, this.m_mapa.cuerpo.abdomen);
				this.AddToBodyPart(this.partes.cintura, this.m_mapa.cuerpo.cintura);
				this.AddToBodyPart(this.partes.caderas, this.m_mapa.cuerpo.caderas);
				this.AddToBodyPart(this.partes.coxis, this.m_mapa.cuerpo.coxis);
				this.AddToBodyPart(this.partes.vientre, this.m_mapa.cuerpo.vientre);
				this.AddToBodyPart(this.partes.nalgas, this.m_mapa.cuerpo.nalgas);
				this.AddToBodyPart(this.partes.vagina, this.m_mapa.cuerpo.vagina);
				this.AddToBodyPart(this.partes.perineo, this.m_mapa.cuerpo.perineo);
				this.AddToBodyPart(this.partes.anoHole, this.m_mapa.cuerpo.anoHole);
				this.AddToBodyPart(this.partes.vagHole, this.m_mapa.cuerpo.vagHole);
				this.AddToBodyPart(this.partes.hombligo, this.m_mapa.cuerpo.hombligo);
				this.AddToBodyPart(this.partes.piernas, this.m_mapa.cuerpo.piernas);
				this.AddToBodyPart(this.partes.rodillas, this.m_mapa.cuerpo.rodillas);
				this.AddToBodyPart(this.partes.canillas, this.m_mapa.cuerpo.canillas);
				this.AddToBodyPart(this.partes.pies, this.m_mapa.cuerpo.pies);
			}

			// Token: 0x06000277 RID: 631 RVA: 0x0000386D File Offset: 0x00001A6D
			protected override int Convertir(BodyPartEnum enu)
			{
				return (int)enu;
			}

			// Token: 0x06000278 RID: 632 RVA: 0x00009304 File Offset: 0x00007504
			protected override void InitParte(FemaleHeroBodyPartHitCalculador.PartBase part, string name)
			{
				MeshFilter meshFilter = this.m_rendersDic[name];
				Mesh sharedMesh = meshFilter.sharedMesh;
				part.Init(meshFilter, sharedMesh.triangles, sharedMesh.vertices);
			}

			// Token: 0x04000126 RID: 294
			[SerializeField]
			private MapaDeBodyParts m_mapa;

			// Token: 0x04000127 RID: 295
			[ReadOnlyUI]
			[NonSerialized]
			public FemaleHeroBodyPartHitCalculador.BodyParts.Partes partes = new FemaleHeroBodyPartHitCalculador.BodyParts.Partes();

			// Token: 0x04000128 RID: 296
			protected Dictionary<string, MeshFilter> m_rendersDic;

			// Token: 0x02000056 RID: 86
			[Serializable]
			public class Partes
			{
				// Token: 0x04000129 RID: 297
				public FemaleHeroBodyPartHitCalculador.BodyPart cabeza = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.cabeza);

				// Token: 0x0400012A RID: 298
				public FemaleHeroBodyPartHitCalculador.BodyPart cuello = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.cuello);

				// Token: 0x0400012B RID: 299
				public FemaleHeroBodyPartHitCalculador.BodyPart mandibula = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.mandibula);

				// Token: 0x0400012C RID: 300
				public FemaleHeroBodyPartHitCalculador.BodyPart boca = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.boca);

				// Token: 0x0400012D RID: 301
				public FemaleHeroBodyPartHitCalculador.BodyPart bocaInterno = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.bocaInterno);

				// Token: 0x0400012E RID: 302
				public FemaleHeroBodyPartHitCalculador.BodyPart nariz = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.nariz);

				// Token: 0x0400012F RID: 303
				public FemaleHeroBodyPartHitCalculador.ParBodyPart mejillas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.mejilla_L, BodyPartEnum.mejilla_R);

				// Token: 0x04000130 RID: 304
				public FemaleHeroBodyPartHitCalculador.ParBodyPart ojos = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.ojo_L, BodyPartEnum.ojo_R);

				// Token: 0x04000131 RID: 305
				public FemaleHeroBodyPartHitCalculador.ParBodyPart ojosInterno = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.ojoInterno_L, BodyPartEnum.ojoInterno_R);

				// Token: 0x04000132 RID: 306
				public FemaleHeroBodyPartHitCalculador.ParBodyPart cejas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.ceja_L, BodyPartEnum.ceja_R);

				// Token: 0x04000133 RID: 307
				public FemaleHeroBodyPartHitCalculador.ParBodyPart cienes = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.ciene_L, BodyPartEnum.ciene_R);

				// Token: 0x04000134 RID: 308
				public FemaleHeroBodyPartHitCalculador.BodyPart frente = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.frente);

				// Token: 0x04000135 RID: 309
				public FemaleHeroBodyPartHitCalculador.BodyPart pecho = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.pecho);

				// Token: 0x04000136 RID: 310
				public FemaleHeroBodyPartHitCalculador.BodyPart espalda = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.espalda);

				// Token: 0x04000137 RID: 311
				public FemaleHeroBodyPartHitCalculador.ParBodyPart hombros = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.hombro_L, BodyPartEnum.hombro_R);

				// Token: 0x04000138 RID: 312
				public FemaleHeroBodyPartHitCalculador.ParBodyPart axilas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.axila_L, BodyPartEnum.axila_R);

				// Token: 0x04000139 RID: 313
				public FemaleHeroBodyPartHitCalculador.ParBodyPart brazos = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.brazo_L, BodyPartEnum.brazo_R);

				// Token: 0x0400013A RID: 314
				public FemaleHeroBodyPartHitCalculador.ParBodyPart anteBrazos = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.anteBrazo_L, BodyPartEnum.anteBrazo_R);

				// Token: 0x0400013B RID: 315
				public FemaleHeroBodyPartHitCalculador.ParBodyPart manos = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.mano_L, BodyPartEnum.mano_R);

				// Token: 0x0400013C RID: 316
				public FemaleHeroBodyPartHitCalculador.ParBodyPart senos = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.seno_L, BodyPartEnum.seno_R);

				// Token: 0x0400013D RID: 317
				public FemaleHeroBodyPartHitCalculador.ParBodyPart pezones = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.pezon_L, BodyPartEnum.pezon_R);

				// Token: 0x0400013E RID: 318
				public FemaleHeroBodyPartHitCalculador.BodyPart abdomen = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.abdomen);

				// Token: 0x0400013F RID: 319
				public FemaleHeroBodyPartHitCalculador.BodyPart cintura = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.cintura);

				// Token: 0x04000140 RID: 320
				public FemaleHeroBodyPartHitCalculador.ParBodyPart caderas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.cadera_L, BodyPartEnum.cadera_R);

				// Token: 0x04000141 RID: 321
				public FemaleHeroBodyPartHitCalculador.BodyPart coxis = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.coxis);

				// Token: 0x04000142 RID: 322
				public FemaleHeroBodyPartHitCalculador.BodyPart vientre = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.vientre);

				// Token: 0x04000143 RID: 323
				public FemaleHeroBodyPartHitCalculador.ParBodyPart nalgas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.nalga_L, BodyPartEnum.nalga_R);

				// Token: 0x04000144 RID: 324
				public FemaleHeroBodyPartHitCalculador.BodyPart vagina = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.vagina);

				// Token: 0x04000145 RID: 325
				public FemaleHeroBodyPartHitCalculador.BodyPart perineo = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.perineo);

				// Token: 0x04000146 RID: 326
				public FemaleHeroBodyPartHitCalculador.BodyPart anoHole = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.anoHole);

				// Token: 0x04000147 RID: 327
				public FemaleHeroBodyPartHitCalculador.BodyPart vagHole = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.vagHole);

				// Token: 0x04000148 RID: 328
				public FemaleHeroBodyPartHitCalculador.BodyPart hombligo = new FemaleHeroBodyPartHitCalculador.BodyPart(BodyPartEnum.hombligo);

				// Token: 0x04000149 RID: 329
				public FemaleHeroBodyPartHitCalculador.ParBodyPart piernas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.pierna_L, BodyPartEnum.pierna_R);

				// Token: 0x0400014A RID: 330
				public FemaleHeroBodyPartHitCalculador.ParBodyPart rodillas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.rodilla_L, BodyPartEnum.rodilla_R);

				// Token: 0x0400014B RID: 331
				public FemaleHeroBodyPartHitCalculador.ParBodyPart canillas = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.canilla_L, BodyPartEnum.canilla_R);

				// Token: 0x0400014C RID: 332
				public FemaleHeroBodyPartHitCalculador.ParBodyPart pies = new FemaleHeroBodyPartHitCalculador.ParBodyPart(BodyPartEnum.pie_L, BodyPartEnum.pie_R);
			}
		}

		// Token: 0x02000057 RID: 87
		[Serializable]
		public class HitSkins : FemaleHeroBodyPartHitCalculador.PartsGenericBase<FemaleHeroBodyPartHitCalculador.ParHitPart, FemaleHeroBodyPartHitCalculador.HitPart, HitPartEnum>
		{
			// Token: 0x170000DE RID: 222
			// (get) Token: 0x0600027C RID: 636 RVA: 0x00009562 File Offset: 0x00007762
			public MapaDeHitParts mapa
			{
				get
				{
					return this.m_mapa;
				}
			}

			// Token: 0x0600027D RID: 637 RVA: 0x0000956A File Offset: 0x0000776A
			public void OnInit(FemaleHeroBodyPartHitCalculador.BodyParts bodyParts)
			{
				this.OnInit();
			}

			// Token: 0x0600027E RID: 638 RVA: 0x0000386D File Offset: 0x00001A6D
			protected override int Convertir(HitPartEnum enu)
			{
				return (int)enu;
			}

			// Token: 0x0600027F RID: 639 RVA: 0x00009574 File Offset: 0x00007774
			public override void OnInit()
			{
				base.OnInit();
				List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>(70);
				this.m_PartsPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(true, list);
				this.m_rendersDic = new Dictionary<string, SkinnedMeshRenderer>(list.Count);
				list.ForEach(delegate(SkinnedMeshRenderer r)
				{
					this.m_rendersDic.Add(r.name, r);
				});
				if (this.m_mapa == null)
				{
					throw new ArgumentNullException("m_mapa", "m_mapa null reference.");
				}
				this.AddToBodyPart(this.partes.torzo, this.m_mapa.partes.torzo);
				this.AddToBodyPart(this.partes.cabeza, this.m_mapa.partes.cabeza);
				this.AddToBodyPart(this.partes.brazos, this.m_mapa.partes.brazos);
				this.AddToBodyPart(this.partes.anteBrazos, this.m_mapa.partes.anteBrazos);
				this.AddToBodyPart(this.partes.senos000, this.m_mapa.partes.senos000);
				this.AddToBodyPart(this.partes.senos001, this.m_mapa.partes.senos001);
				this.AddToBodyPart(this.partes.nalgas, this.m_mapa.partes.nalgas);
				this.AddToBodyPart(this.partes.piernas, this.m_mapa.partes.piernas);
				this.AddToBodyPart(this.partes.canillas, this.m_mapa.partes.canillas);
			}

			// Token: 0x06000280 RID: 640 RVA: 0x00009708 File Offset: 0x00007908
			protected override void InitParte(FemaleHeroBodyPartHitCalculador.PartBase part, string name)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = this.m_rendersDic[name];
				Mesh sharedMesh = skinnedMeshRenderer.sharedMesh;
				part.Init(skinnedMeshRenderer, sharedMesh.triangles, sharedMesh.vertices);
			}

			// Token: 0x0400014D RID: 333
			[SerializeField]
			private MapaDeHitParts m_mapa;

			// Token: 0x0400014E RID: 334
			[ReadOnlyUI]
			[NonSerialized]
			public FemaleHeroBodyPartHitCalculador.HitSkins.Partes partes = new FemaleHeroBodyPartHitCalculador.HitSkins.Partes();

			// Token: 0x0400014F RID: 335
			protected Dictionary<string, SkinnedMeshRenderer> m_rendersDic;

			// Token: 0x02000058 RID: 88
			[Serializable]
			public class Partes
			{
				// Token: 0x04000150 RID: 336
				[Obsolete("", true)]
				[NonSerialized]
				public FemaleHeroBodyPartHitCalculador.HitPart torzoCabezaPiernas;

				// Token: 0x04000151 RID: 337
				public FemaleHeroBodyPartHitCalculador.HitPart torzo = new FemaleHeroBodyPartHitCalculador.HitPart(HitPartEnum.torzo);

				// Token: 0x04000152 RID: 338
				public FemaleHeroBodyPartHitCalculador.HitPart cabeza = new FemaleHeroBodyPartHitCalculador.HitPart(HitPartEnum.cabeza);

				// Token: 0x04000153 RID: 339
				public FemaleHeroBodyPartHitCalculador.ParHitPart brazos = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.brazo_L, HitPartEnum.brazo_R);

				// Token: 0x04000154 RID: 340
				public FemaleHeroBodyPartHitCalculador.ParHitPart anteBrazos = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.anteBrazo_L, HitPartEnum.anteBrazo_R);

				// Token: 0x04000155 RID: 341
				public FemaleHeroBodyPartHitCalculador.ParHitPart senos000 = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.seno000_L, HitPartEnum.seno000_R);

				// Token: 0x04000156 RID: 342
				public FemaleHeroBodyPartHitCalculador.ParHitPart senos001 = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.seno001_L, HitPartEnum.seno001_R);

				// Token: 0x04000157 RID: 343
				public FemaleHeroBodyPartHitCalculador.ParHitPart nalgas = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.nalga_L, HitPartEnum.nalga_R);

				// Token: 0x04000158 RID: 344
				public FemaleHeroBodyPartHitCalculador.ParHitPart piernas = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.pierna_L, HitPartEnum.pierna_R);

				// Token: 0x04000159 RID: 345
				public FemaleHeroBodyPartHitCalculador.ParHitPart canillas = new FemaleHeroBodyPartHitCalculador.ParHitPart(HitPartEnum.canilla_L, HitPartEnum.canilla_R);
			}
		}

		// Token: 0x02000059 RID: 89
		public class PartesDeVertice<Tenum>
		{
			// Token: 0x06000284 RID: 644 RVA: 0x000097F1 File Offset: 0x000079F1
			public PartesDeVertice(Vector3 vertice)
			{
				this.vertice = vertice;
			}

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x06000285 RID: 645 RVA: 0x00009816 File Offset: 0x00007A16
			// (set) Token: 0x06000286 RID: 646 RVA: 0x0000981E File Offset: 0x00007A1E
			public Vector3 vertice { get; private set; }

			// Token: 0x06000287 RID: 647 RVA: 0x00009827 File Offset: 0x00007A27
			public bool AddParte(FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum> parte)
			{
				if (this.partesSet.Add(parte))
				{
					this.partesLista.Add(parte);
					return true;
				}
				return false;
			}

			// Token: 0x06000288 RID: 648 RVA: 0x00009846 File Offset: 0x00007A46
			public bool Contains(FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum> parte)
			{
				return this.partesSet.Contains(parte);
			}

			// Token: 0x06000289 RID: 649 RVA: 0x00009854 File Offset: 0x00007A54
			public FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum> ObtenerRepetido(FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum> a, FemaleHeroBodyPartHitCalculador.PartesDeVertice<Tenum> b)
			{
				for (int i = 0; i < this.partesLista.Count; i++)
				{
					FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum> partGenericBase = this.partesLista[i];
					if (a.Contains(partGenericBase) && b.Contains(partGenericBase))
					{
						return partGenericBase;
					}
				}
				return null;
			}

			// Token: 0x0400015A RID: 346
			private HashSet<FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum>> partesSet = new HashSet<FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum>>();

			// Token: 0x0400015B RID: 347
			private List<FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum>> partesLista = new List<FemaleHeroBodyPartHitCalculador.PartGenericBase<Tenum>>();
		}

		// Token: 0x0200005A RID: 90
		public class ParBase<T> where T : FemaleHeroBodyPartHitCalculador.PartBase
		{
			// Token: 0x0400015D RID: 349
			public T r;

			// Token: 0x0400015E RID: 350
			public T l;
		}

		// Token: 0x0200005B RID: 91
		[Serializable]
		public class ParBodyPart : FemaleHeroBodyPartHitCalculador.ParBase<FemaleHeroBodyPartHitCalculador.BodyPart>
		{
			// Token: 0x0600028B RID: 651 RVA: 0x00009899 File Offset: 0x00007A99
			public ParBodyPart(BodyPartEnum l, BodyPartEnum r)
			{
				this.l = new FemaleHeroBodyPartHitCalculador.BodyPart(l);
				this.r = new FemaleHeroBodyPartHitCalculador.BodyPart(r);
			}
		}

		// Token: 0x0200005C RID: 92
		[Serializable]
		public class ParHitPart : FemaleHeroBodyPartHitCalculador.ParBase<FemaleHeroBodyPartHitCalculador.HitPart>
		{
			// Token: 0x0600028C RID: 652 RVA: 0x000098B9 File Offset: 0x00007AB9
			public ParHitPart(HitPartEnum l, HitPartEnum r)
			{
				this.l = new FemaleHeroBodyPartHitCalculador.HitPart(l);
				this.r = new FemaleHeroBodyPartHitCalculador.HitPart(r);
			}
		}

		// Token: 0x0200005D RID: 93
		public abstract class PartBase
		{
			// Token: 0x0600028D RID: 653 RVA: 0x000098D9 File Offset: 0x00007AD9
			public void Init(Object MeshReferenceHolder, int[] Triangles, Vector3[] Vertices)
			{
				this.m_meshReferenceHolder = MeshReferenceHolder;
				this.m_triangles = Triangles;
				this.m_vertices = Vertices;
			}

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x0600028E RID: 654 RVA: 0x000098F0 File Offset: 0x00007AF0
			public Vector3[] vertices
			{
				get
				{
					return this.m_vertices;
				}
			}

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x0600028F RID: 655 RVA: 0x000098F8 File Offset: 0x00007AF8
			public int[] triangles
			{
				get
				{
					return this.m_triangles;
				}
			}

			// Token: 0x0400015F RID: 351
			private int[] m_triangles;

			// Token: 0x04000160 RID: 352
			private Vector3[] m_vertices;

			// Token: 0x04000161 RID: 353
			[SerializeField]
			[ReadOnlyUI]
			private Object m_meshReferenceHolder;
		}

		// Token: 0x0200005E RID: 94
		public abstract class PartGenericBase<Tenum> : FemaleHeroBodyPartHitCalculador.PartBase
		{
			// Token: 0x06000291 RID: 657 RVA: 0x00009900 File Offset: 0x00007B00
			public PartGenericBase(Tenum partEnum)
			{
				this.m_partEnum = partEnum;
			}

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000292 RID: 658 RVA: 0x0000990F File Offset: 0x00007B0F
			public Tenum partEnum
			{
				get
				{
					return this.m_partEnum;
				}
			}

			// Token: 0x04000162 RID: 354
			[SerializeField]
			[ReadOnlyUI]
			private Tenum m_partEnum;
		}

		// Token: 0x0200005F RID: 95
		[Serializable]
		public class BodyPart : FemaleHeroBodyPartHitCalculador.PartGenericBase<BodyPartEnum>
		{
			// Token: 0x06000293 RID: 659 RVA: 0x00009917 File Offset: 0x00007B17
			public BodyPart(BodyPartEnum bpartEnum)
				: base(bpartEnum)
			{
			}

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x06000294 RID: 660 RVA: 0x00009920 File Offset: 0x00007B20
			// (set) Token: 0x06000295 RID: 661 RVA: 0x00009928 File Offset: 0x00007B28
			public FemaleHeroBodyPartHitCalculador.HitPart owner { get; private set; }

			// Token: 0x06000296 RID: 662 RVA: 0x00009931 File Offset: 0x00007B31
			public void SetOwner(FemaleHeroBodyPartHitCalculador.HitPart ow)
			{
				this.owner = ow;
			}
		}

		// Token: 0x02000060 RID: 96
		[Serializable]
		public class HitPart : FemaleHeroBodyPartHitCalculador.PartGenericBase<HitPartEnum>
		{
			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x06000297 RID: 663 RVA: 0x0000993A File Offset: 0x00007B3A
			// (set) Token: 0x06000298 RID: 664 RVA: 0x00009942 File Offset: 0x00007B42
			public HashSet<FemaleHeroBodyPartHitCalculador.BodyPart> partesSet { get; private set; }

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x06000299 RID: 665 RVA: 0x0000994B File Offset: 0x00007B4B
			// (set) Token: 0x0600029A RID: 666 RVA: 0x00009953 File Offset: 0x00007B53
			public List<FemaleHeroBodyPartHitCalculador.BodyPart> partes { get; private set; }

			// Token: 0x0600029B RID: 667 RVA: 0x0000995C File Offset: 0x00007B5C
			public HitPart(HitPartEnum bpartEnum)
				: base(bpartEnum)
			{
				this.partesSet = new HashSet<FemaleHeroBodyPartHitCalculador.BodyPart>();
				this.partes = new List<FemaleHeroBodyPartHitCalculador.BodyPart>();
			}

			// Token: 0x0600029C RID: 668 RVA: 0x0000997B File Offset: 0x00007B7B
			public void AddBodyParts(FemaleHeroBodyPartHitCalculador.BodyPart part)
			{
				if (this.partesSet.Add(part))
				{
					this.partes.Add(part);
					part.SetOwner(this);
				}
			}

			// Token: 0x0600029D RID: 669 RVA: 0x000099A0 File Offset: 0x00007BA0
			public void AddBodyParts(params FemaleHeroBodyPartHitCalculador.BodyPart[] partes)
			{
				foreach (FemaleHeroBodyPartHitCalculador.BodyPart bodyPart in partes)
				{
					this.AddBodyParts(bodyPart);
				}
			}
		}
	}
}
