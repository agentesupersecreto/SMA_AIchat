using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Skins.Physics;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen.Heredacion
{
	// Token: 0x0200006A RID: 106
	public static class HeredarHelper
	{
		// Token: 0x06000266 RID: 614 RVA: 0x000113E9 File Offset: 0x0000F5E9
		public static IEnumerator DowngradeConjuntoDeRopa(IConjuntoDeRopa conjunto, IRopaManager ropaManager, MonoBehaviour context)
		{
			Pieza pieza;
			using (IEnumerator<Pieza> enumerator = conjunto.piezas.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					pieza = enumerator.Current;
					ropaManager.OcultarPieza(pieza.ropaIDString, false, null);
				}
			}
			HashSet<PiezaDeRopaBase> hashSet = ropaManager.piezasPuestas.Where((PiezaDeRopaBase pp) => conjunto.piezas.FirstOrDefault((Pieza pieza) => pieza.ropaIDString == pp.dataDeRopa.stringId) == null).ToHashSet<PiezaDeRopaBase>();
			HashSet<Pieza> hashSet2 = conjunto.piezas.Where((Pieza pieza) => !ropaManager.piezasPuestasPorId.ContainsKey(pieza.ropaIDString)).ToHashSet<Pieza>();
			ValueTuple<Pieza, string>[] array = (from par in conjunto.piezas.Select((Pieza p) => p).Select(delegate(Pieza ps)
				{
					MapaDeRopa.RopaData ropaData = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerFirstRootData(ps.ropaIDString);
					return new ValueTuple<Pieza, string>(ps, (ropaData != null) ? ropaData.stringId : null);
				})
				where !string.IsNullOrWhiteSpace(par.Item2)
				select par).ToArray<ValueTuple<Pieza, string>>();
			HashSet<PiezaDeRopaBase> hashSet3 = new HashSet<PiezaDeRopaBase>(ropaManager.piezasPuestas.Distinct<PiezaDeRopaBase>());
			List<GlobalUpdater.Corrutina> waitngFor = new List<GlobalUpdater.Corrutina>();
			foreach (ValueTuple<Pieza, string> valueTuple in array)
			{
				try
				{
					AsyncSingleton<RopaParaAvatarUnificado>.instance.SeleccionarJerarquiaPadres(valueTuple.Item2, valueTuple.Item1.ropaIDString, HeredarHelper.padresDePiezaDeConjuntoTEMP);
					PiezaDeRopaBase piezaDeRopaBase = hashSet3.Where((PiezaDeRopaBase pp) => HeredarHelper.padresDePiezaDeConjuntoTEMP.FirstOrDefault((MapaDeRopa.RopaData padre) => padre.stringId == pp.dataDeRopa.stringId) != null).FirstOrDefault<PiezaDeRopaBase>();
					if (piezaDeRopaBase != null)
					{
						hashSet.Remove(piezaDeRopaBase);
						hashSet2.Remove(valueTuple.Item1);
						hashSet3.Remove(piezaDeRopaBase);
						GlobalUpdater.Corrutina corrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, context, HeredarHelper.RestorePiezaDeRopa(ropaManager, valueTuple.Item1, piezaDeRopaBase), null);
						waitngFor.Add(corrutina);
					}
				}
				finally
				{
					HeredarHelper.padresDePiezaDeConjuntoTEMP.Clear();
				}
			}
			foreach (Pieza pieza2 in hashSet2)
			{
				GlobalUpdater.Corrutina corrutina2 = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, context, ropaManager.AddPiezaAsync<PiezaDeRopaBase>(pieza2, null, true), null);
				waitngFor.Add(corrutina2);
			}
			foreach (PiezaDeRopaBase piezaDeRopaBase2 in hashSet)
			{
				ropaManager.RemovePieza(piezaDeRopaBase2.dataDeRopa.stringId, true, null);
			}
			bool flag;
			do
			{
				yield return null;
				flag = true;
				for (int j = 0; j < waitngFor.Count; j++)
				{
					if (!waitngFor[j].finalizada)
					{
						flag = false;
						break;
					}
				}
			}
			while (!flag);
			yield break;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00011406 File Offset: 0x0000F606
		public static IEnumerator RestoreConjuntoDeRopa(IConjuntoDeRopa conjunto, IRopaManager ropaManager, MonoBehaviour context)
		{
			Pieza pieza;
			using (IEnumerator<Pieza> enumerator = conjunto.piezas.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					pieza = enumerator.Current;
					ropaManager.OcultarPieza(pieza.ropaIDString, false, null);
				}
			}
			HashSet<PiezaDeRopaBase> hashSet = ropaManager.piezasPuestas.Where((PiezaDeRopaBase pp) => conjunto.piezas.FirstOrDefault((Pieza pieza) => pieza.ropaIDString == pp.dataDeRopa.stringId) == null).ToHashSet<PiezaDeRopaBase>();
			HashSet<Pieza> hashSet2 = conjunto.piezas.Where((Pieza pieza) => !ropaManager.piezasPuestasPorId.ContainsKey(pieza.ropaIDString)).ToHashSet<Pieza>();
			List<GlobalUpdater.Corrutina> waitngFor = new List<GlobalUpdater.Corrutina>();
			using (IEnumerator<PiezaDeRopaBase> enumerator2 = ropaManager.piezasPuestas.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					PiezaDeRopaBase puesta = enumerator2.Current;
					if (conjunto.piezas.FirstOrDefault((Pieza p) => p.ropaIDString == puesta.dataDeRopa.stringId) == null)
					{
						MapaDeRopa.RopaData root = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerFirstRootData(puesta.dataDeRopa.stringId);
						Pieza pieza2 = conjunto.piezas.FirstOrDefault((Pieza p) => p.ropaIDString == root.stringId);
						if (pieza2 != null && root.stringId != puesta.dataDeRopa.stringId)
						{
							hashSet.Remove(puesta);
							hashSet2.Remove(pieza2);
							GlobalUpdater.Corrutina corrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, context, HeredarHelper.RestorePiezaDeRopa(ropaManager, pieza2, puesta), null);
							waitngFor.Add(corrutina);
						}
					}
				}
			}
			foreach (Pieza pieza3 in hashSet2)
			{
				GlobalUpdater.Corrutina corrutina2 = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, context, ropaManager.AddPiezaAsync<PiezaDeRopaBase>(pieza3, null, true), null);
				waitngFor.Add(corrutina2);
			}
			foreach (PiezaDeRopaBase piezaDeRopaBase in hashSet)
			{
				ropaManager.RemovePieza(piezaDeRopaBase.dataDeRopa.stringId, true, null);
			}
			bool flag;
			do
			{
				yield return null;
				flag = true;
				for (int i = 0; i < waitngFor.Count; i++)
				{
					if (!waitngFor[i].finalizada)
					{
						flag = false;
						break;
					}
				}
			}
			while (!flag);
			yield break;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00011423 File Offset: 0x0000F623
		private static IEnumerator RestorePiezaDeRopa(IRopaManager ropaManager, Pieza toAdd, PiezaDeRopaBase toRemove)
		{
			PiezaDeRopaBase restaurada = null;
			yield return ropaManager.AddPiezaAsync<PiezaDeRopaBase>(toAdd, delegate(PiezaDeRopaBase r)
			{
				restaurada = r;
			}, true);
			SemenSkinController component = toRemove.GetComponent<SemenSkinController>();
			SemenSkinController componentNotNull = restaurada.GetComponentNotNull<SemenSkinController>();
			yield return HeredarHelper.TransferSemenParticles(component, componentNotNull);
			ropaManager.RemovePieza(toRemove.dataDeRopa.stringId, true, null);
			yield return null;
			yield break;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00011440 File Offset: 0x0000F640
		private static IEnumerator TransferSemenParticles(SemenSkinController from, SemenSkinController to)
		{
			if (from == null || to == null)
			{
				yield break;
			}
			while (!to.skins.isStared)
			{
				yield return null;
			}
			if (!from.skins.isCookable || !to.skins.isCookable)
			{
				yield break;
			}
			yield return to.skins.InitTriangleAttachmentSystem();
			if (!to.skins.CheckIfIsTriangleAttachable())
			{
				yield break;
			}
			List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> particleData = new List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>>();
			for (int i = 0; i < from.semenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin = from.semenSkins[i];
				if (semenSkin != null)
				{
					semenSkin.GetParticlesData(particleData);
				}
			}
			if (particleData.Count == 0)
			{
				yield break;
			}
			HeredarHelper.RemovingSkinHandler rev = new HeredarHelper.RemovingSkinHandler(particleData);
			from.skins.Cook(rev, false, null);
			while (!rev.isCooked)
			{
				yield return null;
			}
			HeredarHelper.AddingSkinHandler adding = new HeredarHelper.AddingSkinHandler(particleData);
			to.skins.Cook(adding, false, null);
			while (!adding.isCooked)
			{
				yield return null;
			}
			for (int j = 0; j < particleData.Count; j++)
			{
				ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = particleData[j];
				to.Add(ref valueTuple.Item1, ref valueTuple.Item2);
			}
			to.flagDontWait = true;
			yield break;
		}

		// Token: 0x0400029D RID: 669
		private static List<MapaDeRopa.RopaData> padresDePiezaDeConjuntoTEMP = new List<MapaDeRopa.RopaData>();

		// Token: 0x0200006B RID: 107
		private class RemovingSkinHandler : PedidoDePhyscisBakeDeSkin.IUser
		{
			// Token: 0x0600026B RID: 619 RVA: 0x00011462 File Offset: 0x0000F662
			public RemovingSkinHandler([TupleElementNames(new string[] { "selfData", "nextData" })] List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> ParticleData)
			{
				this.particleData = ParticleData;
			}

			// Token: 0x0600026C RID: 620 RVA: 0x00011474 File Offset: 0x0000F674
			void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
			{
				for (int i = 0; i < this.particleData.Count; i++)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.particleData[i];
					int num;
					int num2;
					int num3;
					Vector3 vector;
					Vector3 vector2;
					Vector3 vector3;
					Vector3 vector4;
					Vector3 vector5;
					Vector3 vector6;
					Vector3 vector7;
					Vector3 vector8;
					Vector3 vector9;
					Vector3 vector10;
					Vector3 vector11;
					Vector3 vector12;
					Vector3 vector13;
					Vector3 vector14;
					Vector3 vector15;
					Vector3 vector16;
					Vector3 vector17;
					Vector3 vector18;
					sender.GetWorldVerticesOfTriangle(valueTuple.Item1.semenData.hitData.triangleIndex, out num, out num2, out num3, out vector, out vector2, out vector3, out vector4, out vector5, out vector6, out vector7, out vector8, out vector9, out vector10, out vector11, out vector12, out vector13, out vector14, out vector15, out vector16, out vector17, out vector18);
					Vector3 barycentricCoordinate = valueTuple.Item1.semenData.hitData.barycentricCoordinate;
					Vector3 vector19 = vector13 * barycentricCoordinate.x + vector14 * barycentricCoordinate.y + vector15 * barycentricCoordinate.z;
					Vector3 vector20 = vector10 * barycentricCoordinate.x + vector11 * barycentricCoordinate.y + vector12 * barycentricCoordinate.z;
					valueTuple.Item1.semenData.hitData.wNormal = vector19;
					valueTuple.Item1.semenData.hitData.wPoint = vector20;
					int num4;
					int num5;
					int num6;
					Vector3 vector21;
					Vector3 vector22;
					Vector3 vector23;
					Vector3 vector24;
					Vector3 vector25;
					Vector3 vector26;
					Vector3 vector27;
					Vector3 vector28;
					Vector3 vector29;
					Vector3 vector30;
					Vector3 vector31;
					Vector3 vector32;
					Vector3 vector33;
					Vector3 vector34;
					Vector3 vector35;
					Vector3 vector36;
					Vector3 vector37;
					Vector3 vector38;
					sender.GetWorldVerticesOfTriangle(valueTuple.Item2.hitData.triangleIndex, out num4, out num5, out num6, out vector21, out vector22, out vector23, out vector24, out vector25, out vector26, out vector27, out vector28, out vector29, out vector30, out vector31, out vector32, out vector33, out vector34, out vector35, out vector36, out vector37, out vector38);
					Vector3 barycentricCoordinate2 = valueTuple.Item2.hitData.barycentricCoordinate;
					Vector3 vector39 = vector33 * barycentricCoordinate2.x + vector34 * barycentricCoordinate2.y + vector35 * barycentricCoordinate2.z;
					Vector3 vector40 = vector30 * barycentricCoordinate2.x + vector31 * barycentricCoordinate2.y + vector32 * barycentricCoordinate2.z;
					valueTuple.Item2.hitData.wNormal = vector39;
					valueTuple.Item2.hitData.wPoint = vector40;
					this.particleData[i] = valueTuple;
				}
				this.isCooked = true;
			}

			// Token: 0x0400029E RID: 670
			[TupleElementNames(new string[] { "selfData", "nextData" })]
			private readonly List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> particleData;

			// Token: 0x0400029F RID: 671
			public bool isCooked;
		}

		// Token: 0x0200006C RID: 108
		private class AddingSkinHandler : PedidoDePhyscisBakeDeSkin.IUser
		{
			// Token: 0x0600026D RID: 621 RVA: 0x0001169C File Offset: 0x0000F89C
			public AddingSkinHandler([TupleElementNames(new string[] { "selfData", "nextData" })] List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> ParticleData)
			{
				this.particleData = ParticleData;
			}

			// Token: 0x0600026E RID: 622 RVA: 0x000116AC File Offset: 0x0000F8AC
			void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
			{
				for (int i = this.particleData.Count - 1; i >= 0; i--)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.particleData[i];
					SemenPuntoCollisionContraSkin.SkinHitResult result = SemenPuntoCollisionContraSkin.SkinHitResult.GetResult(sender.owner.skinnedMeshRenderer.transform.rotation * valueTuple.Item1.semenData.hitData.initialLocalRotationFromMesh, sender, collider, -valueTuple.Item1.semenData.hitData.wNormal, valueTuple.Item1.semenData.hitData.wPoint, valueTuple.Item1.semenData.hitData.prioridad, valueTuple.Item1.semenData.hitData.semenColliderOffset, 1f, 0f);
					valueTuple.Item1.semenData.hitData = result.data;
					if (!result.data.usable)
					{
						valueTuple.Item1.semenData.existio = false;
						valueTuple.Item2.existio = false;
						if (valueTuple.Item1.partesImpactadas.IsCreated)
						{
							valueTuple.Item1.partesImpactadas.Dispose();
						}
						this.particleData.RemoveAt(i);
					}
					else
					{
						if (valueTuple.Item2.existio)
						{
							SemenPuntoCollisionContraSkin.SkinHitResult result2 = SemenPuntoCollisionContraSkin.SkinHitResult.GetResult(sender.owner.skinnedMeshRenderer.transform.rotation * valueTuple.Item2.hitData.initialLocalRotationFromMesh, sender, collider, -valueTuple.Item2.hitData.wNormal, valueTuple.Item2.hitData.wPoint, valueTuple.Item2.hitData.prioridad, valueTuple.Item2.hitData.semenColliderOffset, 1f, 0f);
							valueTuple.Item2.hitData = result2.data;
							if (!result2.data.usable)
							{
								valueTuple.Item2.existio = false;
							}
						}
						this.particleData[i] = valueTuple;
					}
				}
				this.isCooked = true;
			}

			// Token: 0x040002A0 RID: 672
			[TupleElementNames(new string[] { "selfData", "nextData" })]
			private readonly List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> particleData;

			// Token: 0x040002A1 RID: 673
			public bool isCooked;
		}
	}
}
